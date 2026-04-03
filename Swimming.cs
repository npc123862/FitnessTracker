using System;

namespace FitnessTracker
{
    public class Swimming : Activity
    {
        public Swimming()
            : base("Swimming", "Number of Laps", "Time (minutes)", "Average Heart Rate (bpm)")
        {
        }

        public override double CalculateCalories()
        {
            double met = 7.0;
            double time = Metric2;
            return met * 3.5 * time / 200;
        }
    }
}