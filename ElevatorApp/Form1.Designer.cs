namespace ElevatorApp
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
            components = new System.ComponentModel.Container();
            pnlShaft = new Panel();
            pnlCar = new Panel();
            lblFloor1Name = new Label();
            btnRequestFloor1 = new Button();
            lblStatusFloor1 = new Label();
            lblFloor0Name = new Label();
            btnRequestFloor0 = new Button();
            lblStatusFloor0 = new Label();
            grpControlPanel = new GroupBox();
            btnFloor0 = new Button();
            btnFloor1 = new Button();
            lblDisplay = new Label();
            btnLog = new Button();
            dgvLog = new DataGridView();
            btnHistory = new Button();
            animationTimer = new System.Windows.Forms.Timer(components);
            pnlShaft.SuspendLayout();
            grpControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLog).BeginInit();
            SuspendLayout();
            // 
            // pnlShaft
            // 
            pnlShaft.BackColor = Color.Silver;
            pnlShaft.Controls.Add(pnlCar);
            pnlShaft.Location = new Point(20, 20);
            pnlShaft.Name = "pnlShaft";
            pnlShaft.Size = new Size(150, 450);
            pnlShaft.TabIndex = 0;
            // 
            // pnlCar
            // 
            pnlCar.BackColor = Color.SteelBlue;
            pnlCar.Location = new Point(10, 260);
            pnlCar.Name = "pnlCar";
            pnlCar.Size = new Size(130, 180);
            pnlCar.TabIndex = 0;
            // 
            // lblFloor1Name
            // 
            lblFloor1Name.AutoSize = true;
            lblFloor1Name.Location = new Point(190, 30);
            lblFloor1Name.Name = "lblFloor1Name";
            lblFloor1Name.Size = new Size(74, 20);
            lblFloor1Name.TabIndex = 1;
            lblFloor1Name.Text = "First Floor";
            // 
            // btnRequestFloor1
            // 
            btnRequestFloor1.Location = new Point(190, 60);
            btnRequestFloor1.Name = "btnRequestFloor1";
            btnRequestFloor1.Size = new Size(94, 29);
            btnRequestFloor1.TabIndex = 2;
            btnRequestFloor1.Text = "Call";
            btnRequestFloor1.UseVisualStyleBackColor = true;
            btnRequestFloor1.Click += btnRequestFloor1_Click;
            // 
            // lblStatusFloor1
            // 
            lblStatusFloor1.AutoSize = true;
            lblStatusFloor1.Location = new Point(190, 100);
            lblStatusFloor1.Name = "lblStatusFloor1";
            lblStatusFloor1.Size = new Size(97, 20);
            lblStatusFloor1.TabIndex = 3;
            lblStatusFloor1.Text = "Elevator at: G";
            // 
            // lblFloor0Name
            // 
            lblFloor0Name.AutoSize = true;
            lblFloor0Name.Location = new Point(190, 280);
            lblFloor0Name.Name = "lblFloor0Name";
            lblFloor0Name.Size = new Size(96, 20);
            lblFloor0Name.TabIndex = 4;
            lblFloor0Name.Text = "Ground Floor";
            // 
            // btnRequestFloor0
            // 
            btnRequestFloor0.Location = new Point(190, 310);
            btnRequestFloor0.Name = "btnRequestFloor0";
            btnRequestFloor0.Size = new Size(94, 29);
            btnRequestFloor0.TabIndex = 5;
            btnRequestFloor0.Text = "Call";
            btnRequestFloor0.UseVisualStyleBackColor = true;
            btnRequestFloor0.Click += btnRequestFloor0_Click;
            // 
            // lblStatusFloor0
            // 
            lblStatusFloor0.AutoSize = true;
            lblStatusFloor0.Location = new Point(190, 350);
            lblStatusFloor0.Name = "lblStatusFloor0";
            lblStatusFloor0.Size = new Size(97, 20);
            lblStatusFloor0.TabIndex = 6;
            lblStatusFloor0.Text = "Elevator at: G";
            // 
            // grpControlPanel
            // 
            grpControlPanel.Controls.Add(btnFloor0);
            grpControlPanel.Controls.Add(btnFloor1);
            grpControlPanel.Controls.Add(lblDisplay);
            grpControlPanel.Location = new Point(360, 20);
            grpControlPanel.Name = "grpControlPanel";
            grpControlPanel.Size = new Size(220, 250);
            grpControlPanel.TabIndex = 7;
            grpControlPanel.TabStop = false;
            grpControlPanel.Text = "Control Panel";
            // 
            // btnFloor0
            // 
            btnFloor0.Location = new Point(120, 130);
            btnFloor0.Name = "btnFloor0";
            btnFloor0.Size = new Size(80, 60);
            btnFloor0.TabIndex = 2;
            btnFloor0.Text = "G";
            btnFloor0.UseVisualStyleBackColor = true;
            btnFloor0.Click += btnFloor0_Click;
            // 
            // btnFloor1
            // 
            btnFloor1.Location = new Point(20, 130);
            btnFloor1.Name = "btnFloor1";
            btnFloor1.Size = new Size(80, 60);
            btnFloor1.TabIndex = 1;
            btnFloor1.Text = "1";
            btnFloor1.UseVisualStyleBackColor = true;
            btnFloor1.Click += btnFloor1_Click;
            // 
            // lblDisplay
            // 
            lblDisplay.BackColor = Color.Black;
            lblDisplay.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDisplay.ForeColor = Color.Lime;
            lblDisplay.Location = new Point(20, 30);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(180, 70);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "G";
            lblDisplay.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnLog
            // 
            btnLog.Location = new Point(360, 290);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(120, 35);
            btnLog.TabIndex = 8;
            btnLog.Text = "Show Log";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // dgvLog
            // 
            dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLog.Location = new Point(360, 335);
            dgvLog.Name = "dgvLog";
            dgvLog.ReadOnly = true;
            dgvLog.RowHeadersWidth = 51;
            dgvLog.Size = new Size(500, 200);
            dgvLog.TabIndex = 9;
            // 
            // btnHistory
            // 
            btnHistory.Location = new Point(740, 290);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(120, 35);
            btnHistory.TabIndex = 10;
            btnHistory.Text = "History Logs";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // animationTimer
            // 
            animationTimer.Interval = 15;
            animationTimer.Tick += animationTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(btnHistory);
            Controls.Add(dgvLog);
            Controls.Add(btnLog);
            Controls.Add(grpControlPanel);
            Controls.Add(lblStatusFloor0);
            Controls.Add(btnRequestFloor0);
            Controls.Add(lblFloor0Name);
            Controls.Add(lblStatusFloor1);
            Controls.Add(btnRequestFloor1);
            Controls.Add(lblFloor1Name);
            Controls.Add(pnlShaft);
            Name = "Form1";
            Text = "Elevator Control";
            pnlShaft.ResumeLayout(false);
            grpControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlShaft;
        private Panel pnlCar;
        private Label lblFloor1Name;
        private Button btnRequestFloor1;
        private Label lblStatusFloor1;
        private Label lblFloor0Name;
        private Button btnRequestFloor0;
        private Label lblStatusFloor0;
        private GroupBox grpControlPanel;
        private Label lblDisplay;
        private Button btnFloor0;
        private Button btnFloor1;
        private Button btnLog;
        private DataGridView dgvLog;
        private Button btnHistory;
        private System.Windows.Forms.Timer animationTimer;
    }
}
