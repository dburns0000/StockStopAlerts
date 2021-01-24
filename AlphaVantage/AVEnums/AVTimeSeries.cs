namespace Kermor.AlphaVantage
{
	public enum AVTimeSeries
	{
		[EnumValue("TIME_SERIES_INTRADAY")] Stock_Intraday,
		[EnumValue("TIME_SERIES_DAILY")] Stock_Daily,
        [EnumValue("TIME_SERIES_DAILY_ADJUSTED")] Stock_Daily_Adjusted,
        [EnumValue("TIME_SERIES_WEEKLY")] Stock_Weekly,
		[EnumValue("TIME_SERIES_MONTHLY")] Stock_Monthly,
		[EnumValue("DIGITAL_CURRENCY_INTRADAY")] Digital_Currency_Intraday,
		[EnumValue("DIGITAL_CURRENCY_DAILY")] Digital_Currency_Daily,
		[EnumValue("DIGITAL_CURRENCY_WEEKLY")] Digital_Currency_Weekly,
		[EnumValue("DIGITAL_CURRENCY_MONTHLY")] Digital_Currency_Monthly
	}
}
