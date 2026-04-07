using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class frmMain : Form
    {
        private FitnessTrackerManager tracker;
        private frmLogin loginForm;

        public frmMain(FitnessTrackerManager tracker, frmLogin loginForm)
        {
            InitializeComponent();
            this.tracker = tracker;
            this.loginForm = loginForm;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Fitness Tracker - Welcome, {tracker.CurrentUser.Username}!";
            lblWelcome.Text = $"Welcome, {tracker.CurrentUser.Username}!";

            UpdateGoalDisplay();

            PopulateActivityDropdown();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tracker.LogoutUser();
            loginForm.OnMainFormClosed();
        }

        private void PopulateActivityDropdown()
        {
            cmbActivity.Items.Clear();
            cmbActivity.Items.Add("Walking");
            cmbActivity.Items.Add("Swimming");
            cmbActivity.Items.Add("Running");
            cmbActivity.Items.Add("Cycling");
            cmbActivity.Items.Add("Rowing");
            cmbActivity.Items.Add("Yoga");
            cmbActivity.SelectedIndex = 0;
        }

        private void UpdateGoalDisplay()
        {
            double goal = tracker.CurrentUser.GoalCalories;

            if (goal > 0)
                lblCurrentGoal.Text = $"Current Goal: {goal:F2} calories";
            else
                lblCurrentGoal.Text = "Current Goal: Not set yet";
        }

        private void UpdateMetricLabels(Activity activity)
        {
            lblMetric1.Text = activity.Metric1Label + ":";
            lblMetric2.Text = activity.Metric2Label + ":";
            lblMetric3.Text = activity.Metric3Label + ":";
        }

        private Activity CreateSelectedActivity()
        {
            switch (cmbActivity.SelectedItem.ToString())
            {
                case "Walking": return new Walking();
                case "Swimming": return new Swimming();
                case "Running": return new Running();
                case "Cycling": return new Cycling();
                case "Rowing": return new Rowing();
                case "Yoga": return new Yoga();
                default: return null;
            }
        }

        private void cmbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Activity selected = CreateSelectedActivity();

            if (selected != null)
                UpdateMetricLabels(selected);
            
            txtMetric1.Clear();
            txtMetric2.Clear();
            txtMetric3.Clear();
            ShowMessage("", Color.Black);
        }

        private void btnSetGoal_Click(object sender, EventArgs e)
        {
            string input = txtGoal.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                ShowMessage("Please enter a calorie goal.", Color.Red);
                return;
            }

            double goalCalories;
            if (!double.TryParse(input, out goalCalories))
            {
                ShowMessage("Please enter a valid number for the goal.", Color.Red);
                return;
            }

            string result = tracker.SetGoal(goalCalories);
            UpdateGoalDisplay();

            if (result.Contains("successfully"))
                ShowMessage(result, Color.Green);
            else
                ShowMessage(result, Color.Red);
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            double metric1, metric2, metric3;

            if (!double.TryParse(txtMetric1.Text.Trim(), out metric1) ||
                !double.TryParse(txtMetric2.Text.Trim(), out metric2) ||
                !double.TryParse(txtMetric3.Text.Trim(), out metric3))
            {
                ShowMessage("Please enter valid numbers for all three metrics.", Color.Red);
                return;
            }

            Activity activity = CreateSelectedActivity();

            if (activity == null)
            {
                ShowMessage("Please select an activity.", Color.Red);
                return;
            }

            activity.Metric1 = metric1;
            activity.Metric2 = metric2;
            activity.Metric3 = metric3;

            string result = tracker.AddActivity(activity);

            if (result.Contains("successful"))
            {
                ShowMessage(result, Color.Green);
                txtMetric1.Clear();
                txtMetric2.Clear();
                txtMetric3.Clear();

                UpdateProgressDisplay();
            }
            else
            {
                ShowMessage(result, Color.Red);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tracker.ClearActivities();
            txtProgress.Clear();
            ShowMessage("All activities cleared.", Color.OrangeRed);
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            UpdateProgressDisplay();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateProgressDisplay()
        {
            string summary = tracker.GetProgressSummary();
            txtProgress.Text = summary;

            if (tracker.HasAchievedGoal())
                txtProgress.ForeColor = Color.DarkGreen;
            else
                txtProgress.ForeColor = Color.DarkRed;
        }

        private void ShowMessage(string message, Color colour)
        {
            lblMessage.ForeColor = colour;
            lblMessage.Text = message;
        }
    }
}