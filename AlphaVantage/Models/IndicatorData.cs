using System;
using System.Collections.Generic;

namespace Kermor.AlphaVantage
{
    public class IndicatorData
    {
		public string name;
		public Dictionary<DateTime, List<IndicatorSingleValue>> Values = new Dictionary<DateTime, List<IndicatorSingleValue>>();

		public IndicatorData(string name)
		{
			this.name = name;
		}
    }
}
