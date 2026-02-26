namespace M6Lab
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
            panel1 = new Panel();
            addVertexButton = new Button();
            addEdgeButton = new Button();
            createGraphButton = new Button();
            graphComboBox = new ComboBox();
            copySelectedGraphButton = new Button();
            displayButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Location = new Point(184, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(604, 383);
            panel1.TabIndex = 0;
            // 
            // addVertexButton
            // 
            addVertexButton.Location = new Point(38, 80);
            addVertexButton.Name = "addVertexButton";
            addVertexButton.Size = new Size(75, 23);
            addVertexButton.TabIndex = 2;
            addVertexButton.Text = "Add Vertex";
            addVertexButton.UseVisualStyleBackColor = true;
            addVertexButton.Click += addVertexClick;
            // 
            // addEdgeButton
            // 
            addEdgeButton.Location = new Point(38, 109);
            addEdgeButton.Name = "addEdgeButton";
            addEdgeButton.Size = new Size(75, 23);
            addEdgeButton.TabIndex = 3;
            addEdgeButton.Text = "Add Edge";
            addEdgeButton.UseVisualStyleBackColor = true;
            addEdgeButton.Click += addEdgeClick;
            // 
            // createGraphButton
            // 
            createGraphButton.Location = new Point(356, 12);
            createGraphButton.Name = "createGraphButton";
            createGraphButton.Size = new Size(87, 23);
            createGraphButton.TabIndex = 4;
            createGraphButton.Text = "Create Graph";
            createGraphButton.UseVisualStyleBackColor = true;
            createGraphButton.Click += createGraphClick;
            // 
            // graphComboBox
            // 
            graphComboBox.FormattingEnabled = true;
            graphComboBox.Location = new Point(63, 12);
            graphComboBox.Name = "graphComboBox";
            graphComboBox.Size = new Size(267, 23);
            graphComboBox.TabIndex = 5;
            graphComboBox.SelectedIndexChanged += graphComboBox_SelectedIndexChanged;
            // 
            // copySelectedGraphButton
            // 
            copySelectedGraphButton.Location = new Point(449, 12);
            copySelectedGraphButton.Name = "copySelectedGraphButton";
            copySelectedGraphButton.Size = new Size(126, 23);
            copySelectedGraphButton.TabIndex = 6;
            copySelectedGraphButton.Text = "Copy Selected Graph";
            copySelectedGraphButton.UseVisualStyleBackColor = true;
            copySelectedGraphButton.Click += copySelectedGraphClick;
            // 
            // displayButton
            // 
            displayButton.Location = new Point(581, 12);
            displayButton.Name = "displayButton";
            displayButton.Size = new Size(155, 23);
            displayButton.TabIndex = 7;
            displayButton.Text = "Display Selected Graph";
            displayButton.UseVisualStyleBackColor = true;
            displayButton.Click += displayButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 8;
            label1.Text = "Graph: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(displayButton);
            Controls.Add(copySelectedGraphButton);
            Controls.Add(graphComboBox);
            Controls.Add(createGraphButton);
            Controls.Add(addEdgeButton);
            Controls.Add(addVertexButton);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button addVertexButton;
        private Button addEdgeButton;
        private Button createGraphButton;
        private ComboBox graphComboBox;
        private Button copySelectedGraphButton;
        private Button displayButton;
        private Label label1;
    }
}
