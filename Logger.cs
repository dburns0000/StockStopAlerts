using System;
using System.IO;

namespace StockStopAlerts
{
    public static class Logger
    {
        private static readonly string logFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\StockStopAlerts.log";

        public static void Log(string message)
        {
            using (StreamWriter w = File.AppendText(logFile))
            {
                w.WriteLine("{0} {1} : {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), message);
            }
        }
    }
}
