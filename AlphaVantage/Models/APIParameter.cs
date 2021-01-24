using System;
using System.Collections.Generic;
using System.Text;

namespace Kermor.AlphaVantage
{
	public class APIParameter
	{
		private readonly string _name;
		private readonly string _value;

		public APIParameter(string name, string value)
		{
			_name = name;
			_value = value;
		}

		public string ToApiString() => $"&{_name}={_value}";
	}
}
