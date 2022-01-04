using System;
using System.Drawing;
using System.Windows.Forms;

namespace StockStopAlerts
{
    public partial class EditDialog : Form
    {
        readonly bool editing = false;
        ViewData data;
        const string winPos = "Edit Window Position";
        int stopPercentage = 0;
        decimal fixedStopPrice = 0;
        bool useTrailingStop = false;
        bool useDividends = false;
        bool useOptions = false;
        double sharesBought = 0;
        double numShares = 0;
        decimal buyPrice = 0;
        decimal dividends = 0;
        decimal options = 0;

        public EditDialog()
        {
            InitializeComponent();
            fixedPrice_radioButton.Checked = true;
            FixedPrice_radioButton_CheckedChanged(null, null);
            options_textBox.Text = "0";
            dividends_textBox.Text = "0";
        }

        public EditDialog(ViewData data)
        {
            InitializeComponent();
            this.data = data;
            editing = true;
            UpdateFields();
        }

        /// <summary>
        /// Fills in the dialog controls from the data member
        /// </summary>
        private void UpdateFields()
        {
            symbol_textBox.Text = data.symbol;
            sharesBought_textBox.Text = data.sharesBought.ToString();
            currentShares_textBox.Text = data.numShares.ToString();
            buy_dateTimePicker.Value = data.buyDate;
            buyPrice_textBox.Text = data.buyPrice.ToString();
            options_textBox.Text = data.options.ToString();
            dividends_textBox.Text = data.dividends.ToString();
            useDividends_checkBox.Checked = data.useDividends;
            useOptionSales_checkBox.Checked = data.useOptions;
            useTrailingStop_checkBox.Checked = data.useTrailing;
            if (data.fixedStop != 0)
            {
                fixedStopPrice_textBox.Text = data.fixedStop.ToString();
                fixedPrice_radioButton.Checked = true;
                percentage_radioButton.Checked = false;
                currentStopPrice_textBox.Text = data.fixedStop.ToString();
            }
            else
            {
                fixedPrice_radioButton.Checked = false;
                percentage_radioButton.Checked = true;
                stopLossPercentage_textBox.Text = data.stopPercent.ToString();
                if (data.stopPercent != 0)
                {
                    if (data.useTrailing)
                    {
                        decimal referencePrice = data.highestClose;
                        if (data.useDividends)
                            referencePrice -= data.dividends;
                        if (data.useOptions)
                            referencePrice -= data.options;
                        decimal subtractedPercentage = referencePrice * data.stopPercent / 100;
                        decimal stopPrice = referencePrice - subtractedPercentage;
                        currentStopPrice_textBox.Text = stopPrice.ToString();
                    }
                    else
                    {
                        decimal referencePrice = data.buyPrice;
                        if (data.useDividends)
                            referencePrice -= data.dividends;
                        if (data.useOptions)
                            referencePrice -= data.options;
                        decimal subtractedPercentage = referencePrice * data.stopPercent / 100;
                        decimal stopPrice = referencePrice - subtractedPercentage;
                        currentStopPrice_textBox.Text = stopPrice.ToString();
                    }
                }
            }
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                return;

            UpdateDatabase();
            UpdateCurrentStopPrice();
        }

