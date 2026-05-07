using Final.Models;
using YahooFinanceApi;

namespace Final.Providers
{
    public class YahooHistoryService
    {
        public async Task<List<TradeDataPoint>> getHistoricalData(string ticker, DateTime startDate, DateTime endDate)
        {
            var historicalPoints = new List<TradeDataPoint>();

            try
            {
                var yahooData = await Yahoo.GetHistoricalAsync(ticker, startDate, endDate, Period.Daily);

                foreach (var candle in yahooData)
                {
                    // Convert Yahoo's standard DateTime to a Unix Timestamp
                    long unixTimestamp = ((DateTimeOffset)candle.DateTime).ToUnixTimeMilliseconds();

                    TradeDataPoint point = new TradeDataPoint(ticker)
                    {
                        Price = (double)candle.Close,
                        Volume = candle.Volume,
                        Timestamp = unixTimestamp
                    };

                    historicalPoints.Add(point);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch historical data for {ticker}: {ex.Message}");
            }

            return historicalPoints;
        }
    }
}