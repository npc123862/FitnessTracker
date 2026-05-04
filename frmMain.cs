using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTracker
{
    // Main dashboard form that users see after logging in
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
            UpdateProgressDisplay();
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
                lblCurrentGoal.Text = $"Current Goal: {goal:F2} kcal";
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
            if (tracker.CurrentUser.GoalCalories <= 0)
            {
                ShowMessage("Please set a calorie goal before recording activities.", Color.Red);
                return;
            }
            
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
            ShowMessage("", Color.Black);

            btnViewProgress.Text = "Refreshing...";
            btnViewProgress.BackColor = System.Drawing.Color.SlateBlue;

            UpdateProgressDisplay();

            btnViewProgress.Text = "✓ Progress Refreshed!";
            btnViewProgress.BackColor = System.Drawing.Color.SeaGreen;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += (s, args) =>
            {
                btnViewProgress.Text = "Refresh Progress";
                btnViewProgress.BackColor = System.Drawing.Color.DarkSlateBlue;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateProgressDisplay()
        {
            if (tracker.CurrentUser.GoalCalories <= 0)
            {
                txtProgress.Text = "No goal set yet.\r\nPlease set a kcal goal first.";
                txtProgress.ForeColor = Color.OrangeRed;
                return;
            }

            if (tracker.Activities.Count == 0)
            {
                txtProgress.Text = "No activities recorded yet.\r\nPlease add an activity first.";
                txtProgress.ForeColor = Color.OrangeRed;
                return;
            }

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

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            List<ActivityRecord> history = tracker.GetActivityHistory();

            if (history.Count == 0)
            {
                txtProgress.Text = "No activity history found.";
                txtProgress.ForeColor = System.Drawing.Color.OrangeRed;
                return;
            }

            string nl = "\r\n";

            double totalCalories = 0;
            for (int i = 0; i < history.Count; i++)
            {
                totalCalories += history[i].CaloriesBurned;
            }

            string display = "─────────────────────────────────" + nl;
            display += "Activity History:" + nl;
            display += "─────────────────────────────────" + nl;
            display += $"Total Activities: {history.Count}" + nl;
            display += $"Total Calories Burned: {totalCalories:F2} kcal" + nl;
            display += "─────────────────────────────────" + nl;
            display += nl;

            for (int i = history.Count - 1; i >= 0; i--)
            {
                ActivityRecord r = history[i];
                display += $"{i + 1}. {r.ActivityName} - {r.Date}" + nl;
                display += $"{r.Metric1Label}: {r.Metric1}" + nl;
                display += $"{r.Metric2Label}: {r.Metric2}" + nl;
                display += $"{r.Metric3Label}: {r.Metric3}" + nl;
                display += $"Calories Burned: {r.CaloriesBurned:F2} kcal" + nl;
                display += "─────────────────────────────────" + nl;
            }

            txtProgress.Text = display;
            txtProgress.ForeColor = System.Drawing.Color.DarkSlateBlue;
        }
    }
}