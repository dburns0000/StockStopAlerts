using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kermor.AlphaVantage
{
	public static class AlphaVantage
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="timeseries"></param>
		/// <param name="outputsize"></param>
		/// <param name="apikey"></param>
		/// <returns></returns>
		public static MarketData Stock(string symbol, AVTimeSeries timeseries, AVOutputSize outputsize, string apikey)
		{
			MarketData dataTmp = new MarketData(symbol);

			List<APIParameter> parameters = new List<APIParameter>()
			{
				new APIParameter("function", timeseries.GetValue()),
				new APIParameter("symbol", symbol),
				new APIParameter("outputsize", outputsize.GetValue()),
				new APIParameter("apikey", apikey),
				new APIParameter("datatype", "csv")
			};

			int[] dataMap = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            string url = AlphaVantageHelper.CreateURL(parameters);
            string rawData = AlphaVantageHelper.RequestRawData(url);
			if (rawData == null)
			{
				return null;
			}
            string[] result = Regex.Split(rawData, "\r\n|\r|\n");
            AlphaVantageHelper.ProcessRawData(result, ref dataTmp.Bars, dataMap);
			return dataTmp;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="timeseries"></param>
		/// <param name="interval"></param>
		/// <param name="outputsize"></param>
		/// <param name="apikey"></param>
		/// <returns></returns>
		public static MarketData Stock(string symbol, AVTimeSeries timeseries, AVInterval interval, AVOutputSize outputsize, string apikey)
		{
			MarketData dataTmp = new MarketData(symbol);

			List<APIParameter> parameters = new List<APIParameter>()
			{
				new APIParameter("function", timeseries.GetValue()),
				new APIParameter("symbol", symbol),
				new APIParameter("interval", interval.GetValue()),
				new APIParameter("outputsize", outputsize.GetValue()),
				new APIParameter("apikey", apikey),
				new APIParameter("datatype", "csv")
			};

			int[] dataMap = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            string url = AlphaVantageHelper.CreateURL(parameters);
            string rawData = AlphaVantageHelper.RequestRawData(url);
			if (!string.IsNullOrEmpty(rawData))
			{ 
				string[] result = Regex.Split(rawData, "\r\n|\r|\n");
				AlphaVantageHelper.ProcessRawData(result, ref dataTmp.Bars, dataMap);
			}

			return dataTmp;
		}

		public static MarketData CryptoCurrency(string symbol, string apikey)
		{
			MarketData dataTmp = new MarketData(symbol);

			List<APIParameter> parameters = new List<APIParameter>()
			{
				new APIParameter("function", "DIGITAL_CURRENCY_DAILY"),
				new APIParameter("symbol", symbol),
				new APIParameter("market", "USD"),
				new APIParameter("apikey", apikey),
				new APIParameter("datatype", "csv")
			};

			int[] dataMap = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			string url = AlphaVantageHelper.CreateURL(parameters);
			string rawData = AlphaVantageHelper.RequestRawData(url);
			if (rawData == null)
			{
				return null;
			}
			string[] result = Regex.Split(rawData, "\r\n|\r|\n");
			AlphaVantageHelper.ProcessRawData(result, ref dataTmp.Bars, dataMap);
			return dataTmp;
		}

	}
}
