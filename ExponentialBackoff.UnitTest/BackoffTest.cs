using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExponentialBackoff.UnitTest
{
    [TestClass]
    public class BackoffTest
    {
        private readonly int TestIterations = 10000;

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void CNegativeTest()
        {
            Backoff.GetBackoff(-1, 1000);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void CZeroTest()
        {
            long backoff = Backoff.GetBackoff(0, 1000);
        }

        /// <summary>
        /// verify the case where c = 0
        /// </summary>
        [TestMethod]
        public void C1Test()
        {
            for (int i = 0; i < TestIterations; i++)
            {
                long backOff = Backoff.GetBackoff(1, 1);
                Assert.IsTrue(backOff == 0 || backOff == 1, "Backoff = " + backOff);
            }
        }

        /// <summary>
        /// verify the case where c = 0
        /// </summary>
        [TestMethod]
        public void C3Test()
        {
            for (int i = 0; i < TestIterations; i++)
            {
                long backOff = Backoff.GetBackoff(2, 1);
                Assert.IsTrue(backOff == 0 || backOff == 1 || backOff == 7, "Backoff = " + backOff);
            }
        }

        /// <summary>
        /// verify the case where c = 0
        /// </summary>
        [TestMethod]
        public void CCeilingTest()
        {
            int c = 100;

            for (int i = 0; i < TestIterations; i++)
            {
                Assert.IsTrue(Backoff.GetBackoff(c, 1) <= 2047);
            }
        }

    }
}
