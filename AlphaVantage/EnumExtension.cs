using System;
using System.Reflection;

namespace Kermor.AlphaVantage
{
    public static class EnumExtension
    {
		public static string GetValue(this Enum value)
		{
			string stringValue = value.ToString();
			Type type = value.GetType();
			FieldInfo fieldInfo = type.GetField(value.ToString());
			EnumValue[] attrs = fieldInfo.
				GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];
			if (attrs.Length > 0)
			{
				stringValue = attrs[0].Value;
			}
			return stringValue;
		}
	}
}
