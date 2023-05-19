using Common;
using DistributionCenters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionCenterTest
{
    [TestFixture]
    public class DistributionCenterTests
    {
        IDistributionCenter _mockDistributionCenter;
        IHydroelectricPowerPlant _hydroelectric;
        ILogger _logger;

        [Test]
        [TestCase(35)]
        [TestCase(550)]
        public void CalculatePriceDobarTest(int requestedKWh)
        {
            DistributionCentar d = new DistributionCentar(_hydroelectric, _logger);

            Assert.AreEqual(requestedKWh, d);
        }


    }
}
