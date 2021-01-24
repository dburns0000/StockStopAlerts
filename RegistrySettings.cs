using System;
using System.Text;
using Microsoft.Win32;      // for Registry classes
using System.Security.Cryptography;

namespace StockStopAlerts
{
    /// <summary>
    /// Manages user settings and saved folder locations via the Windows registry.
    /// </summary>
    public sealed class RegistrySettings : ISettings, IDisposable
    {
        private readonly RegistryKey baseKey;

        public RegistrySettings(string applicationKey)
        {
            baseKey = Registry.CurrentUser.CreateSubKey(applicationKey);
        }

        public override void SetStringValue(string name, string value, string subKey = null)
        {
            RegistryKey key = baseKey;
            if (!string.IsNullOrEmpty(subKey))
            {
                key = baseKey.OpenSubKey(subKey, true);
            }
            key.SetValue(name, value);
        }

        public override string GetStringValue(string name, string subKey = null)
        {
            RegistryKey key = baseKey;
            if (!string.IsNullOrEmpty(subKey))
            {
                key = baseKey.OpenSubKey(subKey, false);
            }
            return key != null ? (string)key.GetValue(name, "") : "";
        }

        public override void SetIntValue(string name, int value, string subKey = null)
        {
            RegistryKey key = baseKey;
            if (!string.IsNullOrEmpty(subKey))
            {
                key = baseKey.OpenSubKey(subKey, true);
            }
            key.SetValue(name, value);
        }

        public override int GetIntValue(string name, int defaultValue, string subKey = null)
        {
            RegistryKey key = baseKey;
            if (!string.IsNullOrEmpty(subKey))
            {
                key = baseKey.OpenSubKey(subKey, false);
            }
            return key != null ? (int)key.GetValue(name, defaultValue) : defaultValue;
        }

        public override void SetPointValue(string name, System.Drawing.Point value, string subKey = null)
        {
            SetIntValue(name + " X", value.X);
            SetIntValue(name + " Y", value.Y);
        }

        public override System.Drawing.Point GetPointValue(string name, string subKey = null)
        {
            System.Drawing.Point point = new System.Drawing.Point
            {
                X = GetIntValue(name + " X", 0, subKey),
                Y = GetIntValue(name + " Y", 0, subKey)
            };
            return point;
        }

        public override void SetSizeValue(string name, System.Drawing.Size value, string subKey = null)
        {
            SetIntValue(name + " Height", value.Height);
            SetIntValue(name + " Width", value.Width);
        }

        public override System.Drawing.Size GetSizeValue(string name, string subKey = null)
        {
            System.Drawing.Size size = new System.Drawing.Size
            {
                Height = GetIntValue(name + " Height", 0, subKey),
                Width = GetIntValue(name + " Width", 0, subKey)
            };
            return size;
        }


        public override void SetDateTimeValue(string name, DateTime value, string subKey = null)
        {
            RegistryKey key = baseKey;
            if (!string.IsNullOrEmpty(subKey))
            {
                key = baseKey.OpenSubKey(subKey, true);
            }
            key.SetValue(name, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Too many exception types for RegistryKey.GetValue")]
        public override DateTime GetDateTimeValue(string name, string subKey = null)
        {
            RegistryKey key = baseKey;
            if (!string.IsNullOrEmpty(subKey))
            {
                key = baseKey.OpenSubKey(subKey, false);
            }
            if (key != null)
            {
                try
                {
                    string dateString = (string)key.GetValue(name);
                    return !string.IsNullOrEmpty(dateString) ? Convert.ToDateTime(dateString) : new DateTime();
                }
                catch (Exception)
                {
                    return new DateTime();
                }
            }
            else
            {
                DateTime time = new DateTime();
                return time;
            }
        }

        private T Get<T>(string name, Func<T> defaultValue = null) where T : class
        {
            RegistryKey key = baseKey;
            var value = key.GetValue(name) as T;

            if (defaultValue != null && value == null)
            {
                value = defaultValue();
                key.SetValue(name, value);
            }

            return value;
        }

        private void Set<T>(string name, T value)
        {
            RegistryKey key = baseKey;
            key.SetValue(name, value);
        }

        public override string GetProtected(string name)
        {
            var encryptedData = Get<byte[]>(name);

            if (encryptedData == null)
            {
                return null;
            }

            var entropy = GetEntropy();
            var data = ProtectedData.Unprotect(encryptedData, entropy, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(data);
        }

        public override void SetProtected(string name, string value)
        {
            var entropy = GetEntropy();
            var encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(value), entropy, DataProtectionScope.CurrentUser);
            Set(name, encryptedData);
        }

        private byte[] GetEntropy()
        {
            return Get(
                "Entropy",
                defaultValue: () =>
                {
                    var val = new byte[20];

                    using (var rng = new RNGCryptoServiceProvider())
                    {
                        rng.GetBytes(val);
                    }

                    return val;
                });
        }

        public void Dispose() => baseKey.Dispose();

    }   // RegistrySettings
}   // namespace
