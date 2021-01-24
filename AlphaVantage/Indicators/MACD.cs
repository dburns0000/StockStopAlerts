namespace Kermor.AlphaVantage
{
	public class MACD: TechnicalIndicator
    {
		public MACD(int fastperiod = 12,int slowperiod = 26, int signalperiod = 9)
		{
			Name = "MACD";
			parameters.Add(new APIParameter("fastperiod", fastperiod.ToString()));
			parameters.Add(new APIParameter("slowperiod", slowperiod.ToString()));
			parameters.Add(new APIParameter("signalperiod", signalperiod.ToString()));
		}
    }
}
