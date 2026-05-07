using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using Final.Engine;

namespace Final.UI
{
    public partial class MainShell : Form
    {
        private readonly StockMonitorEngine _engine;

        private Panel pnlSidebar;
        private Panel pnlMainContent;
        private Label lblLogo;
        private ucDashboard _cachedDashboard;
        private Control _currentView;

        public MainShell(StockMonitorEngine engine)
        {
            InitializeComponent();
            _engine = engine;

            ConfigureWindow();
            InitializeShellLayout();

            this.Load += MainShell_Load;
            this.FormClosing += MainShell_FormClosing;
        }

        private void ConfigureWindow()
        {
            this.Text = "StockMonitor Dashboard";
            this.ClientSize = new Size(1280, 800);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(248, 249, 250);
        }

        private void InitializeShellLayout()
        {
            pnlMainContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(30)
            };

            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            lblLogo = new Label
            {
                Text = "StockMonitor",
                Font = new Font("Segoe UI", 18, FontStyle.Regular),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(25, 25),
                AutoSize = true
            };
            pnlSidebar.Controls.Add(lblLogo);

            CreateNavButton("Dashboard", 100, (s, e) => NavigateTo(_cachedDashboard));
            CreateNavButton("Watchlist", 155, (s, e) => NavigateTo(new ucWatchlist(_engine)));
            CreateNavButton("Alerts", 210, (s, e) => NavigateTo(new ucAlerts(_engine)));
            CreateNavButton("Rules", 265, (s, e) => NavigateTo(new ucRules(_engine)));

            pnlSidebar.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(233, 236, 239), 1))
                {
                    e.Graphics.DrawLine(p, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
                }
            };

            this.Controls.Add(pnlMainContent);
            this.Controls.Add(pnlSidebar);
        }

        private void CreateNavButton(string text, int top, EventHandler onClick)
        {
            Button btn = new Button
            {
                Text = "      " + text,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(220, 50),
                Location = new Point(20, top),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(73, 80, 87),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 243, 245);

            btn.Click += onClick;
            pnlSidebar.Controls.Add(btn);
        }

        private void MainShell_Load(object sender, EventArgs e)
        {
            _cachedDashboard = new ucDashboard(_engine);
            NavigateTo(_cachedDashboard);
        }

        private void NavigateTo(Control newView)
        {
            if (newView == null) return;

            if (_currentView != null)
            {
                pnlMainContent.Controls.Remove(_currentView);

                if (_currentView != _cachedDashboard)
                {
                    _currentView.Dispose();
                }
            }

            newView.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(newView);
            _currentView = newView;
        }

        private async void MainShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("Shutting down system...");
            await _engine.stopSystem();
        }
    }
}