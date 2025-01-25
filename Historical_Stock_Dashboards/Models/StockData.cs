using System.Collections.Generic;
using Newtonsoft.Json;

public class StockData
{
    [JsonProperty("Meta Data")]
    public MetaData MetaData { get; set; }

    [JsonProperty("Time Series (Daily)")]
    public Dictionary<string, DailyStock> TimeSeriesDaily { get; set; }
}

public class MetaData
{
    [JsonProperty("2. Symbol")]
    public string Symbol { get; set; }

    [JsonProperty("3. Last Refreshed")]
    public string LastRefreshed { get; set; }
}

public class DailyStock
{
    [JsonProperty("1. open")]
    public string Open { get; set; }

    [JsonProperty("2. high")]
    public string High { get; set; }

    [JsonProperty("3. low")]
    public string Low { get; set; }

    [JsonProperty("4. close")]
    public string Close { get; set; }

    [JsonProperty("5. volume")]
    public string Volume { get; set; }
}
