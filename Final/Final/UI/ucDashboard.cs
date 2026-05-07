using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading.Tasks;
using Final.Engine;
using Final.Models;

namespace Final.UI
{
    public partial class ucDashboard : UserControl
    {
        private readonly StockMonitorEngine _engine;
        private Chart priceChart;
        private System.Windows.Forms.Timer uiRefreshTimer;

        // Multiplexing Data
        private List<string> _monitoredTickers = new List<string> { "BINANCE:BTCUSDT", "AAPL", "MSFT", "NVDA" };
        private string _activeChartTicker = "BINANCE:BTCUSDT";

        // Real Data UI References
        private Label lblMonitoredCount;
        private Label lblActiveRulesCount;
        private Label lblAlertsCount;
        private Label lblLatencyCount;

        private ListBox lstLiveAlerts;
        private DataGridView dgvRules;
        private int _alertsFiredToday = 0;

        public ucDashboard(StockMonitorEngine engine)
        {
            _engine = engine;

            SetupChart();
            SetupLiveAlertsFeed();
            SetupRulesGrid();

            InitializeLayout();
            SetupSamplingTimer();

            // Hook into the background engine's Alert Event
            _engine.getAlertService().OnAlertGenerated += HandleNewAlert;

            this.Load += ucDashboard_Load;
            this.Disposed += ucDashboard_Disposed;
        }

        private async void ucDashboard_Load(object sender, EventArgs e)
        {
            Debug.WriteLine($"[DASHBOARD] Initializing Multiplexed Feed...");

            // Seed with Historical Data for the chart focus
            await LoadHistoricalData();

            // Boot the firehose with the full list
            await _engine.startLiveFeed(_monitoredTickers);

            uiRefreshTimer.Start();
        }

        private void InitializeLayout()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.Padding = new Padding(20);

            // --- HEADER ---
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 50 };
            Label lblTitle = new Label { Text = "Dashboard", Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.FromArgb(33, 37, 41), AutoSize = true, Location = new Point(0, 0) };

            // EXPLICIT FINNHUB LABEL
            Label lblStatus = new Label { Text = "Data Source: Finnhub WebSocket • Connected", Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = Color.FromArgb(40, 167, 69), AutoSize = true, Location = new Point(this.Width - 300, 15), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblStatus);

            // --- STAT CARDS ---
            TableLayoutPanel pnlStats = new TableLayoutPanel { Dock = DockStyle.Top, Height = 100, ColumnCount = 4, RowCount = 1, Padding = new Padding(0, 0, 0, 15) };
            for (int i = 0; i < 4; i++) pnlStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            pnlStats.Controls.Add(CreateStatCard("Monitored Stocks", _monitoredTickers.Count.ToString(), Color.FromArgb(0, 123, 255), out lblMonitoredCount), 0, 0);
            pnlStats.Controls.Add(CreateStatCard("Active Rules", _engine.getAlertService().getRuleCount().ToString(), Color.FromArgb(102, 16, 242), out lblActiveRulesCount), 1, 0);
            pnlStats.Controls.Add(CreateStatCard("Alerts (Today)", _alertsFiredToday.ToString(), Color.FromArgb(220, 53, 69), out lblAlertsCount), 2, 0);
            pnlStats.Controls.Add(CreateStatCard("Avg. Latency", "-- ms", Color.FromArgb(40, 167, 69), out lblLatencyCount), 3, 0);

