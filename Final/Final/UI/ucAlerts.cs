using System;
using System.Drawing;
using System.Windows.Forms;
using Final.Engine;
using Final.Models;

namespace Final.UI
{
    public partial class ucAlerts : UserControl
    {
        private readonly StockMonitorEngine _engine;
        private DataGridView dgvActiveAlerts;

        public ucAlerts(StockMonitorEngine engine)
        {
            _engine = engine;

            InitializeLayout();

            PopulateExistingAlerts();

            // Hook into the engine event
            _engine.getAlertService().onAlertGenerated += HandleNewAlert;
            this.Disposed += ucAlerts_Disposed;
        }

        private void InitializeLayout()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.Padding = new Padding(30);

            // --- HEADER ---
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60 };
            Label lblTitle = new Label { Text = "Actionable Alerts", Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.FromArgb(33, 37, 41), AutoSize = true };
            Label lblSub = new Label { Text = "Rules are suspended upon triggering. Click 'Read Details' to view and acknowledge.", Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, Location = new Point(0, 35), AutoSize = true };
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSub);

            // --- DATA GRID ---
            dgvActiveAlerts = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersHeight = 45,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                GridColor = Color.FromArgb(233, 236, 239),
                Font = new Font("Segoe UI", 11),
                ReadOnly = true
            };

            // Setup Columns
            dgvActiveAlerts.Columns.Add("RuleId", "RuleId");
            dgvActiveAlerts.Columns["RuleId"].Visible = false; // Hidden tracking column

            dgvActiveAlerts.Columns.Add("Message", "Message");
            dgvActiveAlerts.Columns["Message"].Visible = false; // Hidden payload for the popup

            dgvActiveAlerts.Columns.Add("Time", "Trigger Time");
            dgvActiveAlerts.Columns["Time"].Width = 200;

            dgvActiveAlerts.Columns.Add("Ticker", "Ticker");

            // Add the Action Button Column
            DataGridViewButtonColumn btnAcknowledge = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Read Details",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 150
            };
            btnAcknowledge.DefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            btnAcknowledge.DefaultCellStyle.ForeColor = Color.White;
            dgvActiveAlerts.Columns.Add(btnAcknowledge);

            dgvActiveAlerts.CellContentClick += DgvActiveAlerts_CellContentClick;

            Panel pnlGridWrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 20, 0, 0) };
            pnlGridWrapper.Controls.Add(dgvActiveAlerts);

            this.Controls.Add(pnlGridWrapper);
            this.Controls.Add(pnlHeader);
        }

        private void PopulateExistingAlerts()
        {
            var allRules = _engine.getAlertService().getRules();

            foreach (var rule in allRules)
            {
                if (rule.IsSuspended)
                {
                    // Order must match column setup: RuleId, Message, Time, Ticker
                    dgvActiveAlerts.Rows.Insert(0, rule.RuleId.ToString(), rule.LastAlertMessage, rule.LastTriggerTime, rule.TargetTicker);
                }
            }
        }

        private void HandleNewAlert(AlertRule rule, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleNewAlert(rule, message)));
                return;
            }

            string timeStr = DateTime.Now.ToString("HH:mm:ss.fff");

            // Order must match column setup: RuleId, Message, Time, Ticker
            dgvActiveAlerts.Rows.Insert(0, rule.RuleId.ToString(), message, timeStr, rule.TargetTicker);
        }

        private void DgvActiveAlerts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if they clicked the button column (Index 4)
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                string rawId = dgvActiveAlerts.Rows[e.RowIndex].Cells["RuleId"].Value.ToString();
                string alertMsg = dgvActiveAlerts.Rows[e.RowIndex].Cells["Message"].Value.ToString();
                string ticker = dgvActiveAlerts.Rows[e.RowIndex].Cells["Ticker"].Value.ToString();

                if (Guid.TryParse(rawId, out Guid ruleId))
                {
                    // Show the popup with the full details FIRST
                    MessageBox.Show(alertMsg, $"Alert Triggered - {ticker}", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Once they close the MessageBox, tell the backend to wake the rule back up
                    _engine.getAlertService().acknowledgeRule(ruleId);

                    // Remove the alert from the UI
                    dgvActiveAlerts.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void ucAlerts_Disposed(object sender, EventArgs e)
        {
            if (_engine != null)
            {
                _engine.getAlertService().onAlertGenerated -= HandleNewAlert;
            }
        }
    }
}