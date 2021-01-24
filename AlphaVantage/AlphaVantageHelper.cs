using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Kermor.AlphaVantage
{
	public static  class AlphaVantageHelper
    {
        public static string ExceptionMessage { get; set; }

		public static string CreateURL(List<APIParameter> APIParameters)
		{
			return APIParameters.Aggregate(@"https://www.alphavantage.co/query?", (current, param) => current + param.ToApiString());
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Too many possible types")]
		public static string RequestRawData(string url)
		{
			try
			{
				HttpWebResponse response = (HttpWebResponse)WebRequest.Create(url).GetResponse();

				using (StreamReader Stream = new StreamReader(response.GetResponseStream()))
				{
					var result = Stream.ReadToEnd();

					Stream.Close();
					response.Close();

					return (string)result;
				}

			}
            catch (Exception e)
			{
                ExceptionMessage = e.Message;
				return null;
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "False positive")]
		public static void ProcessRawData(string[] data, ref Dictionary<DateTime, Bar> bars, int[] dataMap)
		{

			for (int i = 1; i < data.Length; i++)
			{
				string[] barData = data[i].Split(',');

				try
				{
					DateTime barDateTmp = Convert.ToDateTime(barData[dataMap[0]]);

					bars.Add(barDateTmp, new Bar(
                                            Math.Round(Convert.ToDouble(barData[dataMap[1]]), 2),
											Math.Round(Convert.ToDouble(barData[dataMap[2]]), 2),
                                            Math.Round(Convert.ToDouble(barData[dataMap[3]]), 2),
											Math.Round(Convert.ToDouble(barData[dataMap[4]]), 2),
                                            Math.Round(Convert.ToDouble(barData[dataMap[5]]), 2),
                                            Math.Round(Convert.ToDouble(barData[dataMap[6]]), 0),
                                            Math.Round(Convert.ToDouble(barData[dataMap[7]]), 3),
                                            Math.Round(Convert.ToDouble(barData[dataMap[8]]), 3),
                                            barDateTmp));
				}
				catch (FormatException)
				{
					//nothing to do, empty or does not contain ohlc data
				}
			}

		}
	}
}