        private void UpdateCurrentStopPrice()
        {
            if (fixedStopPrice != 0)
            {
                currentStopPrice_textBox.Text = fixedStopPrice.ToString();
            }
            else
            {
                if (stopPercentage != 0)
                {
                    if (useTrailingStop)
                    {
                        decimal referencePrice = editing ? data.highestClose : buyPrice;
                        if (useDividends && editing)
                            referencePrice -= data.dividends;
                        if (useOptions)
                            referencePrice -= options;
                        decimal subtractedPercentage = referencePrice * stopPercentage / 100;
                        decimal stopPrice = referencePrice - subtractedPercentage;
                        currentStopPrice_textBox.Text = stopPrice.ToString();
                    }
                    else
                    {
                        decimal referencePrice = buyPrice;
                        if (useDividends)
                            referencePrice -= dividends;
                        if (useOptions)
                            referencePrice -= options;
                        decimal subtractedPercentage = referencePrice * stopPercentage / 100;
                        decimal stopPrice = referencePrice - subtractedPercentage;
                        currentStopPrice_textBox.Text = stopPrice.ToString();
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types")]
        private void Ok_button_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                return;

            UpdateDatabase();
            Close();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidateEntries()
        {

            try
            {
                sharesBought = double.Parse(sharesBought_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("# of shares bought is not a valid number");
                return false;
            }

            try
            {
                numShares = double.Parse(currentShares_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Current # of shares is not a valid number");
                return false;
            }

            try
            {
                buyPrice = decimal.Parse(buyPrice_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Buy price is not a valid number");
                return false;
            }

            if (fixedPrice_radioButton.Checked)
            {
                try
                {
                    fixedStopPrice = decimal.Parse(fixedStopPrice_textBox.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Fixed stop price is not a valid number");
                    return false;
                }

            }
            else
            {
                try
                {
                    stopPercentage = int.Parse(stopLossPercentage_textBox.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Stop loss percentage is not a valid number");
                    return false;
                }
                useTrailingStop = useTrailingStop_checkBox.Checked;
                useDividends = useDividends_checkBox.Checked;
                useOptions = useOptionSales_checkBox.Checked;
            }

            try
            {
                dividends = decimal.Parse(dividends_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Dividends is not a valid number");
                return false;
            }

            try
            {
                options = decimal.Parse(options_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Option Sales is not a valid number");
                return false;
            }

            return true;
        }

        private void UpdateDatabase()
        {
            if (editing)
            {
                Program.positionsTable.UpdateRecord(
                    data.id,
                    symbol_textBox.Text,
                    stopPercentage,
                    useTrailingStop,
                    buy_dateTimePicker.Value,
                    sharesBought,
                    numShares,
                    buyPrice,
                    useDividends,
                    dividends,
                    useOptions,
                    options,
                    fixedStopPrice
                    );
            }
            else
            {
                // Add position to the database
                Program.positionsTable.AddRecord(
                    symbol_textBox.Text,
                    stopPercentage,
                    useTrailingStop,
                    buy_dateTimePicker.Value,
                    sharesBought,
                    numShares,
                    buyPrice,
                    useDividends,
                    dividends,
                    useOptions,
                    options,
                    fixedStopPrice
                    );
            }
        }

        private void FixedPrice_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!editing)
            {
                fixedStopPrice_textBox.Enabled = true;
                stopLossPercentage_textBox.Enabled = false;
                useTrailingStop_checkBox.Enabled = false;
                useDividends_checkBox.Enabled = false;
                useOptionSales_checkBox.Enabled = false;
            }
        }

        private void Percentage_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!editing)
            {
                fixedStopPrice_textBox.Enabled = false;
                stopLossPercentage_textBox.Enabled = true;
                useTrailingStop_checkBox.Enabled = true;
                useDividends_checkBox.Enabled = true;
                useOptionSales_checkBox.Enabled = true;
            }
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            Point position = Program.settings.GetPointValue(winPos);
            if (position.X != 0 || position.Y != 0)
                this.Location = position;
        }

        private void EditDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.settings.SetPointValue(winPos, this.Location);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types")]
        private void AddDiv_button_Click(object sender, EventArgs e)
        {
            decimal additionalDividend;
            try
            {
                additionalDividend = decimal.Parse(addDiv_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Additional dividend is not a valid number");
                addDiv_textBox.Text = "";
                return;
            }

            decimal dividends;
            try
            {
                dividends = decimal.Parse(dividends_textBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Dividends is not a valid number");
                return;
            }

            dividends += additionalDividend;
            dividends_textBox.Text = dividends.ToString();
        }

    }
}
