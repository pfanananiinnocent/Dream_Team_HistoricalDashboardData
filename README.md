Clone the repository:
git clone  https://github.com/pfanananiinnocent/Dream_Team_HistoricalDashboardData.git

Install dependencies:
- Newtonsoft.Json
- System.Net.Http.Json

Encountered this error while fetching API data "Error fetching data for FB: Object reference not set to an instance of an object."
- this was because FB changed to META when Facebook rebranded to Meta in October 2021. so FB does not exist on the API data anymore
- I had to replace FB with META in companies array:
string[] companies = { "MSFT", "AAPL", "NFLX", "META", "AMZN" };
