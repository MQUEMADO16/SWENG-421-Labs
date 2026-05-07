using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Final.Engine;
using Final.Models;
using Final.Alerts.Filters;

namespace Final.UI
{
    public partial class ucRules : UserControl
    {
        private readonly StockMonitorEngine _engine;
        private DataGridView dgvRules;
        private ComboBox cmbTickers;
        private ComboBox cmbFilters;
        private TextBox txtHighPrice;
        private TextBox txtLowPrice;
        private CheckBox chkTimestamp;
        private CheckBox chkPercent;
        private Button btnCreateRule;

        public ucRules(StockMonitorEngine engine)
        {
            _engine = engine;
            InitializeLayout();
            PopulateTickerDropdown();
            RefreshRulesGrid();
        }

        private void InitializeLayout()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.Padding = new Padding(30);

            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60 };
            Label lblTitle = new Label { Text = "Alert Rules Management", Font = new Font("Segoe UI", 20), ForeColor = Color.FromArgb(33, 37, 41), AutoSize = true };
            pnlHeader.Controls.Add(lblTitle);

            TableLayoutPanel mainGrid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            mainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350));
            mainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            Panel pnlForm = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(20), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0, 0, 20, 0) };

            Label lblInstr = new Label { Text = "Configure New Rule", Font = new Font("Segoe UI", 12), Dock = DockStyle.Top, Height = 40 };

            Label lblT = new Label { Text = "Target Ticker:", Dock = DockStyle.Top, Height = 25, Margin = new Padding(0, 10, 0, 0) };
            cmbTickers = new ComboBox { Dock = DockStyle.Top, Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblH = new Label { Text = "High Threshold ($):", Dock = DockStyle.Top, Height = 25, Margin = new Padding(0, 15, 0, 0) };
            txtHighPrice = new TextBox { Dock = DockStyle.Top, Font = new Font("Segoe UI", 10) };

            Label lblL = new Label { Text = "Low Threshold ($):", Dock = DockStyle.Top, Height = 25, Margin = new Padding(0, 10, 0, 0) };
            txtLowPrice = new TextBox { Dock = DockStyle.Top, Font = new Font("Segoe UI", 10) };

            Label lblF = new Label { Text = "Filter Strategy:", Dock = DockStyle.Top, Height = 25, Margin = new Padding(0, 15, 0, 0) };
            cmbFilters = new ComboBox { Dock = DockStyle.Top, Font = new Font("Segoe UI", 10), DropDownStyle = ComboBoxStyle.DropDownList };

            cmbFilters.Items.Add("Price Filter");
            cmbFilters.Items.Add("Price Evaluation Filter");
            cmbFilters.Items.Add("Percent Change Filter");
            cmbFilters.Items.Add("Market Cap Filter");
            cmbFilters.Items.Add("Volume Filter");
            cmbFilters.SelectedIndex = 0;

            Label lblD = new Label { Text = "Alert Formatting:", Dock = DockStyle.Top, Height = 25, Margin = new Padding(0, 15, 0, 0) };
            chkTimestamp = new CheckBox { Text = "Include Timestamp", Dock = DockStyle.Top, Checked = true };
            chkPercent = new CheckBox { Text = "Include Percent Change", Dock = DockStyle.Top };

            btnCreateRule = new Button
            {
                Text = "Add Rule",
                Dock = DockStyle.Bottom,
                Height = 45,
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnCreateRule.FlatAppearance.BorderSize = 0;
            btnCreateRule.Click += BtnCreateRule_Click;

            pnlForm.Controls.Add(btnCreateRule);
            pnlForm.Controls.Add(chkPercent);
            pnlForm.Controls.Add(chkTimestamp);
            pnlForm.Controls.Add(lblD);
            pnlForm.Controls.Add(cmbFilters);
            pnlForm.Controls.Add(lblF);
            pnlForm.Controls.Add(txtLowPrice);
            pnlForm.Controls.Add(lblL);
            pnlForm.Controls.Add(txtHighPrice);
            pnlForm.Controls.Add(lblH);
            pnlForm.Controls.Add(cmbTickers);
            pnlForm.Controls.Add(lblT);
            pnlForm.Controls.Add(lblInstr);

            dgvRules = new DataGridView
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
                Font = new Font("Segoe UI", 10)
            };

            dgvRules.Columns.Add("Ticker", "Target Ticker");
            dgvRules.Columns.Add("Low", "Low Limit");
            dgvRules.Columns.Add("High", "High Limit");
            dgvRules.Columns.Add("Filter", "Active Filter");
            dgvRules.Columns.Add("Decorators", "Active Decorators");

            mainGrid.Controls.Add(pnlForm, 0, 0);
            mainGrid.Controls.Add(dgvRules, 1, 0);

            this.Controls.Add(mainGrid);
            this.Controls.Add(pnlHeader);
        }

        private void PopulateTickerDropdown()
        {
            cmbTickers.Items.Clear();
            List<string> activeTickers = _engine.getActiveTickers();

            foreach (var ticker in activeTickers)
            {
                cmbTickers.Items.Add(ticker);
            }

            if (cmbTickers.Items.Count > 0)
            {
                cmbTickers.SelectedIndex = 0;
            }
        }

        private void RefreshRulesGrid()
        {
            dgvRules.Rows.Clear();
            List<AlertRule> activeRules = _engine.getAlertService().getRules();

            foreach (var rule in activeRules)
            {
                List<string> activeDecors = new List<string>();
                if (rule.IncludeTimestamp) activeDecors.Add("Time");
                if (rule.IncludePercentChange) activeDecors.Add("Percent");

                string decorString = activeDecors.Count > 0 ? string.Join(", ", activeDecors) : "None";
                string filterName = rule.ActiveFilter.GetType().Name;

                dgvRules.Rows.Add(rule.TargetTicker, $"${rule.LowThreshold:F2}", $"${rule.HighThreshold:F2}", filterName, decorString);
            }
        }

        private void BtnCreateRule_Click(object sender, EventArgs e)
        {
            if (cmbTickers.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid ticker from the active streams.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtHighPrice.Text, out double high) || !double.TryParse(txtLowPrice.Text, out double low))
            {
                MessageBox.Show("Please enter valid numeric values for the thresholds.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IFilter selectedFilter = null;
            string filterChoice = cmbFilters.SelectedItem.ToString();

            switch (filterChoice)
            {
                case "Price Filter":
                    selectedFilter = new PriceFilter();
                    break;
                case "Price Evaluation Filter":
                    selectedFilter = new PriceEvaluationFilter();
                    break;
                case "Percent Change Filter":
                    selectedFilter = new PercentChangeFilter();
                    break;
                case "Market Cap Filter":
                    selectedFilter = new MarketCapFilter();
                    break;
                case "Volume Filter":
                    selectedFilter = new VolumeFilter();
                    break;
            }

            AlertRule newRule = new AlertRule(cmbTickers.SelectedItem.ToString(), low, high, selectedFilter)
            {
                IncludeTimestamp = chkTimestamp.Checked,
                IncludePercentChange = chkPercent.Checked
            };

            _engine.getAlertService().addRule(newRule);

            txtHighPrice.Clear();
            txtLowPrice.Clear();
            RefreshRulesGrid();
        }
    }
}