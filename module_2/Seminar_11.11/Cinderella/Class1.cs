using System;

namespace Cinderella
{
    public abstract class Something
    {
        protected static readonly Random Rand = new();
    }

    public class Lentil : Something
    {
        // Floating point number in range [0;2]
        private double Weight = 2 * Rand.NextDouble();

        public override string ToString()
        {
            return $"Lentil with weight = {Weight:F2}";
        }
    }

    public class Ashes : Something
    {
        // Floating point number in range [0;1]
        private double Volume = Rand.NextDouble();

        public override string ToString()
        {
            return $"Ashes with volume = {Volume:F2}";
        }
    }
}