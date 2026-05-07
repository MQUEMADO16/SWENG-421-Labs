using Final.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Final.UI
{
    public partial class ucWatchlist : UserControl
    {
        private readonly StockMonitorEngine _engine;
        private DataGridView dgvWatchlist;
        private TextBox txtNewTicker;
        private Button btnAddTicker;
        private System.Windows.Forms.Timer uiRefreshTimer;

        public ucWatchlist(StockMonitorEngine engine)
        {
            _engine = engine;
            InitializeLayout();
            PopulateGrid();
            SetupSamplingTimer();

            this.Disposed += ucWatchlist_Disposed;
        }

        private void InitializeLayout()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.Padding = new Padding(30);

            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 80 };

            Label lblTitle = new Label { Text = "My Watchlist", Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.FromArgb(33, 37, 41), AutoSize = true, Location = new Point(0, 0) };

            txtNewTicker = new TextBox
            {
                Font = new Font("Segoe UI", 12),
                Location = new Point(0, 45),
                Width = 200,
                ForeColor = Color.Black
            };

            btnAddTicker = new Button
            {
                Text = "Add to Stream",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(210, 44),
                Size = new Size(120, 29),
                Cursor = Cursors.Hand
            };
            btnAddTicker.FlatAppearance.BorderSize = 0;
            btnAddTicker.Click += BtnAddTicker_Click;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(txtNewTicker);
            pnlHeader.Controls.Add(btnAddTicker);

            dgvWatchlist = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                GridColor = Color.FromArgb(233, 236, 239),
                Font = new Font("Segoe UI", 11),
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 45
            };

            dgvWatchlist.Columns.Add("Symbol", "Symbol");
            dgvWatchlist.Columns.Add("LastPrice", "Last Price");
            dgvWatchlist.Columns.Add("Volume", "Volume");
            dgvWatchlist.Columns.Add("Status", "Connection Status");

            Panel pnlGridWrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 20, 0, 0) };
            pnlGridWrapper.Controls.Add(dgvWatchlist);

            this.Controls.Add(pnlGridWrapper);
            this.Controls.Add(pnlHeader);
        }

        private void PopulateGrid()
        {
            dgvWatchlist.Rows.Clear();
            List<string> activeStreams = _engine.getActiveTickers();

            foreach (var ticker in activeStreams)
            {
                var existingData = _engine.getAlertService().getTargetCache().getLiveDataPoint(ticker);

                string initialPrice = existingData != null ? $"${existingData.Price:F2}" : "";
                string initialVol = existingData != null ? $"{existingData.Volume:F4}" : "";

                dgvWatchlist.Rows.Add(ticker, initialPrice, initialVol, "Active");
            }
        }

        private async void BtnAddTicker_Click(object sender, EventArgs e)
        {
            string newTicker = txtNewTicker.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(newTicker)) return;

            await _engine.SubscribeToTicker(newTicker);

            dgvWatchlist.Rows.Add(newTicker, "", "", "Active");

            txtNewTicker.Text = "";
        }

        private void SetupSamplingTimer()
        {
            uiRefreshTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            uiRefreshTimer.Tick += (s, e) => {
                foreach (DataGridViewRow row in dgvWatchlist.Rows)
                {
                    string ticker = row.Cells[0].Value.ToString();
                    var latestData = _engine.getAlertService().getTargetCache().getLiveDataPoint(ticker);

                    if (latestData != null)
                    {
                        row.Cells[1].Value = $"${latestData.Price:F2}";
                        row.Cells[2].Value = $"{latestData.Volume:F4}";
                    }
                }
            };
            uiRefreshTimer.Start();
        }

        private void ucWatchlist_Disposed(object sender, EventArgs e)
        {
            Debug.WriteLine("[SPA] Cleaning up Watchlist resources...");

            if (uiRefreshTimer != null)
            {
                uiRefreshTimer.Stop();
                uiRefreshTimer.Dispose();
            }
        }
    }
}