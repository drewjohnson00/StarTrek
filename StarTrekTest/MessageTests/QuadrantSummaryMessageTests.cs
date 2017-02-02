using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarTrek.Messages;
using StarTrek;

namespace StarTrekTest.MessageTests
{
    /// <summary>
    /// Summary description for QuadrantSummaryMessageTests
    /// </summary>
    [TestClass]
    public class QuadrantSummaryMessageTests
    {
        public QuadrantSummaryMessageTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void HappyPathTest()
        {
            // Create a message
            var testMessage = new QuadrantSummaryMessage
            {
                Summary = new List<QuadrantSummary> {
                    new QuadrantSummary { QuadrantX = 0, QuadrantY = 0, NumberOfStars = 0, NumberOfEnemies = 0 },
                    new QuadrantSummary { QuadrantX = 1, QuadrantY = 0, NumberOfStars = 1, NumberOfEnemies = 0 },
                    new QuadrantSummary { QuadrantX = 2, QuadrantY = 0, NumberOfStars = 2, NumberOfEnemies = 0 },
                    new QuadrantSummary { QuadrantX = 0, QuadrantY = 1, NumberOfStars = 0, NumberOfEnemies = 1 },
                    new QuadrantSummary { QuadrantX = 1, QuadrantY = 1, NumberOfStars = 1, NumberOfEnemies = 1 },
                    new QuadrantSummary { QuadrantX = 2, QuadrantY = 1, NumberOfStars = 2, NumberOfEnemies = 1 }
                }
            };

            // Add it to the queue
            var e = Enterprise.Instance;
            e.RealityQueue.Enqueue(testMessage);

            // Verify results
        }

    }
}
