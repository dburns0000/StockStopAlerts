using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace StockStopAlerts
{
    public class SQLitePositionsTable : IPositionsTable
    {
        /// <summary>
        /// Indexes of the various fields (columns)
        /// </summary>
        private enum ColumnIndices : int
        {
            ID, Symbol, BuyDate, SharesBought, BuyPrice,
            NumShares, LastUpdate, LastClose, HighestClose,
            StopPercent, UseTrailing, UseDividends,
            UseOptions, Dividends, OptionsSold, FixedStopPrice
        };

        private string databaseFilename;
        private readonly object syncObject = new object();
        private bool noRecords = false;      // set when database is created
        private readonly SQLiteConnection connection = new SQLiteConnection();

        public override void SetDatabaseLocation(string filename) => databaseFilename = filename;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "SQLiteConnection.Open doesn't list the possible exception types")]
        private bool Open(string function)
        {
            connection.ConnectionString = $"Data Source={databaseFilename};Version=3;New=False;Compress=True;";
            try
            {
                connection.Open();
            }
            catch(SQLiteException e)
            {
                MessageBox.Show($"{function} - error opening database: {e.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{function} - error opening database: {ex.Message}");
                return false;
            }
            return true;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "SQLiteCommand.ExecuteNonQuery doesn't list the possible exception types")]
        private bool ExecuteCommand(string command, string function)
        {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            SQLiteCommand sqlCommand = new SQLiteCommand(command, connection);
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            try
            {
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(function + " - ExecuteNonQuery: " + e.Message);
                Logger.Log(function + " - ExecuteNonQuery: " + e.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(function + " - ExecuteNonQuery: " + ex.Message);
                Logger.Log(function + " - ExecuteNonQuery: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public override bool CreateDatabase()
        {
            string sqlCommand =
                "CREATE TABLE Positions(ID integer UNIQUE," +
                "Symbol text,BuyDate datetime,SharesBought real,BuyPrice real," +
                "NumShares real,LastUpdate datetime,LastClose real,HighestClose real," +
                "StopPercent integer,UseTrailing integer,UseDividends integer," +
                "UseOptions integer,Dividends real,OptionsSold real,FixedStopPrice real)";
            lock (syncObject)
            {
                if (!Open("CreateDatabase"))
                {
                    Logger.Log("CreateDatabase(): Open() failed");
                    return false;
                }
                if (ExecuteCommand(sqlCommand, "CreateDatabase"))
                {
                    noRecords = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string AppendString(string str) => "'" + str + "',";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "SQLiteDataReader.ExecuteReader doesn't list the possible exception types")]
        private int GetNextID()
        {
            if (noRecords)
            {
                return 1;
            }

            string query = "SELECT MAX(ID) FROM Positions";
            try
            {
                SQLiteCommand sqlCommand = new SQLiteCommand(query, connection);
                string results = string.Empty;
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    int value = reader.GetInt32(0);
                    return value + 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("GetNextID:" + e.Message);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetNextID:" + ex.Message);
                return 0;
            }
        }
 
        public override bool AddRecord(
            string symbol, int stopPercent, bool useTrailing, DateTime buyDate, double sharesBought, double numShares, decimal buyPrice,
            bool useDividends, decimal dividends, bool useOptions, decimal options, decimal fixedStop)
        {
            lock (syncObject)
            {
                if (!Open("AddRecord"))
                {
                    Logger.Log(string.Format($"AddRecord({symbol}): Open() failed"));
                    return false;
                }

                int id = GetNextID();
                if (id == 0)
                {
                    connection.Close();
                    return false;
                }

                StringBuilder positions = new StringBuilder("INSERT INTO Positions(");
                StringBuilder values = new StringBuilder(" VALUES(");
                positions.Append("ID,");
                values.Append(id); values.Append(",");

                positions.Append("Symbol,");
                values.Append(AppendString(symbol));

                positions.Append("BuyDate,");
                values.Append(AppendString(buyDate.Date.ToString("yyyy-MM-dd hh:mm:ss")));

                positions.Append("SharesBought,");
                values.Append(sharesBought); values.Append(",");

                positions.Append("BuyPrice,");
                values.Append(buyPrice); values.Append(",");

                positions.Append("NumShares,");
                values.Append(numShares); values.Append(",");

                positions.Append("LastUpdate,");
                values.Append(AppendString(buyDate.Date.ToString("yyyy-MM-dd hh:mm:ss")));

                positions.Append("LastClose,");
                values.Append(buyPrice); values.Append(",");

                positions.Append("HighestClose,");
                values.Append(buyPrice); values.Append(",");

                positions.Append("StopPercent,");
                values.Append(stopPercent); values.Append(",");

                positions.Append("UseTrailing,");
                values.Append(useTrailing ? 1 : 0); values.Append(",");

                positions.Append("UseDividends,");
                values.Append(useDividends ? 1 : 0); values.Append(",");

                positions.Append("UseOptions,");
                values.Append(useOptions ? 1 : 0); values.Append(",");

                positions.Append("Dividends,");
                values.Append(dividends); values.Append(",");

                positions.Append("OptionsSold,");
                values.Append(options); values.Append(",");

                positions.Append("FixedStopPrice)");
                values.Append(fixedStop); values.Append(");");
                positions.Append(values);

                if (ExecuteCommand(positions.ToString(), "AddRecord"))
                {
                    noRecords = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }   // lock scope
        }

        public override bool UpdateRecord(
            long id, string symbol, int stopPercent, bool useTrailing, DateTime buyDate, double sharesBought, double numShares, decimal buyPrice,
            bool useDividends, decimal dividends, bool useOptions, decimal options, decimal fixedStop)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Positions SET Symbol='");
            sb.Append(symbol);
            sb.Append("',StopPercent=");
            sb.Append(stopPercent.ToString());
            sb.Append(",UseTrailing=");
            sb.Append(useTrailing ? "1" : "0");
            sb.Append(",BuyDate='");
            sb.Append(buyDate.Date.ToString("yyyy-MM-dd hh:mm:ss"));
            sb.Append("',SharesBought=");
            sb.Append(sharesBought.ToString());
            sb.Append(",NumShares=");
            sb.Append(numShares.ToString());
            sb.Append(",UseDividends=");
            sb.Append(useDividends ? "1" : "0");
            sb.Append(",Dividends=");
            sb.Append(dividends.ToString());
            sb.Append(",UseOptions=");
            sb.Append(useOptions ? "1" : "0");
            sb.Append(",OptionsSold=");
            sb.Append(options.ToString());
            sb.Append(",BuyPrice=");
            sb.Append(buyPrice.ToString());
            sb.Append(",FixedStopPrice=");
            sb.Append(fixedStop.ToString());
            sb.Append(" WHERE ID=");
            sb.Append(id);
            sb.Append(";");

            lock (syncObject)
            {
                if (!Open("UpdateRecord"))
                {
                    Logger.Log(string.Format($"UpdateRecord({id}): Open() failed"));
                    return false;
                }
                return ExecuteCommand(sb.ToString(), "UpdateRecord");
            }
        }


        private int CompareBySymbol(ViewData obj1, ViewData obj2) => String.Compare(obj1.symbol, obj2.symbol);


        /// <summary>
        /// Retrieves all of the records into a DataTable
        /// </summary>
        /// <returns> 1 if records were successfully retrieved </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "")]
        public override bool GetAllRecords(out List<ViewData> list)
        {
            list = new List<ViewData>();
            lock (syncObject)
            {
                if (!Open("GetAllRecords"))
                {
                    Logger.Log("GetAllRecords: Open() failed");
                    return false;
                }

                SQLiteCommand sqlCommand = new SQLiteCommand("SELECT * FROM Positions", connection);
                string results = string.Empty;
                try
                {
                    SQLiteDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        ViewData record = new ViewData
                        {
                            id = reader.GetInt64((int)ColumnIndices.ID),
                            symbol = reader.GetString((int)ColumnIndices.Symbol),
                            buyDate = reader.GetDateTime((int)ColumnIndices.BuyDate),
                            buyPrice = reader.GetDecimal((int)ColumnIndices.BuyPrice),
                            sharesBought = reader.GetDouble((int)ColumnIndices.SharesBought),
                            numShares = reader.GetDouble((int)ColumnIndices.NumShares),
                            highestClose = reader.GetDecimal((int)ColumnIndices.HighestClose),
                            lastClose = reader.GetDecimal((int)ColumnIndices.LastClose),
                            fixedStop = reader.GetDecimal((int)ColumnIndices.FixedStopPrice),
                            stopPercent = reader.GetInt32((int)ColumnIndices.StopPercent),
                            useTrailing = reader.GetBoolean((int)ColumnIndices.UseTrailing),
                            useDividends = reader.GetBoolean((int)ColumnIndices.UseDividends),
                            dividends = reader.GetDecimal((int)ColumnIndices.Dividends),
                            useOptions = reader.GetBoolean((int)ColumnIndices.UseOptions),
                            options = reader.GetDecimal((int)ColumnIndices.OptionsSold),
                            lastUpdate = reader.GetDateTime((int)ColumnIndices.LastUpdate)
                        };
                        list.Add(record);
                    }
                    reader.Close();
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show("GetAllRecords - " + e.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GetAllRecords - " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }   // lock

            list.Sort(CompareBySymbol);
            return true;
        }

        
        /// <summary>
        /// Deletes the row that matches the given id
        /// </summary>
        /// <param name="data"></param>
        public override bool DeleteRecord(long id)
        {
            string sqlString = string.Format("DELETE FROM Positions WHERE ID={0}", id.ToString());

            lock (syncObject)
            {
                if (!Open("DeleteRecord"))
                {
                    Logger.Log(string.Format($"DeleteRecord({id}): Open() failed"));
                    return false;
                }
                return ExecuteCommand(sqlString, "DeleteRecord");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="highestClose"></param>
        /// <returns></returns>
        public override bool UpdateRecord(long id, DateTime lastUpdate, Decimal highestClose, Decimal dividends, Decimal lastClose)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Positions SET LastUpdate='");
            sb.Append(lastUpdate.Date.ToString("yyyy-MM-dd hh:mm:ss"));
            sb.Append("'");
            sb.Append(",LastClose=");
            sb.Append(lastClose.ToString());
            if (highestClose != 0)
            {
                sb.Append(",HighestClose=");
                sb.Append(highestClose.ToString());
            }
            if (dividends != 0)
            {
                sb.Append(",Dividends=");
                sb.Append(dividends.ToString());
            }
            sb.Append(" WHERE ID=");
            sb.Append(id);
            sb.Append(";");
            string sqlString = sb.ToString();
            Logger.Log(sqlString);

            lock (syncObject)
            {
                if (!Open("UpdateRecord"))
                {
                    Logger.Log(string.Format($"UpdateRecord({id},..): Open() failed"));
                    return false;
                }

                return ExecuteCommand(sqlString, "UpdateRecord");
            }
        }

    }   // class PositionsTable
}   // namespace
