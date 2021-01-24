namespace Kermor.AlphaVantage
{
	public enum AVInterval {

		[EnumValue("1min")] OneMinute,
		[EnumValue("5min")] FiveMinutes,
		[EnumValue("15min")] FifteenMinutes,
		[EnumValue("30min")] ThirtyMinutes,
		[EnumValue("60min")] SixtyMinutes,
		[EnumValue("daily")] Daily,
		[EnumValue("weekly")] Weekly,
		[EnumValue("monthly")] Monthly

	}
}
