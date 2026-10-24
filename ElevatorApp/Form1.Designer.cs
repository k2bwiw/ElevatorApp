namespace ElevatorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitleA = new Label();
            pnlShaftA = new Panel();
            pnlCarA = new Panel();
            lblTitleB = new Label();
            pnlShaftB = new Panel();
            pnlCarB = new Panel();

            lblFloor1Name = new Label();
            btnCall1 = new Button();
            lblFloor0Name = new Label();
            btnCall0 = new Button();

            grpPanelA = new GroupBox();
            lblDisplayA = new Label();
            btnA1 = new Button();
            btnA0 = new Button();
            lblStatusA = new Label();

            grpPanelB = new GroupBox();
            lblDisplayB = new Label();
            btnB1 = new Button();
            btnB0 = new Button();
            lblStatusB = new Label();

            btnLog = new Button();
            btnHistory = new Button();
            dgvLog = new DataGridView();
            animationTimer = new System.Windows.Forms.Timer(components);

            pnlShaftA.SuspendLayout();
            pnlShaftB.SuspendLayout();
            grpPanelA.SuspendLayout();
            grpPanelB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLog).BeginInit();
            SuspendLayout();

            // lblTitleA
            lblTitleA.AutoSize = true;
            lblTitleA.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleA.ForeColor = Color.FromArgb(25, 55, 95);
            lblTitleA.Location = new Point(25, 15);
            lblTitleA.Name = "lblTitleA";
            lblTitleA.Text = "Elevator A";

            // pnlShaftA
            pnlShaftA.BackColor = Color.Silver;
            pnlShaftA.Controls.Add(pnlCarA);
            pnlShaftA.Location = new Point(25, 50);
            pnlShaftA.Name = "pnlShaftA";
            pnlShaftA.Size = new Size(150, 560);

            // pnlCarA
            pnlCarA.BackColor = Color.SteelBlue;
            pnlCarA.Location = new Point(10, 320);
            pnlCarA.Name = "pnlCarA";
            pnlCarA.Size = new Size(130, 230);

            // lblTitleB
            lblTitleB.AutoSize = true;
            lblTitleB.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleB.ForeColor = Color.FromArgb(25, 55, 95);
            lblTitleB.Location = new Point(200, 15);
            lblTitleB.Name = "lblTitleB";
            lblTitleB.Text = "Elevator B";

            // pnlShaftB
            pnlShaftB.BackColor = Color.Silver;
            pnlShaftB.Controls.Add(pnlCarB);
            pnlShaftB.Location = new Point(200, 50);
            pnlShaftB.Name = "pnlShaftB";
            pnlShaftB.Size = new Size(150, 560);

            // pnlCarB
            pnlCarB.BackColor = Color.CornflowerBlue;
            pnlCarB.Location = new Point(10, 320);
            pnlCarB.Name = "pnlCarB";
            pnlCarB.Size = new Size(130, 230);

            // lblFloor1Name
            lblFloor1Name.AutoSize = true;
            lblFloor1Name.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFloor1Name.ForeColor = Color.FromArgb(25, 55, 95);
            lblFloor1Name.Location = new Point(380, 70);
            lblFloor1Name.Name = "lblFloor1Name";
            lblFloor1Name.Text = "First floor";

            // btnCall1
            StyleAccentButton(btnCall1);
            btnCall1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCall1.Location = new Point(380, 100);
            btnCall1.Name = "btnCall1";
            btnCall1.Size = new Size(150, 55);
            btnCall1.Text = "Call up to 1";
            btnCall1.Click += btnCall1_Click;

            // lblFloor0Name
            lblFloor0Name.AutoSize = true;
            lblFloor0Name.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFloor0Name.ForeColor = Color.FromArgb(25, 55, 95);
            lblFloor0Name.Location = new Point(380, 520);
            lblFloor0Name.Name = "lblFloor0Name";
            lblFloor0Name.Text = "Ground floor";

            // btnCall0
            StyleAccentButton(btnCall0);
            btnCall0.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCall0.Location = new Point(380, 550);
            btnCall0.Name = "btnCall0";
            btnCall0.Size = new Size(150, 55);
            btnCall0.Text = "Call down to G";
            btnCall0.Click += btnCall0_Click;

            // grpPanelA
            grpPanelA.BackColor = Color.Transparent;
            grpPanelA.Controls.Add(lblDisplayA);
            grpPanelA.Controls.Add(btnA1);
            grpPanelA.Controls.Add(btnA0);
            grpPanelA.Controls.Add(lblStatusA);
            grpPanelA.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpPanelA.ForeColor = Color.FromArgb(25, 55, 95);
            grpPanelA.Location = new Point(570, 20);
            grpPanelA.Name = "grpPanelA";
            grpPanelA.Size = new Size(320, 290);
            grpPanelA.TabStop = false;
            grpPanelA.Text = "Elevator A - inside";

            // lblDisplayA
            lblDisplayA.BackColor = Color.Black;
            lblDisplayA.Font = new Font("Segoe UI", 36F, FontStyle.Regular);
            lblDisplayA.ForeColor = Color.Lime;
            lblDisplayA.Location = new Point(25, 40);
            lblDisplayA.Name = "lblDisplayA";
            lblDisplayA.Size = new Size(270, 95);
            lblDisplayA.Text = "G";
            lblDisplayA.TextAlign = ContentAlignment.MiddleCenter;

            // btnA1
            StyleAccentButton(btnA1);
            btnA1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnA1.Location = new Point(25, 150);
            btnA1.Name = "btnA1";
            btnA1.Size = new Size(125, 90);
            btnA1.Text = "1";
            btnA1.Click += btnA1_Click;

            // btnA0
            StyleAccentButton(btnA0);
            btnA0.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnA0.Location = new Point(160, 150);
            btnA0.Name = "btnA0";
            btnA0.Size = new Size(125, 90);
            btnA0.Text = "G";
            btnA0.Click += btnA0_Click;

            // lblStatusA
            lblStatusA.AutoSize = true;
            lblStatusA.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblStatusA.ForeColor = Color.FromArgb(40, 40, 40);
            lblStatusA.Location = new Point(25, 250);
            lblStatusA.Name = "lblStatusA";
            lblStatusA.Text = "Idle at G";

            // grpPanelB
            grpPanelB.BackColor = Color.Transparent;
            grpPanelB.Controls.Add(lblDisplayB);
            grpPanelB.Controls.Add(btnB1);
            grpPanelB.Controls.Add(btnB0);
            grpPanelB.Controls.Add(lblStatusB);
            grpPanelB.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpPanelB.ForeColor = Color.FromArgb(25, 55, 95);
            grpPanelB.Location = new Point(910, 20);
            grpPanelB.Name = "grpPanelB";
            grpPanelB.Size = new Size(320, 290);
            grpPanelB.TabStop = false;
            grpPanelB.Text = "Elevator B - inside";

            // lblDisplayB
            lblDisplayB.BackColor = Color.Black;
            lblDisplayB.Font = new Font("Segoe UI", 36F, FontStyle.Regular);
            lblDisplayB.ForeColor = Color.Lime;
            lblDisplayB.Location = new Point(25, 40);
            lblDisplayB.Name = "lblDisplayB";
            lblDisplayB.Size = new Size(270, 95);
            lblDisplayB.Text = "G";
            lblDisplayB.TextAlign = ContentAlignment.MiddleCenter;

            // btnB1
            StyleAccentButton(btnB1);
            btnB1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnB1.Location = new Point(25, 150);
            btnB1.Name = "btnB1";
            btnB1.Size = new Size(125, 90);
            btnB1.Text = "1";
            btnB1.Click += btnB1_Click;

            // btnB0
            StyleAccentButton(btnB0);
            btnB0.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnB0.Location = new Point(160, 150);
            btnB0.Name = "btnB0";
            btnB0.Size = new Size(125, 90);
            btnB0.Text = "G";
            btnB0.Click += btnB0_Click;

            // lblStatusB
            lblStatusB.AutoSize = true;
            lblStatusB.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblStatusB.ForeColor = Color.FromArgb(40, 40, 40);
            lblStatusB.Location = new Point(25, 250);
            lblStatusB.Name = "lblStatusB";
            lblStatusB.Text = "Idle at G";

            // btnLog
            btnLog.BackColor = Color.FromArgb(176, 196, 222);
            btnLog.FlatStyle = FlatStyle.Flat;
            btnLog.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnLog.ForeColor = Color.FromArgb(25, 55, 95);
            btnLog.Location = new Point(570, 340);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(150, 40);
            btnLog.Text = "Show Log";
            btnLog.UseVisualStyleBackColor = false;
            btnLog.Click += btnLog_Click;

            // btnHistory
            btnHistory.BackColor = Color.FromArgb(176, 196, 222);
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnHistory.ForeColor = Color.FromArgb(25, 55, 95);
            btnHistory.Location = new Point(730, 340);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(160, 40);
            btnHistory.Text = "History Logs";
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += btnHistory_Click;

            // dgvLog  (modest size; stretches horizontally but stays a bottom strip)
            dgvLog.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvLog.BackgroundColor = Color.White;
            dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLog.Location = new Point(570, 390);
            dgvLog.Name = "dgvLog";
            dgvLog.ReadOnly = true;
            dgvLog.RowHeadersWidth = 51;
            dgvLog.Size = new Size(660, 220);
            dgvLog.TabIndex = 0;

            // animationTimer
            animationTimer.Interval = 15;
            animationTimer.Tick += animationTimer_Tick;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(222, 238, 250);
            ClientSize = new Size(1260, 660);
            MinimumSize = new Size(1120, 720);
            Controls.Add(lblTitleA);
            Controls.Add(pnlShaftA);
            Controls.Add(lblTitleB);
            Controls.Add(pnlShaftB);
            Controls.Add(lblFloor1Name);
            Controls.Add(btnCall1);
            Controls.Add(lblFloor0Name);
            Controls.Add(btnCall0);
            Controls.Add(grpPanelA);
            Controls.Add(grpPanelB);
            Controls.Add(btnLog);
            Controls.Add(btnHistory);
            Controls.Add(dgvLog);
            Name = "Form1";
            Text = "Elevator Control";

            pnlShaftA.ResumeLayout(false);
            pnlShaftB.ResumeLayout(false);
            grpPanelA.ResumeLayout(false);
            grpPanelA.PerformLayout();
            grpPanelB.ResumeLayout(false);
            grpPanelB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // gives a button the shared blue "accent" look
        private void StyleAccentButton(Button b)
        {
            b.BackColor = Color.SteelBlue;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.UseVisualStyleBackColor = false;
        }

        #endregion

        private Label lblTitleA;
        private Panel pnlShaftA;
        private Panel pnlCarA;
        private Label lblTitleB;
        private Panel pnlShaftB;
        private Panel pnlCarB;
        private Label lblFloor1Name;
        private Button btnCall1;
        private Label lblFloor0Name;
        private Button btnCall0;
        private GroupBox grpPanelA;
        private Label lblDisplayA;
        private Button btnA1;
        private Button btnA0;
        private Label lblStatusA;
        private GroupBox grpPanelB;
        private Label lblDisplayB;
        private Button btnB1;
        private Button btnB0;
        private Label lblStatusB;
        private Button btnLog;
        private Button btnHistory;
        private DataGridView dgvLog;
        private System.Windows.Forms.Timer animationTimer;
    }
}
