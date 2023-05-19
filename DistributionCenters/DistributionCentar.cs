using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionCenters
{
    public class DistributionCentar : IDistributionCenter
    {
        private readonly IHydroelectricPowerPlant _hydroelectricPowerPlant;
        private readonly ILogger _logger;

        private readonly Dictionary<int, int> solarPanelsProduction = new Dictionary<int, int>();
        private readonly Dictionary<int, int> windGenerators = new Dictionary<int, int>();

        public DistributionCentar(IHydroelectricPowerPlant hydroelectricPowerPlant, ILogger logger)
        {
            _hydroelectricPowerPlant = hydroelectricPowerPlant;
            _logger = logger;
        }

        public void ProcessEnergyProductonChange(ISmallPowerGenerator generator)
        {
            switch (generator.Type)
            {
                case SmallPowerGeneratorType.SolarPanel:
                    AddOrUpdateDict(solarPanelsProduction, generator.ID, generator.PowerPercentage);
                    break;

                case SmallPowerGeneratorType.WindGenerator:
                    AddOrUpdateDict(windGenerators, generator.ID, generator.PowerPercentage);
                    break;
            }

            _hydroelectricPowerPlant.ProductionPercentage = CalcuatePercantageProductionForHEPP();
        }

        public int ProvideEnergy(int requestedKWh)
        {
            _logger.Info($"Potrosac zahteva {requestedKWh} kWh.");
            _hydroelectricPowerPlant.ProductionPercentage = CalcuatePercantageProductionForHEPP();
            return CalculatePrice(requestedKWh);
        }

        private int CalculatePrice(int requestedKWh)
        {
            // TO DO: smisli neku logiku za ovo - da li je jeftina ili skupa, mora li da radi elektrana i slicno...
            int price = 0;
            if (requestedKWh >= 0 && requestedKWh < 350)
            {
                price = requestedKWh * 50;
            }
            else if (requestedKWh > 350 && requestedKWh < 1600)
            {
                price = requestedKWh * 70;
            }
            else if (requestedKWh > 1600)
            {
                price = requestedKWh * 90;
            }

            return price;
        }

        private int CalcuatePercantageProductionForHEPP()
        {
            // TO DO: smisli neku logiku za ovo koja se zasniva na proizvodnji i potrosnji
            return new Random().Next(0, 100);
        }

        private void AddOrUpdateDict(Dictionary<int, int> dict, int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }
    }
}
