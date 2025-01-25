using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var service = new StockApiService();
        string[] companies = { "MSFT", "AAPL", "NFLX", "META", "AMZN" };

        Console.WriteLine("Welcome to the Historical Stock Dashboard!");
        Console.WriteLine("Fetching stock data...\n");

        foreach (var company in companies)
        {
            try
            {
                // Fetch stock data
                var data = await service.GetDailyStockPricesAsync(company);

                //raw response
                Console.WriteLine($"Raw API Response for {company}: {data}");

                // Handle empty or invalid responses
                if (string.IsNullOrWhiteSpace(data) || data.Contains("Note") || data.Contains("Error Message"))
                {
                    Console.WriteLine($"Error in API response for {company}: {data}");
                    continue;
                }

                // Deserialize stock data
                var stockData = JsonConvert.DeserializeObject<StockData>(data);
                if (stockData == null || stockData.TimeSeriesDaily == null)
                {
                    Console.WriteLine($"Error: Unable to parse 'Time Series (Daily)' data for {company}. The response might be incomplete or invalid.");
                    continue;
                }

                // Display latest stock data
                var latestDate = stockData.TimeSeriesDaily.Keys.First();
                var latestStock = stockData.TimeSeriesDaily[latestDate];

                Console.WriteLine($"--- {company} ({latestDate}) ---");
                Console.WriteLine($"Open: {latestStock.Open}");
                Console.WriteLine($"High: {latestStock.High}");
                Console.WriteLine($"Low: {latestStock.Low}");
                Console.WriteLine($"Close: {latestStock.Close}");
                Console.WriteLine($"Volume: {latestStock.Volume}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data for {company}: {ex.Message}");
            }

            //Wait 15 seconds between calls
            await Task.Delay(15000);
        }

        Console.WriteLine("Dashboard update complete!");
    }
}
