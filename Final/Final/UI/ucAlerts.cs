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
            populateExistingAlerts();

            // Hook into the event
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
            Label lblTitle = new Label { Text = "Actionable Alerts", Font = new Font("Segoe UI", 20), ForeColor = Color.FromArgb(33, 37, 41), AutoSize = true };
            Label lblSub = new Label { Text = "Rules are suspended upon triggering until acknowledged.", Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, Location = new Point(0, 35), AutoSize = true };
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

            dgvActiveAlerts.Columns.Add("Time", "Trigger Time");
            dgvActiveAlerts.Columns["Time"].Width = 150;

            dgvActiveAlerts.Columns.Add("Ticker", "Ticker");
            dgvActiveAlerts.Columns["Ticker"].Width = 120;

            dgvActiveAlerts.Columns.Add("Message", "Alert Details");

            // Add the Action Button Column
            DataGridViewButtonColumn btnAcknowledge = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Acknowledge",
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

        private void HandleNewAlert(AlertRule rule, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleNewAlert(rule, message)));
                return;
            }

            // Add the newly triggered alert to the grid. 
            // Because the backend suspended the rule, this row will NOT duplicate.
            string timeStr = DateTime.Now.ToString("HH:mm:ss.fff");
            dgvActiveAlerts.Rows.Insert(0, rule.RuleId.ToString(), timeStr, rule.TargetTicker, message);
        }

        private void DgvActiveAlerts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                // Grab the hidden Rule ID from the row
                string rawId = dgvActiveAlerts.Rows[e.RowIndex].Cells["RuleId"].Value.ToString();

                if (Guid.TryParse(rawId, out Guid ruleId))
                {
                    // Tell the backend to wake the rule back up
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

        private void populateExistingAlerts()
        {
            var allRules = _engine.getAlertService().getRules();

            foreach (var rule in allRules)
            {
                if (rule.IsSuspended)
                {
                    dgvActiveAlerts.Rows.Insert(0, rule.RuleId.ToString(), rule.LastTriggerTime, rule.TargetTicker, rule.LastAlertMessage);
                }
            }
        }
    }
}