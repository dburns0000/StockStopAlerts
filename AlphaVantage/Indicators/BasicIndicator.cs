namespace Kermor.AlphaVantage
{
	public class BasicIndicator: TechnicalIndicator
    {
		public BasicIndicator(string name, int timeperiod = 30)
		{
			Name = name;
			parameters.Add(new APIParameter("time_period", timeperiod.ToString()));
		}
	}
}
