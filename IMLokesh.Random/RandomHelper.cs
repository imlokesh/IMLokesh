using System;
using System.Text;
using System.Threading;

namespace IMLokesh.Random
{
    public static class RandomHelper
    {
        /// <summary>
        /// Global System.RandomHelper instance. Use this only with lock.
        /// </summary>
        private static readonly System.Random GlobalRandom = new System.Random();

        /// <summary>
        /// Private object for thread synchronization. 
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Returns an instance of System.RandomHelper. This instance is not time dependent as it is generated using a global random as seed.
        /// </summary>
        /// <returns></returns>
        public static System.Random NewRandom()
        {
            lock (_lock)
            {
                return new System.Random(GlobalRandom.Next());
            }
        }

        private static readonly ThreadLocal<System.Random> ThreadRandom = new ThreadLocal<System.Random>(NewRandom);

        public static System.Random Instance => ThreadRandom.Value;

        public static string RandomString(int size, bool lowerCase = false)
        {
            StringBuilder randStr = new StringBuilder(size);

            int start = (lowerCase) ? 97 : 65;

            for (int i = 0; i < size; i++)
            {
                var nextDouble = Instance.NextDouble();
                randStr.Append((char)(26 * nextDouble + start));
            }

            return randStr.ToString();
        }

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns></returns>
        public static int RandomInt()
        {
            return Instance.Next();
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to 0.</param>
        /// <returns></returns>
        public static int RandomInt(int maxValue)
        {
            return Instance.Next(maxValue);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns></returns>
        public static int RandomInt(int minValue, int maxValue)
        {
            return Instance.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0, and less than 1.0.
        /// </summary>
        /// <returns></returns>
        public static double RandomDouble()
        {
            return Instance.NextDouble();
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to minValue, and less than maxValue.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <param name="digits">The number of </param>
        /// <returns></returns>
        public static double RandomDouble(int minValue, int maxValue, int digits)
        {
            return Math.Round(RandomInt(minValue, maxValue) + RandomDouble(), digits);
        }

        /// <summary>
        /// Returns a random Boolean value (true/false).
        /// </summary>
        /// <returns></returns>
        public static bool RandomBool()
        {
            return (RandomDouble() > 0.5);
        }

        /// <summary>
        /// Returns a random DateTime between DateTime.MinValue and DateTime.Now
        /// </summary>
        /// <returns></returns>
        public static DateTime RandomDate()
        {
            return RandomDate(DateTime.MinValue, DateTime.Now);
        }

        /// <summary>
        /// Returns a random DateTime between minValue and DateTime.Now
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random DateTime returned.</param>
        /// <returns></returns>
        public static DateTime RandomDate(DateTime minValue)
        {
            return RandomDate(minValue, DateTime.Now);
        }

        /// <summary>
        /// Returns a random DateTime between minValue and maxValue
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random DateTime returned. </param>
        /// <param name="maxValue">The exclusive upper bound of the random DateTime returned. maxValue must be greater than or equal to minValue. </param>
        /// <returns></returns>
        public static DateTime RandomDate(DateTime minValue, DateTime maxValue)
        {
            TimeSpan range = new TimeSpan(maxValue.Ticks - minValue.Ticks);
            if (range < TimeSpan.Zero)
            {
                throw new ArgumentException("maxValue must be greater than or equal to minValue.");
            }
            return minValue + new TimeSpan((long)(range.Ticks * RandomDouble()));
        }

    }
}