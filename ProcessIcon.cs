using System;
using System.Windows.Forms;
using StockStopAlerts.Properties;
using System.Collections.Generic;
using System.IO;

namespace StockStopAlerts
{
    class ProcessIcon : IDisposable
    {
        private readonly NotifyIcon notifyIcon;
        private static Timer timer;
        private bool initialUpdate = true;
        private bool newDatabase = false;
        private DateTime lastUpdate;
        private struct StopAlert
        {
            public string symbol;
            public decimal close;
            public decimal stop;
        }
        private readonly List<StopAlert> stopAlerts = new List<StopAlert>();

        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            notifyIcon = new NotifyIcon();
        }

        /// <summary>
        /// This is where the app starts executing.
        /// To start, update the current positions in the PositionsTable if the last update
        /// was made earlier than today
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display(bool disableUpdate)
        {
            string dbFile = Program.settings.GetStringValue("Database Filename");
            if (string.IsNullOrEmpty(dbFile))
            {
                dbFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\StockStopAlerts.db";
            }

            if (!File.Exists(dbFile))
            {
                SettingsDialog dlg = new SettingsDialog(dbFile);
                DialogResult rtn = dlg.ShowDialog();
                if (rtn == DialogResult.OK && !String.IsNullOrEmpty(dlg.DatabaseLocation))
                {
                    Program.settings.SetStringValue("Database Filename", dlg.DatabaseLocation);
                    Program.positionsTable.SetDatabaseLocation(dlg.DatabaseLocation);
                    if (dlg.CreateNew || !File.Exists(dlg.DatabaseLocation))
                    {
                        newDatabase = true;
                        Program.positionsTable.CreateDatabase();
                    }
                }
            }
            else
            {
                Program.positionsTable.SetDatabaseLocation(dbFile);
            }

            // Put the icon in the system tray and allow it react to mouse clicks.			
            notifyIcon.MouseClick += new MouseEventHandler(Icon_MouseClick);
            notifyIcon.Icon = Resources.AppIcon;
            notifyIcon.Text = "Stock Stop Alerts";
            notifyIcon.Visible = true;

            // Attach a context menu.
            notifyIcon.ContextMenuStrip = new ContextMenus().Create(newDatabase);

            if (!disableUpdate)
            {
                // Create a timer
                timer = new Timer { Interval = 1000 };
                timer.Tick += (sender, e) => TimerEventProcessor(this);
                timer.Start();
            }
        }

        /// <summary>
        /// Called every 30 minutes to check the time of day.
        /// After 10:00 PM UTC on a week day it will call a function
        /// to get the closing prices of all the positions in the PositionsTable.
        /// </summary>
        private static void TimerEventProcessor(ProcessIcon pi)
        {
            bool updateNow = false;
            if (pi.initialUpdate)
            {
                timer.Interval = 1000 * 60 * 30;    // 30 minutes
                pi.initialUpdate = false;
                updateNow = true;
            }
            DateTime now = DateTime.UtcNow;
            DateTime previousUpdate = Program.settings.GetDateTimeValue("Last Update");
            if (!updateNow && now.Date == previousUpdate.Date)
            {
                Logger.Log("TimerEventProcessor(): already updated for today");
                return;
            }
            DayOfWeek dow = now.DayOfWeek;
            if (!updateNow && (dow == DayOfWeek.Sunday || dow == DayOfWeek.Saturday))
            {
                return;
            }
            if (updateNow || now.Hour == 22)
            {
                timer.Stop();
                Logger.Log("TimerEventProcessor(): calling CheckClosingPrices()");
                pi.CheckClosingPrices();
                Logger.Log("TimerEventProcessor(): returned from CheckClosingPrices()");
                updateNow = false;
                timer.Start();
            }
            else
                Logger.Log("TimerEventProcessor(): waiting for 10 PM GMT");
        }

