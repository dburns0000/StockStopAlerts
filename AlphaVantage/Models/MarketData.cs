using System;
using System.Collections.Generic;
using System.Text;

namespace Kermor.AlphaVantage
{
    public class MarketData
    {
		public string Symbol;
		public string Currency;
		public Dictionary<DateTime, Bar> Bars;

		public MarketData(string symbol, string currency = "USD")
		{
			this.Symbol = symbol;
			this.Currency = currency;
			this.Bars = new Dictionary<DateTime, Bar>();
		}
    }
}
