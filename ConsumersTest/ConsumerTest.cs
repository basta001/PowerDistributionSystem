using Common;
using Consumers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumersTest
{
    [TestFixture]
    public class ConsumerTest
    {
        IConsumer _mockConsumer;
        IDistributionCenter center;
        ILogger logger;

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void DobarKonstruktorTest(IList<ElectricalDevice> devices)
        {
            
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void LosKonstruktorTest(IList<ElectricalDevice> devices)
        {
            Assert.Throws<ArgumentNullException>
                (() =>
                {
                    Consumer c = new Consumer(center, logger);
                });
        }

    }
}