        private void CheckClosingPrices()
        {
            lastUpdate = DateTime.Now;
            stopAlerts.Clear();
            CheckClosingPricesAlphaVantage();
            CheckCryptoCurrencies();
            if (stopAlerts.Count != 0)
            {
                Logger.Log(string.Format($"CheckClosingPrices() showing {stopAlerts.Count} alerts"));
                ShowAlerts();
            }
            Logger.Log(string.Format($"CheckClosingPrices() updating settings.LastUpdate to {lastUpdate}"));
            Program.settings.SetDateTimeValue("Last Update", lastUpdate);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            notifyIcon.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the notifyIcon control.
        /// </summary>
        private void Icon_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // View database
                ViewDialog dlg = new ViewDialog();
                dlg.ShowDialog();
            }
        }

        private async void CheckClosingPricesAlphaVantage()
        {
            //lastUpdate = DateTime.Now;
            if (!Program.positionsTable.GetAllRecords(out List<ViewData> list))
            {
                Logger.Log("CheckClosingPricesAlphaVantage(): PositionsTable.GetAllRecords returned false");
                return;
            }
            foreach (ViewData data in list)
            {
                if (data.symbol[0] == '_')  // non-stock position (cash, 401K, etc)
                    continue;
                if (data.symbol[0] == '^')  // Crypto-currency
                    continue;

                IStockQuote avQuote = new AlphaVantageQuote();
                DateTime start = data.buyDate;  // recalculate all dividends since stock was bought
                Logger.Log(String.Format($"CheckClosingPricesAlphaVantage(): calling avQuote.GetQuote({data.symbol}, {start.ToShortDateString()}, ..)"));
                bool success = await avQuote.GetQuote(data.symbol, start, out StockQuote quote);
                if (success)
                {
                    if (quote.highest <= data.highestClose)
                    {
                        quote.highest = 0;  // doesn't change the existing value in the database
                    }
                    this.lastUpdate = quote.date;

                    // Use updated dividends (if available) for the stop calculations below
                    success = await avQuote.GetDividends(data.symbol, data.buyDate, out decimal dividends);
                    if (success)
                    {
                        if (dividends < data.dividends)
                            dividends = data.dividends;     // retain value in database if it's higher than the calculated value.
                    }
                    else
                        dividends = data.dividends;

                    Logger.Log(String.Format($"CheckClosingPricesAlphaVantage(): calling PositionsTable.UpdateRecord({data.symbol}, .., {quote.close.ToString()})"));
                    Program.positionsTable.UpdateRecord(data.id, quote.date, quote.highest, dividends, quote.close);
                    CheckStop(data, quote, dividends);
                }
                else
                {
                    Logger.Log(string.Format($"CheckClosingPricesAlphaVantage(): avQuote.GetQuote('{data.symbol}') failed"));
                }
            }
        }

        private async void CheckCryptoCurrencies()
        {
            lastUpdate = DateTime.Now;
            if (!Program.positionsTable.GetAllRecords(out List<ViewData> list))
            {
                Logger.Log("CheckCryptoCurrencies(): PositionsTable.GetAllRecords returned false");
                return;
            }

            foreach (ViewData data in list)
            {
                if (data.symbol[0] != '^')
                    continue;

                string id = data.symbol.Substring(1);
                IStockQuote avQuote = new AlphaVantageQuote();
                bool success = await avQuote.GetCryptoQuote(id, data.buyDate, out StockQuote quote);
                if (success)
                {
                    this.lastUpdate = quote.date;
                    Logger.Log(String.Format($"CheckClosingPricesAlphaVantage(): calling PositionsTable.UpdateRecord({data.symbol}, .., {quote.close.ToString()})"));
                    Program.positionsTable.UpdateRecord(data.id, quote.date, quote.highest, 0, quote.close);
                    CheckStop(data, quote, 0);
                }
                else
                {
                    Logger.Log(String.Format($"CheckCryptoCurrencies(): avQuote.GetCryptoQuote({data.symbol}) failed"));
                }
            }
        }

        private void CheckStop(ViewData data, StockQuote quote, decimal dividends)
        {
            bool showAlert = false;
            Decimal stopPrice = data.fixedStop;
            if (data.fixedStop != 0 && data.fixedStop >= quote.close)
                showAlert = true;

            if (data.stopPercent != 0)
            {
                if (data.useTrailing)
                {
                    Decimal highestClose = data.highestClose;
                    if (quote.highest > data.highestClose)
                        highestClose = quote.highest;

                    Decimal referencePrice = highestClose;
                    if (data.useDividends)
                        referencePrice -= dividends;
                    if (data.useOptions)
                        referencePrice -= data.options;
                    Decimal subtractedPercentage = referencePrice * data.stopPercent / 100;
                    stopPrice = referencePrice - subtractedPercentage;
                    if (quote.close <= stopPrice)
                        showAlert = true;
                }
                else
                {
                    Decimal referencePrice = data.buyPrice;
                    if (data.useDividends)
                        referencePrice -= data.dividends;
                    if (data.useOptions)
                        referencePrice -= data.options;
                    Decimal subtractedPercentage = referencePrice * data.stopPercent / 100;
                    stopPrice = referencePrice - subtractedPercentage;
                    if (quote.close <= stopPrice)
                        showAlert = true;
                }
            }

            if (showAlert)
            {
                StopAlert alert = new StopAlert { symbol = data.symbol, close = quote.close, stop = stopPrice };
                stopAlerts.Add(alert);
            }
        }

        private void ShowAlerts()
        {
            foreach (var item in stopAlerts)
            {
                MessageBox.Show($"Symbol {item.symbol} has closed at {item.close} which is below its stop of {item.stop}", "Stock Stop Alert!");
            }
        }

    }   // class
}       // namespace