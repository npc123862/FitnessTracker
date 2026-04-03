using System;
using System.Diagnostics;

namespace FitnessTracker
{
    public class Yoga : Activity
    {
        public Yoga()
            : base("Yoga", "Number of Poses", "Time (minutes)", "Intensity Level (1-10)")
        {
        }

        public override double CalculateCalories()
        {
            double intensity = Metric3;
            double time = Metric2;
            double met = (intensity / 10.0) * 4.0;
            return met * 3.5 * time / 200;
        }
    }
}