            // --- MAIN GRID ---
            TableLayoutPanel grid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));

            Panel pnlChart = CreateSection("", priceChart);
            Panel pnlAlerts = CreateSection("Live Alerts", lstLiveAlerts);
            Panel pnlRules = CreateSection("My Rules", dgvRules);
            Panel pnlWatchlist = CreateSection("Watchlist", new Label { Text = "Watchlist UI TBD", ForeColor = Color.Gray, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter });

            grid.Controls.Add(pnlChart, 0, 0);
            grid.Controls.Add(pnlAlerts, 1, 0);
            grid.Controls.Add(pnlRules, 0, 1);
            grid.Controls.Add(pnlWatchlist, 1, 1);

            this.Controls.Add(grid);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlHeader);
        }

        private void SetupLiveAlertsFeed()
        {
            lstLiveAlerts = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33, 37, 41),
                BorderStyle = BorderStyle.None
            };
            lstLiveAlerts.Items.Add("System ready. Listening for alerts...");
        }

        private void SetupRulesGrid()
        {
            dgvRules = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                GridColor = Color.FromArgb(233, 236, 239)
            };

            dgvRules.Columns.Add("Symbol", "Symbol");
            dgvRules.Columns.Add("Condition", "Condition");
            dgvRules.Columns.Add("Threshold", "Threshold");
            dgvRules.Columns.Add("Direction", "Direction");
            dgvRules.Columns.Add("Status", "Status");
        }

        // --- BACKGROUND EVENT LISTENERS ---

        private void HandleNewAlert(string alertMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleNewAlert(alertMessage)));
                return;
            }

            lstLiveAlerts.Items.Insert(0, alertMessage);
            _alertsFiredToday++;
            lblAlertsCount.Text = _alertsFiredToday.ToString();
        }

        private void SetupSamplingTimer()
        {
            uiRefreshTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            uiRefreshTimer.Tick += (s, e) => {
                var latest = _engine.getAlertService().getTargetCache().getLiveDataPoint(_activeChartTicker);
                if (latest != null)
                {
                    var series = priceChart.Series["Price"];
                    series.Points.AddXY(DateTime.Now, latest.Price);
                    if (series.Points.Count > 50) series.Points.RemoveAt(0);
                }

                lblMonitoredCount.Text = _engine.getActiveStreamCount().ToString();
                lblActiveRulesCount.Text = _engine.getAlertService().getRuleCount().ToString();
            };
        }

        // --- STYLING HELPERS ---
        private Panel CreateStatCard(string title, string value, Color accentColor, out Label valLabel)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 15, 0), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };

            Label lblT = new Label { Text = title, Font = new Font("Segoe UI", 10), ForeColor = Color.FromArgb(73, 80, 87), Location = new Point(15, 10), AutoSize = true };
            Label lblV = new Label { Text = value, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.Black, Location = new Point(15, 35), AutoSize = true };

            valLabel = lblV;
            Panel accent = new Panel { BackColor = accentColor, Height = 4, Dock = DockStyle.Bottom };

            card.Controls.Add(lblT);
            card.Controls.Add(lblV);
            card.Controls.Add(accent);
            return card;
        }

        private Panel CreateSection(string titleText, Control content)
        {
            Panel pnl = new Panel { Dock = DockStyle.Fill, Margin = new Padding(10), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Padding = new Padding(15) };

            content.Dock = DockStyle.Fill;
            pnl.Controls.Add(content);

            if (!string.IsNullOrEmpty(titleText))
            {
                Label lbl = new Label { Text = titleText, Font = new Font("Segoe UI", 11, FontStyle.Regular), ForeColor = Color.FromArgb(33, 37, 41), Dock = DockStyle.Top, Height = 30 };
                pnl.Controls.Add(lbl);
            }

            return pnl;
        }

        private void SetupChart()
        {
            priceChart = new Chart { BackColor = Color.White };

            // Layout engine crash prevention
            priceChart.MinimumSize = new Size(10, 10);

            priceChart.Titles.Add(new Title { Name = "MainTitle", Text = $"{_activeChartTicker} - Live Feed", Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.FromArgb(33, 37, 41), Alignment = ContentAlignment.TopLeft });
            ChartArea area = new ChartArea("MainArea") { BackColor = Color.White };
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            area.AxisY.IsStartedFromZero = false;
            priceChart.ChartAreas.Add(area);
            Series series = new Series("Price") { ChartType = SeriesChartType.Spline, XValueType = ChartValueType.DateTime, Color = Color.FromArgb(40, 167, 69), BorderWidth = 2 };
            priceChart.Series.Add(series);
        }

        private async Task LoadHistoricalData()
        {
            try
            {
                var history = await _engine.fetchInitialChartData(_activeChartTicker);
                var series = priceChart.Series["Price"];
                foreach (var p in history)
                {
                    DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).DateTime.ToLocalTime();
                    series.Points.AddXY(dt, p.Price);
                }
            }
            catch (Exception ex) { Debug.WriteLine("History Error: " + ex.Message); }
        }

        private void ucDashboard_Disposed(object sender, EventArgs e)
        {
            Debug.WriteLine("[SPA] Cleaning up Dashboard resources...");

            if (uiRefreshTimer != null)
            {
                uiRefreshTimer.Stop();
                uiRefreshTimer.Dispose();
            }

            if (_engine != null)
            {
                _engine.getAlertService().OnAlertGenerated -= HandleNewAlert;
            }
        }
    }
}