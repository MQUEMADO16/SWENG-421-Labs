namespace Final
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TitleText = new Label();
            ToolBoxPanel = new Panel();
            DashboardButton = new Button();
            WatchlistButton = new Button();
            RulesButton = new Button();
            AlertsButton = new Button();
            SettingsButton = new Button();
            ExitButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            TotalTickersLabel = new Label();
            TickerCount = new Label();
            ActiveRules = new Label();
            ActiveRulesLabel = new Label();
            ActiveAlerts = new Label();
            ActiveAlertsLabel = new Label();
            Latency = new Label();
            LatencyLabel = new Label();
            ToolBoxPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // TitleText
            // 
            TitleText.AutoSize = true;
            TitleText.Font = new Font("Segoe UI", 18F);
            TitleText.Location = new Point(21, 24);
            TitleText.Name = "TitleText";
            TitleText.Size = new Size(193, 32);
            TitleText.TabIndex = 0;
            TitleText.Text = "Stock Dashboard";
            TitleText.Click += label1_Click;
            // 
            // ToolBoxPanel
            // 
            ToolBoxPanel.BorderStyle = BorderStyle.FixedSingle;
            ToolBoxPanel.Controls.Add(ExitButton);
            ToolBoxPanel.Controls.Add(SettingsButton);
            ToolBoxPanel.Controls.Add(AlertsButton);
            ToolBoxPanel.Controls.Add(RulesButton);
            ToolBoxPanel.Controls.Add(WatchlistButton);
            ToolBoxPanel.Controls.Add(DashboardButton);
            ToolBoxPanel.Controls.Add(TitleText);
            ToolBoxPanel.Location = new Point(12, 12);
            ToolBoxPanel.Name = "ToolBoxPanel";
            ToolBoxPanel.Size = new Size(240, 879);
            ToolBoxPanel.TabIndex = 0;
            ToolBoxPanel.Paint += panel1_Paint;
            // 
            // DashboardButton
            // 
            DashboardButton.Font = new Font("Segoe UI", 18F);
            DashboardButton.Location = new Point(43, 98);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(143, 47);
            DashboardButton.TabIndex = 1;
            DashboardButton.Text = "Dashboard";
            DashboardButton.UseVisualStyleBackColor = true;
            // 
            // WatchlistButton
            // 
            WatchlistButton.Font = new Font("Segoe UI", 18F);
            WatchlistButton.Location = new Point(43, 151);
            WatchlistButton.Name = "WatchlistButton";
            WatchlistButton.Size = new Size(143, 47);
            WatchlistButton.TabIndex = 2;
            WatchlistButton.Text = "Watchlist";
            WatchlistButton.UseVisualStyleBackColor = true;
            // 
            // RulesButton
            // 
            RulesButton.Font = new Font("Segoe UI", 18F);
            RulesButton.Location = new Point(43, 204);
            RulesButton.Name = "RulesButton";
            RulesButton.Size = new Size(143, 47);
            RulesButton.TabIndex = 3;
            RulesButton.Text = "Rules";
            RulesButton.UseVisualStyleBackColor = true;
            // 
            // AlertsButton
            // 
            AlertsButton.Font = new Font("Segoe UI", 18F);
            AlertsButton.Location = new Point(43, 257);
            AlertsButton.Name = "AlertsButton";
            AlertsButton.Size = new Size(143, 47);
            AlertsButton.TabIndex = 4;
            AlertsButton.Text = "Alerts";
            AlertsButton.UseVisualStyleBackColor = true;
            // 
            // SettingsButton
            // 
            SettingsButton.Font = new Font("Segoe UI", 18F);
            SettingsButton.Location = new Point(43, 310);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(143, 47);
            SettingsButton.TabIndex = 5;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            ExitButton.Font = new Font("Segoe UI", 18F);
            ExitButton.Location = new Point(43, 818);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(143, 47);
            ExitButton.TabIndex = 6;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel5);
            panel1.Location = new Point(275, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 160);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(ActiveRules);
            panel2.Controls.Add(ActiveRulesLabel);
            panel2.Location = new Point(645, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 160);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(ActiveAlerts);
            panel3.Controls.Add(ActiveAlertsLabel);
            panel3.Location = new Point(1020, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(350, 160);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(Latency);
            panel4.Controls.Add(LatencyLabel);
            panel4.Location = new Point(1393, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(350, 160);
            panel4.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(TickerCount);
            panel5.Controls.Add(TotalTickersLabel);
            panel5.Location = new Point(-1, -1);
            panel5.Name = "panel5";
            panel5.Size = new Size(350, 160);
            panel5.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Location = new Point(275, 191);
            panel6.Name = "panel6";
            panel6.Size = new Size(880, 485);
            panel6.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Location = new Point(1161, 191);
            panel7.Name = "panel7";
            panel7.Size = new Size(582, 402);
            panel7.TabIndex = 6;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Location = new Point(275, 682);
            panel8.Name = "panel8";
            panel8.Size = new Size(880, 209);
            panel8.TabIndex = 6;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Location = new Point(1161, 599);
            panel9.Name = "panel9";
            panel9.Size = new Size(582, 292);
            panel9.TabIndex = 7;
            // 
            // TotalTickersLabel
            // 
            TotalTickersLabel.AutoSize = true;
            TotalTickersLabel.Font = new Font("Segoe UI", 18F);
            TotalTickersLabel.Location = new Point(44, 24);
            TotalTickersLabel.Name = "TotalTickersLabel";
            TotalTickersLabel.Size = new Size(265, 32);
            TotalTickersLabel.TabIndex = 7;
            TotalTickersLabel.Text = "Total Monitored Tickers";
            TotalTickersLabel.Click += label1_Click_1;
            // 
            // TickerCount
            // 
            TickerCount.AutoSize = true;
            TickerCount.Font = new Font("Segoe UI", 18F);
            TickerCount.Location = new Point(151, 77);
            TickerCount.Name = "TickerCount";
            TickerCount.Size = new Size(40, 32);
            TickerCount.TabIndex = 8;
            TickerCount.Text = "99";
            // 
            // ActiveRules
            // 
            ActiveRules.AutoSize = true;
            ActiveRules.Font = new Font("Segoe UI", 18F);
            ActiveRules.Location = new Point(148, 77);
            ActiveRules.Name = "ActiveRules";
            ActiveRules.Size = new Size(40, 32);
            ActiveRules.TabIndex = 10;
            ActiveRules.Text = "99";
            // 
            // ActiveRulesLabel
            // 
            ActiveRulesLabel.AutoSize = true;
            ActiveRulesLabel.Font = new Font("Segoe UI", 18F);
            ActiveRulesLabel.Location = new Point(94, 24);
            ActiveRulesLabel.Name = "ActiveRulesLabel";
            ActiveRulesLabel.Size = new Size(143, 32);
            ActiveRulesLabel.TabIndex = 9;
            ActiveRulesLabel.Text = "Active Rules";
            // 
            // ActiveAlerts
            // 
            ActiveAlerts.AutoSize = true;
            ActiveAlerts.Font = new Font("Segoe UI", 18F);
            ActiveAlerts.Location = new Point(151, 77);
            ActiveAlerts.Name = "ActiveAlerts";
            ActiveAlerts.Size = new Size(40, 32);
            ActiveAlerts.TabIndex = 12;
            ActiveAlerts.Text = "99";
            // 
            // ActiveAlertsLabel
            // 
            ActiveAlertsLabel.AutoSize = true;
            ActiveAlertsLabel.Font = new Font("Segoe UI", 18F);
            ActiveAlertsLabel.Location = new Point(98, 24);
            ActiveAlertsLabel.Name = "ActiveAlertsLabel";
            ActiveAlertsLabel.Size = new Size(146, 32);
            ActiveAlertsLabel.TabIndex = 11;
            ActiveAlertsLabel.Text = "Active Alerts";
            // 
            // Latency
            // 
            Latency.AutoSize = true;
            Latency.Font = new Font("Segoe UI", 18F);
            Latency.Location = new Point(147, 77);
            Latency.Name = "Latency";
            Latency.Size = new Size(40, 32);
            Latency.TabIndex = 14;
            Latency.Text = "99";
            // 
            // LatencyLabel
            // 
            LatencyLabel.AutoSize = true;
            LatencyLabel.Font = new Font("Segoe UI", 18F);
            LatencyLabel.Location = new Point(79, 24);
            LatencyLabel.Name = "LatencyLabel";
            LatencyLabel.Size = new Size(189, 32);
            LatencyLabel.TabIndex = 13;
            LatencyLabel.Text = "Average Latency";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1755, 903);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(ToolBoxPanel);
            Name = "Form1";
            Text = "Form1";
            ToolBoxPanel.ResumeLayout(false);
            ToolBoxPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label TitleText;
        private Panel ToolBoxPanel;
        private Button SettingsButton;
        private Button AlertsButton;
        private Button RulesButton;
        private Button WatchlistButton;
        private Button DashboardButton;
        private Button ExitButton;
        private Panel panel1;
        private Panel panel5;
        private Label TotalTickersLabel;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Label TickerCount;
        private Label ActiveRules;
        private Label ActiveRulesLabel;
        private Label ActiveAlerts;
        private Label ActiveAlertsLabel;
        private Label Latency;
        private Label LatencyLabel;
    }
}
