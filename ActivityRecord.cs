using System;
using System.Diagnostics;

namespace FitnessTracker
{
    // To store activity history to JSON
    public class ActivityRecord
    {
        public string Username { get; set; }
        public string ActivityName { get; set; }
        public double Metric1 { get; set; }
        public double Metric2 { get; set; }
        public double Metric3 { get; set; }
        public string Metric1Label { get; set; }
        public string Metric2Label { get; set; }
        public string Metric3Label { get; set; }
        public double CaloriesBurned { get; set; }
        public string Date { get; set; }

        public ActivityRecord() { }

        public ActivityRecord(string username, Activity activity)
        {
            Username = username;
            ActivityName = activity.ActivityName;
            Metric1 = activity.Metric1;
            Metric2 = activity.Metric2;
            Metric3 = activity.Metric3;
            Metric1Label = activity.Metric1Label;
            Metric2Label = activity.Metric2Label;
            Metric3Label = activity.Metric3Label;
            CaloriesBurned = activity.CalculateCalories();
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }
    }
}