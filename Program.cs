using System;
using System.Windows.Forms;

namespace StockStopAlerts
{

	/// <summary>
	/// 
	/// </summary>
	public static class Program
	{
        public static ISettings settings;
        public static IPositionsTable positionsTable;
        public static string ApiKey { get; private set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            settings = new RegistrySettings("Software\\StockStopAlerts");
            positionsTable = new SQLitePositionsTable();

			if (args.Length < 1)
            {
				MessageBox.Show("The Alpha Vantage API key is required as a command-line argument.\n" +
					"Get your free API key at https://www.alphavantage.co", "Stock Stop Alerts");
				return;
            }
			ApiKey = args[0];
			bool disableUpdate = args.Length == 2 && args[1] == "-du";

			// Show the system tray icon.					
			using (ProcessIcon pi = new ProcessIcon())
			{
                pi.Display(disableUpdate);

				// Make sure the application runs!
				Application.Run();
			}
		}
	}
}