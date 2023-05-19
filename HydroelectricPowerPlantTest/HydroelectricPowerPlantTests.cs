using Common;
using HydroelectricPowerPlant;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroelectricPowerPlantTest
{
    [TestFixture]
    public class HydroelectricPowerPlantTests
    {
        IDataBase _mockDataBase;

        /*[SetUp]
        public void setUp()
        {
            _mockDataBase = new Mock<IDataBase>();
        }*/

        [Test]
        [TestCase(100)]
        [TestCase(0)]
        [TestCase(50)]
        public void HydroelectricKonstruktorDobarTest(int precentage)
        {
            HydroelectricPowerPlants h = new HydroelectricPowerPlants(precentage, _mockDataBase);
            Assert.IsNotNull(h.ProductionPercentage);
        }


        [Test]
        [TestCase(101)]
        [TestCase(-1)]
        public void HydroelectricLosiParametri(int precentage)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    HydroelectricPowerPlants h = new HydroelectricPowerPlants(precentage, _mockDataBase);
                });
        }

        [Test]
        public void VerifySaveToDB()
        {
            int percentage = 50;
            HydroelectricPowerPlants h = new HydroelectricPowerPlants(percentage, _mockDataBase);

            h.ProductionPercentage = percentage;

            Assert.AreEqual(h.ProductionPercentage, percentage);
           // _mockDataBase.Verify(db => db.Send(SaveHydroelectricPowerPlantChange(percentage)));   //Provera da li je pozvana odgovarajuca metoda sa odgovarajuci parametrom
        }
    }
}
