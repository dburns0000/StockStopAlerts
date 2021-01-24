using System;
using System.Threading.Tasks;

namespace StockStopAlerts
{
    public struct StockQuote
    {
        public DateTime date;
        public decimal close;
        public decimal highest;
        internal StockQuote(DateTime d, decimal c, decimal h) { date = d; close = c; highest = h; }
    }

    public abstract class IStockQuote
    {
        /// <summary>
        /// Retrieves prices for a given stock/fund from the starting date to the present
        /// </summary>
        /// <param name="stock"> Stock symbol </param>
        /// <param name="start"> Start date </param>
        /// <returns> true if data received successfully, false if not </returns>
        public abstract Task<bool> GetQuote(string stock, DateTime start, out StockQuote quote);

        /// <summary>
        /// Retrieves dividends for a given stock/fund from the starting date to the present
        /// </summary>
        /// <param name="stock"> Stock symbol </param>
        /// <param name="start"> Start date </param>
        /// <returns> true if data received successfully, false if not </returns>
        public abstract Task<bool> GetDividends(string stock, DateTime start, out decimal dividends);

        public abstract Task<bool> GetCryptoQuote(string currency, DateTime start, out StockQuote quote);

        }
    }
