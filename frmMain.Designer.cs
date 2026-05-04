namespace FitnessTracker
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Form
            this.Text = "Fitness Tracker";
            this.Size = new System.Drawing.Size(860, 640);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Welcome label
            lblWelcome = new System.Windows.Forms.Label();
            lblWelcome.Location = new System.Drawing.Point(20, 15);
            lblWelcome.Size = new System.Drawing.Size(600, 35);
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            lblWelcome.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // Logout button
            btnLogout = new System.Windows.Forms.Button();
            btnLogout.Text = "Logout";
            btnLogout.Location = new System.Drawing.Point(730, 15);
            btnLogout.Size = new System.Drawing.Size(90, 35);
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 9f);
            btnLogout.BackColor = System.Drawing.Color.IndianRed;
            btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Divider label
            var lblDivider1 = new System.Windows.Forms.Label();
            lblDivider1.Location = new System.Drawing.Point(20, 55);
            lblDivider1.Size = new System.Drawing.Size(810, 2);
            lblDivider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            
            // Left Panel — Goal Setting + Activity Recording            
            var pnlLeft = new System.Windows.Forms.Panel();
            pnlLeft.Location = new System.Drawing.Point(20, 65);
            pnlLeft.Size = new System.Drawing.Size(390, 520);

            // Goal Section
            var lblGoalSection = new System.Windows.Forms.Label();
            lblGoalSection.Text = "🎯  Set Calorie Goal";
            lblGoalSection.Location = new System.Drawing.Point(0, 0);
            lblGoalSection.Size = new System.Drawing.Size(390, 28);
            lblGoalSection.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            lblGoalSection.ForeColor = System.Drawing.Color.DarkSlateBlue;

            lblCurrentGoal = new System.Windows.Forms.Label();
            lblCurrentGoal.Location = new System.Drawing.Point(0, 32);
            lblCurrentGoal.Size = new System.Drawing.Size(390, 22);
            lblCurrentGoal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Italic);
            lblCurrentGoal.ForeColor = System.Drawing.Color.Gray;

            var lblGoalInput = new System.Windows.Forms.Label();
            lblGoalInput.Text = "Enter target kcal to burn:";
            lblGoalInput.Location = new System.Drawing.Point(0, 60);
            lblGoalInput.Size = new System.Drawing.Size(390, 22);
            lblGoalInput.Font = new System.Drawing.Font("Segoe UI", 9f);

            txtGoal = new System.Windows.Forms.TextBox();
            txtGoal.Location = new System.Drawing.Point(0, 85);
            txtGoal.Size = new System.Drawing.Size(280, 25);
            txtGoal.Font = new System.Drawing.Font("Segoe UI", 10f);

            btnSetGoal = new System.Windows.Forms.Button();
            btnSetGoal.Text = "Set Goal";
            btnSetGoal.Location = new System.Drawing.Point(290, 83);
            btnSetGoal.Size = new System.Drawing.Size(100, 28);
            btnSetGoal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnSetGoal.BackColor = System.Drawing.Color.DarkSlateBlue;
            btnSetGoal.ForeColor = System.Drawing.Color.White;
            btnSetGoal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSetGoal.Click += new System.EventHandler(this.btnSetGoal_Click);

            // Divider
            var lblDivider2 = new System.Windows.Forms.Label();
            lblDivider2.Location = new System.Drawing.Point(0, 125);
            lblDivider2.Size = new System.Drawing.Size(390, 2);
            lblDivider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // Activity Section
            var lblActivitySection = new System.Windows.Forms.Label();
            lblActivitySection.Text = "🏃  Record Activity";
            lblActivitySection.Location = new System.Drawing.Point(0, 135);
            lblActivitySection.Size = new System.Drawing.Size(390, 28);
            lblActivitySection.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            lblActivitySection.ForeColor = System.Drawing.Color.DarkSlateBlue;

            var lblSelectActivity = new System.Windows.Forms.Label();
            lblSelectActivity.Text = "Select Activity:";
            lblSelectActivity.Location = new System.Drawing.Point(0, 170);
            lblSelectActivity.Size = new System.Drawing.Size(390, 22);
            lblSelectActivity.Font = new System.Drawing.Font("Segoe UI", 9f);

            cmbActivity = new System.Windows.Forms.ComboBox();
            cmbActivity.Location = new System.Drawing.Point(0, 193);
            cmbActivity.Size = new System.Drawing.Size(390, 25);
            cmbActivity.Font = new System.Drawing.Font("Segoe UI", 10f);
            cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbActivity.SelectedIndexChanged += new System.EventHandler(this.cmbActivity_SelectedIndexChanged);

            // Metric 1
            lblMetric1 = new System.Windows.Forms.Label();
            lblMetric1.Text = "Metric 1:";
            lblMetric1.Location = new System.Drawing.Point(0, 235);
            lblMetric1.Size = new System.Drawing.Size(390, 22);
            lblMetric1.Font = new System.Drawing.Font("Segoe UI", 9f);

            txtMetric1 = new System.Windows.Forms.TextBox();
            txtMetric1.Location = new System.Drawing.Point(0, 258);
            txtMetric1.Size = new System.Drawing.Size(390, 25);
            txtMetric1.Font = new System.Drawing.Font("Segoe UI", 10f);

            // Metric 2
            lblMetric2 = new System.Windows.Forms.Label();
            lblMetric2.Text = "Metric 2:";
            lblMetric2.Location = new System.Drawing.Point(0, 295);
            lblMetric2.Size = new System.Drawing.Size(390, 22);
            lblMetric2.Font = new System.Drawing.Font("Segoe UI", 9f);

            txtMetric2 = new System.Windows.Forms.TextBox();
            txtMetric2.Location = new System.Drawing.Point(0, 318);
            txtMetric2.Size = new System.Drawing.Size(390, 25);
            txtMetric2.Font = new System.Drawing.Font("Segoe UI", 10f);

            // Metric 3
            lblMetric3 = new System.Windows.Forms.Label();
            lblMetric3.Text = "Metric 3:";
            lblMetric3.Location = new System.Drawing.Point(0, 355);
            lblMetric3.Size = new System.Drawing.Size(390, 22);
            lblMetric3.Font = new System.Drawing.Font("Segoe UI", 9f);

            txtMetric3 = new System.Windows.Forms.TextBox();
            txtMetric3.Location = new System.Drawing.Point(0, 378);
            txtMetric3.Size = new System.Drawing.Size(390, 25);
            txtMetric3.Font = new System.Drawing.Font("Segoe UI", 10f);

            // Add Activity button
            btnAddActivity = new System.Windows.Forms.Button();
            btnAddActivity.Text = "Add Activity";
            btnAddActivity.Location = new System.Drawing.Point(0, 420);
            btnAddActivity.Size = new System.Drawing.Size(190, 40);
            btnAddActivity.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnAddActivity.BackColor = System.Drawing.Color.SeaGreen;
            btnAddActivity.ForeColor = System.Drawing.Color.White;
            btnAddActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddActivity.Click += new System.EventHandler(this.btnAddActivity_Click);

            // Clear button
            btnClear = new System.Windows.Forms.Button();
            btnClear.Text = "Clear All";
            btnClear.Location = new System.Drawing.Point(200, 420);
            btnClear.Size = new System.Drawing.Size(190, 40);
            btnClear.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnClear.BackColor = System.Drawing.Color.IndianRed;
            btnClear.ForeColor = System.Drawing.Color.White;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // Message label
            lblMessage = new System.Windows.Forms.Label();
            lblMessage.Location = new System.Drawing.Point(0, 470);
            lblMessage.Size = new System.Drawing.Size(390, 40);
            lblMessage.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Add all controls to left panel
            pnlLeft.Controls.Add(lblGoalSection);
            pnlLeft.Controls.Add(lblCurrentGoal);
            pnlLeft.Controls.Add(lblGoalInput);
            pnlLeft.Controls.Add(txtGoal);
            pnlLeft.Controls.Add(btnSetGoal);
            pnlLeft.Controls.Add(lblDivider2);
            pnlLeft.Controls.Add(lblActivitySection);
            pnlLeft.Controls.Add(lblSelectActivity);
            pnlLeft.Controls.Add(cmbActivity);
            pnlLeft.Controls.Add(lblMetric1);
            pnlLeft.Controls.Add(txtMetric1);
            pnlLeft.Controls.Add(lblMetric2);
            pnlLeft.Controls.Add(txtMetric2);
            pnlLeft.Controls.Add(lblMetric3);
            pnlLeft.Controls.Add(txtMetric3);
            pnlLeft.Controls.Add(btnAddActivity);
            pnlLeft.Controls.Add(btnClear);
            pnlLeft.Controls.Add(lblMessage);

           
            // Right Panel — Progress Display            
            var pnlRight = new System.Windows.Forms.Panel();
            pnlRight.Location = new System.Drawing.Point(430, 65);
            pnlRight.Size = new System.Drawing.Size(400, 520);

            var lblProgressSection = new System.Windows.Forms.Label();
            lblProgressSection.Text = "📊  Progress Report";
            lblProgressSection.Location = new System.Drawing.Point(0, 0);
            lblProgressSection.Size = new System.Drawing.Size(400, 28);
            lblProgressSection.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            lblProgressSection.ForeColor = System.Drawing.Color.DarkSlateBlue;

            btnViewProgress = new System.Windows.Forms.Button();
            btnViewProgress.Text = "Refresh Progress";
            btnViewProgress.Location = new System.Drawing.Point(0, 35);
            btnViewProgress.Size = new System.Drawing.Size(400, 35);
            btnViewProgress.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnViewProgress.BackColor = System.Drawing.Color.DarkSlateBlue;
            btnViewProgress.ForeColor = System.Drawing.Color.White;
            btnViewProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnViewProgress.Click += new System.EventHandler(this.btnViewProgress_Click);

            btnViewHistory = new System.Windows.Forms.Button();
            btnViewHistory.Text = "View Activity History";
            btnViewHistory.Location = new System.Drawing.Point(0, 75);
            btnViewHistory.Size = new System.Drawing.Size(400, 35);
            btnViewHistory.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnViewHistory.BackColor = System.Drawing.Color.SlateBlue;
            btnViewHistory.ForeColor = System.Drawing.Color.White;
            btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);

            pnlRight.Controls.Add(btnViewHistory);

            txtProgress = new System.Windows.Forms.TextBox();
            txtProgress.Location = new System.Drawing.Point(0, 120);
            txtProgress.Size = new System.Drawing.Size(400, 395);
            txtProgress.Font = new System.Drawing.Font("Consolas", 10f);
            txtProgress.Multiline = true;
            txtProgress.ReadOnly = true;
            txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtProgress.BackColor = System.Drawing.Color.White;

            pnlRight.Controls.Add(lblProgressSection);
            pnlRight.Controls.Add(btnViewProgress);
            pnlRight.Controls.Add(txtProgress);

            // Add all controls to form
            this.Controls.Add(lblWelcome);
            this.Controls.Add(btnLogout);
            this.Controls.Add(lblDivider1);
            this.Controls.Add(pnlLeft);
            this.Controls.Add(pnlRight);

            // Wire up events
            this.Load         += new System.EventHandler(this.frmMain_Load);
            this.FormClosing  += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
        }

        // Control declarations
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblCurrentGoal;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMetric1;
        private System.Windows.Forms.Label lblMetric2;
        private System.Windows.Forms.Label lblMetric3;
        private System.Windows.Forms.TextBox txtGoal;
        private System.Windows.Forms.TextBox txtMetric1;
        private System.Windows.Forms.TextBox txtMetric2;
        private System.Windows.Forms.TextBox txtMetric3;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.Button btnSetGoal;
        private System.Windows.Forms.Button btnAddActivity;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnViewProgress;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cmbActivity;
    }
}