using System;

namespace FitnessTracker
{
    public abstract class Activity
    {
        private string activityName;
        private double metric1;
        private double metric2;
        private double metric3;
        private string metric1Label;
        private string metric2Label;
        private string metric3Label;

        public Activity(string activityName, string metric1Label, string metric2Label, string metric3Label)
        {
            this.activityName = activityName;
            this.metric1Label = metric1Label;
            this.metric2Label = metric2Label;
            this.metric3Label = metric3Label;
            this.metric1 = 0;
            this.metric2 = 0;
            this.metric3 = 0;
        }

        public string ActivityName
        {
            get { return activityName; }
            set { activityName = value; }
        }

        public double Metric1
        {
            get { return metric1; }
            set { metric1 = value; }
        }

        public double Metric2
        {
            get { return metric2; }
            set { metric2 = value; }
        }

        public double Metric3
        {
            get { return metric3; }
            set { metric3 = value; }
        }

        public string Metric1Label
        {
            get { return metric1Label; }
        }

        public string Metric2Label
        {
            get { return metric2Label; }
        }

        public string Metric3Label
        {
            get { return metric3Label; }
        }

        public virtual string GetSummary()
        {
            return $"{activityName}: {CalculateCalories():F2} calories burned";
        }

        public bool AreMetricsValid()
        {
            return metric1 > 0 && metric2 > 0 && metric3 > 0;
        }
    }
}