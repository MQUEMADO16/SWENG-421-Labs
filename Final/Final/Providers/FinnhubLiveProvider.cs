using Final.Models;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Final.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Final.Providers
{
    public class FinnhubLiveProvider : ILiveStockProvider
    {
        private readonly string _apiKey = "d7tn2f9r01qlbd3kp3d0d7tn2f9r01qlbd3kp3dg";
        private ClientWebSocket _webSocket;
        private CancellationTokenSource _cancellationTokenSource;

        public MarketDataCache DataTarget { get; set; }

        public async Task connect()
        {
            _webSocket = new ClientWebSocket();
            _cancellationTokenSource = new CancellationTokenSource();

            Uri serverUri = new Uri($"wss://ws.finnhub.io?token={_apiKey}");

            try
            {
                await _webSocket.ConnectAsync(serverUri, CancellationToken.None);

                _ = Task.Run(() => ListenForData(_cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
            }
        }

        public async Task disconnect()
        {
            if (_webSocket == null) return;

            try
            {
                _cancellationTokenSource?.Cancel();

                if (_webSocket.State == WebSocketState.Open ||
                    _webSocket.State == WebSocketState.CloseReceived ||
                    _webSocket.State == WebSocketState.CloseSent)
                {
                    // Use a short timeout or CancellationToken.None here to ensure 
                    // the close handshake finishes even if the main token is canceled.
                    await _webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebSocket cleanup info: {ex.Message}");
            }
            finally
            {
                _webSocket.Dispose();
                _webSocket = null;
                _cancellationTokenSource?.Dispose();
            }
        }

        public async Task subscribe(string ticker)
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                string payload = $"{{\"type\":\"subscribe\",\"symbol\":\"{ticker}\"}}";
                byte[] bytes = Encoding.UTF8.GetBytes(payload);

                await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private async Task ListenForData(CancellationToken cancellationToken)
        {
            var buffer = new byte[1024 * 4];

            while (_webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await disconnect();
                    break;
                }

                string jsonMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                ProcessIncomingData(jsonMessage);
            }
        }

        private void ProcessIncomingData(string json)
        {
            try
            {
                // Finnhub sends pings and status updates over the socket.
                // We drop them immediately to avoid wasting time on non-trade events.
                if (!json.Contains("\"type\":\"trade\"")) return;

                var tradeEvent = JsonSerializer.Deserialize<FinnhubTradeMessage>(json);

                if (tradeEvent?.Data != null)
                {
                    // Finnhub batches trades into a single message array during high-volume periods.
                    foreach (var trade in tradeEvent.Data)
                    {
                        TradeDataPoint newPoint = new TradeDataPoint(trade.Symbol)
                        {
                            Price = trade.Price,
                            Volume = trade.Volume,
                            Timestamp = trade.Timestamp
                        };

                        DataTarget?.updateLiveDataPoint(newPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing trade: {ex.Message}");
            }
        }
    }

    public class FinnhubTradeMessage
    {
        [JsonPropertyName("data")]
        public FinnhubTrade[] Data { get; set; }
    }

    public class FinnhubTrade
    {
        [JsonPropertyName("p")]
        public double Price { get; set; }

        [JsonPropertyName("s")]
        public string Symbol { get; set; }

        [JsonPropertyName("t")]
        public long Timestamp { get; set; }

        [JsonPropertyName("v")]
        public double Volume { get; set; }
    }
}