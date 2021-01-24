using System;
using System.Collections.Generic;

namespace StockStopAlerts
{
    public struct ViewData
    {
        internal long id;
        internal string symbol;
        internal DateTime buyDate;
        internal Decimal buyPrice;
        internal Double sharesBought;
        internal Double numShares;
        internal Decimal highestClose;
        internal Decimal lastClose;
        internal Decimal fixedStop;
        internal int stopPercent;
        internal bool useTrailing;
        internal bool useDividends;
        internal Decimal dividends;
        internal bool useOptions;
        internal Decimal options;
        internal DateTime lastUpdate;
    }

    public abstract class IPositionsTable
    {
        public abstract void SetDatabaseLocation(string filename);

        public abstract bool CreateDatabase();

        public abstract bool AddRecord(
            string symbol, int stopPercent, bool useTrailing, DateTime buyDate, double sharesBought, double numShares, decimal buyPrice,
            bool useDividends, decimal dividends, bool useOptions, decimal options, decimal fixedStop);

        public abstract bool UpdateRecord(
            long id, string symbol, int stopPercent, bool useTrailing, DateTime buyDate, double sharesBought, double numShares, decimal buyPrice,
            bool useDividends, decimal dividends, bool useOptions, decimal options, decimal fixedStop);

        /// <summary>
        /// Retrieves all of the records into a DataTable
        /// </summary>
        /// <returns> 1 if records were successfully retrieved </returns>
        public abstract bool GetAllRecords(out List<ViewData> list);

        /// <summary>
        /// Deletes the row that matches the given id
        /// </summary>
        /// <param name="data"></param>
        public abstract bool DeleteRecord(long id);

        /// <summary>
        /// Updates the row that matches the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="highestClose"></param>
        /// <returns></returns>
        public abstract bool UpdateRecord(long id, DateTime lastUpdate, Decimal highestClose, Decimal dividends, Decimal lastClose);
    }
}
