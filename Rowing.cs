using System;

namespace FitnessTracker
{
    public class Rowing : Activity
    {
        public Rowing()
            : base("Rowing", "Number of Strokes", "Time (minutes)", "Avg Heart Rate (bpm)")
        {
        }

        public override double CalculateCalories()
        {
            double heartRate = Metric3;
            double time = Metric2;
            return (heartRate * time * 0.014) - (time * 0.07);
        }
    }
}