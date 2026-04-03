using System;

namespace FitnessTracker
{
    public class walking : Activity
    {
        public walking()
            : base("Walking", "Steps", "Distance (km)", "Time (minutes)")
            {
            }
        
        public override double CalculateCalories()
        {
            double met = 3.5;
            double time = Metric3;
            return met * 3.5 * time / 200;
        }
    }
}