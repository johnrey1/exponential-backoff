
namespace ExponentialBackoff
{
    using System;

    public class Backoff
    {

        /// <summary>
        /// compute the backoff
        /// throws an exception if C &lteq; 0
        /// 
        /// </summary>
        /// <param name="c">the number sequential collisions (or events) that have occurred warranting backoff</param>
        /// <param name="interval">the base time interval to use to compute backoff in the case of c = 1</param>
        /// <returns></returns>
        public static long GetBackoff(int c, long interval, int ceiling = 10)
        {
            if (c <= 0)
            {
                throw new ArgumentOutOfRangeException("Pass in a number greater than 0");
            }

            int max_k = (int)Math.Pow(2,Math.Min(c,ceiling)) - 1;
            
            Random r = new Random();
            int k = r.Next(max_k);

            return k * interval;
        }
    }
}
