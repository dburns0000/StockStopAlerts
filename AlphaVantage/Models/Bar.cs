using System;
using System.Collections.Generic;
using System.Text;

namespace Kermor.AlphaVantage
{
    public struct Bar
    {
		public double open;
		public double high;
		public double low;
		public double close;
        public double adjusted_close;
        public double volume;
        public double dividend_amount;
        public double split_coefficient;
        public DateTime timestamp;

		public Bar(double open, double high, double low, double close, double adjusted_close,
                   double volume, double dividend_amount, double split_coefficient, DateTime timestamp)
		{
			this.open = open;
			this.high = high;
			this.low = low;
			this.close = close;
            this.adjusted_close = adjusted_close;
            this.volume = volume;
            this.dividend_amount = dividend_amount;
            this.split_coefficient = split_coefficient;
			this.timestamp = timestamp;
		}

		public string ToLine(string DateTimeFormat = "dd/MM/yyyy HH:mm")
		{
			return timestamp.ToString(DateTimeFormat) + "," + open + "," + high + "," + low + "," + close + "," + volume;
		}
    }
}
