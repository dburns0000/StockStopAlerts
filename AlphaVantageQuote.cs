using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kermor.AlphaVantage;

namespace StockStopAlerts
{
    public class AlphaVantageQuote : IStockQuote
    {
        private readonly string AlphaVantageAPIKey = Program.ApiKey;
        private readonly Dictionary<string, MarketData> retrievedValues = new Dictionary<string, MarketData>();

        /// <summary>
        /// Retrieves prices for a given stock/fund from the starting date to the present
        /// </summary>
        /// <param name="stock"> Stock symbol </param>
        /// <param name="start"> Start date - used for highest price since bought </param>
        /// <returns> true if data received successfully, false if not </returns>
        public override Task<bool> GetQuote(string stock, DateTime start, out StockQuote quote)
        {
            if (retrievedValues.ContainsKey(stock))
            {
                MarketData cachedStockData = retrievedValues[stock];
                DateTime cachedDate = DateTime.Today;
                double cachedClose = 0;
                double cachedHighest = 0;
                bool firstItem = true;
                foreach (var item in cachedStockData.Bars)
                {
                    if (firstItem)
                    {
                        cachedDate = item.Key;
                        cachedClose = item.Value.close;
                        firstItem = false;
                    }
                    if (start >= item.Value.timestamp && item.Value.close > cachedHighest)
                        cachedHighest = item.Value.close;
                    if (item.Key < start)
                        break;
                }
                quote.date = cachedDate;
                quote.close = (decimal)cachedClose;
                quote.highest = (decimal)cachedHighest;
                return Task.FromResult(true);
            }

            MarketData stockData = AlphaVantage.Stock(stock, AVTimeSeries.Stock_Daily, AVOutputSize.full, AlphaVantageAPIKey);
            if (stockData == null)
            {
                quote.date = DateTime.Today;
                quote.close = 0;
                quote.highest = 0;
                return Task.FromResult(false);
            }
            int tries = 0;
            while (stockData.Bars.Count == 0 && tries++ <= 5)
            {
                Thread.Sleep(10000);
                stockData = AlphaVantage.Stock(stock, AVTimeSeries.Stock_Daily, AVOutputSize.full, AlphaVantageAPIKey);
                if (stockData == null)
                {
                    quote.date = DateTime.Today;
                    quote.close = 0;
                    quote.highest = 0;
                    return Task.FromResult(false);
                }
            }
            if (stockData.Bars.Count == 0)
            {
                quote.date = DateTime.Today;
                quote.close = 0;
                quote.highest = 0;
                return Task.FromResult(false);
            }

            DateTime date = DateTime.Today;
            double close = 0;
            double highest = 0;
            bool first = true;
            foreach (var item in stockData.Bars)
            {
                if (first)
                {
                    date = item.Key;
                    close = item.Value.close;
                    first = false;
                }
                if (item.Value.close > highest)
                    highest = item.Value.close;
                if (item.Key < start)
                    break;
            }
            quote.date = date;
            quote.close = (decimal)close;
            quote.highest = (decimal)highest;
            retrievedValues.Add(stock, stockData);
            return Task.FromResult(true);
        }

#if false   // requires paid subscription to AlphaVantage
        /// <summary>
        /// Retrieves prices for a given stock/fund from the starting date to the present
        /// </summary>
        /// <param name="stock"> Stock symbol </param>
        /// <param name="start"> Start date </param>
        /// <returns> true if data received successfully, false if not </returns>
        public override Task<bool> GetDividends(string stock, DateTime start, out Decimal dividends)
        {
            dividends = (decimal)sumOfDividends;
            return Task.FromResult(true);
        }
#endif

        /// <summary>
        /// Retrieves prices for a given stock/fund from the starting date to the present
        /// </summary>
        /// <param name="stock"> Stock symbol </param>
        /// <param name="start"> Start date - used for highest price since bought </param>
        /// <returns> true if data received successfully, false if not </returns>
        public override Task<bool> GetCryptoQuote(string currency, DateTime start, out StockQuote quote)
        {
            MarketData stockData = AlphaVantage.Stock(currency, AVTimeSeries.Digital_Currency_Daily, AVOutputSize.full, AlphaVantageAPIKey);
            if (stockData == null)
            {
                quote.date = DateTime.Today;
                quote.close = 0;
                quote.highest = 0;
                return Task.FromResult(false);
            }
            int tries = 0;
            while (stockData.Bars.Count == 0 && tries++ <= 5)
            {
                Thread.Sleep(10000);
                stockData = AlphaVantage.CryptoCurrency(currency, AlphaVantageAPIKey);
                if (stockData == null)
                {
                    quote.date = DateTime.Today;
                    quote.close = 0;
                    quote.highest = 0;
                    return Task.FromResult(false);
                }
            }
            if (stockData.Bars.Count == 0)
            {
                quote.date = DateTime.Today;
                quote.close = 0;
                quote.highest = 0;
                return Task.FromResult(false);
            }

            DateTime date = DateTime.Today;
            double close = 0;
            double highest = 0;
            bool first = true;
            foreach (var item in stockData.Bars)
            {
                if (first)
                {
                    date = item.Key;
                    close = item.Value.close;
                    first = false;
                }
                if (item.Value.close > highest)
                    highest = item.Value.close;
                if (item.Key < start)
                    break;
            }
            quote.date = date;
            quote.close = (decimal)close;
            quote.highest = (decimal)highest;
            return Task.FromResult(true);
        }

    }   // class
}       // namespace
