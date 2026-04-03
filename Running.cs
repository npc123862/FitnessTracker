using System;

namespace FitnessTracker
{
    public class Running : Activity
    {
        public Running()
            : base("Running", "Distance (km)", "Time (minutes)", "Avg Speed (km/h)")
        {
        }

        public override double CalculateCalories()
        {
            double speed = Metric3;
            double time = Metric2;
            return speed * 0.75 * time / 60;
        }
    }
}