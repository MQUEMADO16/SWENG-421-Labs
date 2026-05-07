using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Final.Engine;

namespace Final.UI
{
    public partial class MainShell : Form
    {
        private readonly StockMonitorEngine _engine;

        // UI Components
        private Panel pnlSidebar;
        private Panel pnlMainContent;
        private Label lblLogo;

        public MainShell(StockMonitorEngine engine)
        {
            InitializeComponent();
            _engine = engine;

            ConfigureWindow();
            InitializeShellLayout();

            this.FormClosing += MainShell_FormClosing;
        }

        private void ConfigureWindow()
        {
            this.Text = "Stock Price Monitor";
            this.ClientSize = new Size(1280, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(248, 249, 250); // Light Theme background
        }

        private void InitializeShellLayout()
        {
            // idebar Panel
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 240,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Main Content Area
            pnlMainContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(20)
            };

            // Logo Placeholder
            lblLogo = new Label
            {
                Text = "StockMonitor",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Add Sidebar Buttons
            CreateNavButton("Dashboard", 100, (s, e) => Debug.WriteLine("Navigating to Dashboard..."));
            CreateNavButton("Watchlist", 150, (s, e) => Debug.WriteLine("Navigating to Watchlist..."));
            CreateNavButton("Alerts", 200, (s, e) => Debug.WriteLine("Navigating to Alerts..."));
            CreateNavButton("Rules", 250, (s, e) => Debug.WriteLine("Navigating to Rules..."));

            // Assembly
            pnlSidebar.Controls.Add(lblLogo);
            this.Controls.Add(pnlMainContent);
            this.Controls.Add(pnlSidebar);
        }

        private void CreateNavButton(string text, int top, EventHandler onClick)
        {
            Button btn = new Button
            {
                Text = "  " + text,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Size = new Size(200, 45),
                Location = new Point(20, top),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(73, 80, 87),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(233, 236, 239);
            btn.Click += onClick;

            pnlSidebar.Controls.Add(btn);
        }

        // The SPA Engine: Swaps UserControls into the main content panel
        public void NavigateTo(UserControl view)
        {
            pnlMainContent.Controls.Clear();
            view.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(view);
        }

        private async void MainShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _engine.stopSystem();
        }
    }
}