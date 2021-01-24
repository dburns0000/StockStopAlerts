using System;

namespace Kermor.AlphaVantage
{
    public sealed class EnumValue : Attribute
    {
        public string Value { get; private set; }

        public EnumValue(string value)
        {
            Value = value;
        }
    }
}
