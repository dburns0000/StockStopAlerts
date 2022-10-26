# StockStopAlerts
C# program to manage a stock portfolio and automatically alert when a stop is hit

<p>It runs as a taskbar app. The main logic is in ProcessIcon.cs.
<p>For accounts that don't have a symbol (401K, etc.) prefix the symbol with an underscore, eg: "_401K".</p>
<p>For crypto-currencies, prefix the symbol with a caret, eg: "^BTC". See digital_currency_list.csv for a list of symbols.</p>
<p>The Alpha Vantage API key is required as a command-line argument</p>
<p>Get your free API key at https://www.alphavantage.co</p>

## SAST Tools
[PVS-Studio](https://pvs-studio.com/en/pvs-studio/?utm_source=github&utm_medium=organic&utm_campaign=open_source) - static analyzer for C, C++, C#, and Java code.
