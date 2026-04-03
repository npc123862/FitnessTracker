using System;

namespace FitnessTracker
{
    public class Cycling : Activity
    {
        public Cycling()
            : base("Cycling", "Distance (km)", "Time (minutes)", "Avg Speed (km/h)")
        {
        }

        public override double CalculateCalories()
        {
            double met = 6.0;
            double time = Metric2;
            return met * 3.5 * time /200;
        }
    }
}