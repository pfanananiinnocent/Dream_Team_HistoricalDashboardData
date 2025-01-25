using System;
using System.Net.Http;
using System.Threading.Tasks;

public class StockApiService
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private const string BaseUrl = "https://alpha-vantage.p.rapidapi.com/query";
    private const string ApiKey = "589a6d6cedmsh4c0cf365627c871p1156aajsnbebfb7fbb3e5";

    static StockApiService()
    {
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "alpha-vantage.p.rapidapi.com");
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", ApiKey);
    }

    public async Task<string> GetDailyStockPricesAsync(string symbol)
    {
        var url = $"{BaseUrl}?function=TIME_SERIES_DAILY&symbol={symbol}&outputsize=compact&datatype=json";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        throw new Exception($"Error fetching data: {response.StatusCode}");
    }
}
