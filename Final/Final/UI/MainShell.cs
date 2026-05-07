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

        // UI Layout Components
        private Panel pnlSidebar;
        private Panel pnlMainContent;
        private Label lblLogo;

        public MainShell(StockMonitorEngine engine)
        {
            InitializeComponent();
            _engine = engine;

            ConfigureWindow();

            InitializeShellLayout();

            this.Load += (s, e) => NavigateTo(new ucDashboard(_engine));

            // 4. Teardown logic
            this.FormClosing += MainShell_FormClosing;
        }

        private void ConfigureWindow()
        {
            this.Text = "StockMonitor Dashboard";

            // Set the internal canvas size first
            this.ClientSize = new Size(1280, 800);

            // Lock the border so it cannot be resized by dragging the edges
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 3. Disable the Maximize button
            this.MaximizeBox = false;

            // Force the min and max size to match just to be safe
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(248, 249, 250);
        }

        private void InitializeShellLayout()
        {
            // The Content Canvas
            pnlMainContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(30)
            };

            // Sticky Sidebar
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Logo / Branding
            lblLogo = new Label
            {
                Text = "StockMonitor",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(25, 25),
                AutoSize = true
            };
            pnlSidebar.Controls.Add(lblLogo);

            // Navigation Buttons
            CreateNavButton("Dashboard", 100, (s, e) => NavigateTo(new ucDashboard(_engine)));
            CreateNavButton("Watchlist", 155, (s, e) => NavigateTo(new ucWatchlist(_engine)));
            CreateNavButton("Alerts", 210, (s, e) => NavigateTo(new ucAlerts(_engine)));
            CreateNavButton("Rules", 265, (s, e) => NavigateTo(new ucRules(_engine)));

            // Sidebar Border Decoration
            // Adds a subtle 1px gray line to the right to separate sidebar from content
            pnlSidebar.Paint += (s, e) => {
                using (Pen p = new Pen(Color.FromArgb(233, 236, 239), 1))
                {
                    e.Graphics.DrawLine(p, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
                }
            };

            // ASSEMBLY
            // Order matters for Z-index. Add the sidebar last so it sits on top
            this.Controls.Add(pnlMainContent);
            this.Controls.Add(pnlSidebar);
        }

        private void CreateNavButton(string text, int top, EventHandler onClick)
        {
            Button btn = new Button
            {
                Text = "      " + text, // Space for a future icon
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(220, 50),
                Location = new Point(20, top),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(73, 80, 87),
                Cursor = Cursors.Hand
            };

            // Remove the default button borders
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 243, 245);

            btn.Click += onClick;
            pnlSidebar.Controls.Add(btn);
        }

        /// <summary>
        /// The Core SPA Method: Swaps the visible UserControl in the main content panel.
        /// </summary>
        public void NavigateTo(UserControl view)
        {
            if (view == null) return;

            if (pnlMainContent.Controls.Count > 0 && pnlMainContent.Controls[0].GetType() == view.GetType())
            {
                view.Dispose();
                return;
            }

            // Clear previous view and dispose to save memory
            foreach (Control ctrl in pnlMainContent.Controls)
            {
                ctrl.Dispose();
            }
            pnlMainContent.Controls.Clear();

            // Setup new view
            view.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(view);

            Debug.WriteLine($"[SPA] Navigated to {view.GetType().Name}");
        }

        private async void MainShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure the engine and web-sockets close politely
            Debug.WriteLine("Shutting down system...");
            await _engine.stopSystem();
        }
    }
}