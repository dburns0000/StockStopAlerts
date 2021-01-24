using System;

namespace StockStopAlerts
{
    public abstract class ISettings
    {
        public abstract void SetStringValue(string name, string value, string subKey = null);

        public abstract string GetStringValue(string name, string subKey = null);

        public abstract void SetIntValue(string name, int value, string subKey = null);

        public abstract int GetIntValue(string name, int defaultValue, string subKey = null);

        public abstract void SetPointValue(string name, System.Drawing.Point value, string subKey = null);

        public abstract System.Drawing.Point GetPointValue(string name, string subKey = null);

        public abstract void SetSizeValue(string name, System.Drawing.Size value, string subKey = null);

        public abstract System.Drawing.Size GetSizeValue(string name, string subKey = null);

        public abstract void SetDateTimeValue(string name, DateTime value, string subKey = null);

        public abstract DateTime GetDateTimeValue(string name, string subKey = null);

        public abstract string GetProtected(string name);

        public abstract void SetProtected(string name, string value);

    }
}
