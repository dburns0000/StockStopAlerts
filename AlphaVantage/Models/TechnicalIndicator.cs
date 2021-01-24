using System;
using System.Collections.Generic;
using System.Text;

namespace Kermor.AlphaVantage
{
	public abstract class TechnicalIndicator
	{
		public string Name { get; set; }
		public List<APIParameter> parameters = new List<APIParameter>();
	}
}
