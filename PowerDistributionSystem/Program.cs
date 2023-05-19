using Common;
using Consumers;
using DistributionCenters;
using HydroelectricPowerPlant;
using Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydroelectricPowerPlant;
using SmallPowerGenerator;
using WeatherObserver;

namespace PowerDistributionSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger consumerLogger = new Logger("consumer.txt", true);
            ILogger dcLogger = new Logger("distirbutionCenter.txt");
            IDataBase dataBase = new DataBase();
            IWeatherObserver weatherObserver = new WeatherObservers(30);

            IHydroelectricPowerPlant hydroelectricPowerPlant = new HydroelectricPowerPlants(0, dataBase);
            IDistributionCenter distirbutionCenter = new DistributionCentar(hydroelectricPowerPlant, dcLogger);

            // pravljenje solarnih panela i vetrenjaca
            // TO DO: ubaci da korisnik moze da ih doda
            List<ISmallPowerGenerator> smallPowerGenerators = new List<ISmallPowerGenerator>()
            {
                new SmallPowerGenerators(SmallPowerGeneratorType.SolarPanel, distirbutionCenter, dataBase),
                new SmallPowerGenerators(SmallPowerGeneratorType.SolarPanel, distirbutionCenter, dataBase),
                new SmallPowerGenerators(SmallPowerGeneratorType.SolarPanel, distirbutionCenter, dataBase),
                new SmallPowerGenerators(SmallPowerGeneratorType.WindGenerator, distirbutionCenter, dataBase),
                new SmallPowerGenerators(SmallPowerGeneratorType.WindGenerator, distirbutionCenter, dataBase),
                new SmallPowerGenerators(SmallPowerGeneratorType.WindGenerator, distirbutionCenter, dataBase),

            };

            // promena vremena
            foreach (var smallGenerator in smallPowerGenerators)
            {
                weatherObserver.RegisterSmallPowerGenerator(smallGenerator);
            }
            weatherObserver.StartObserving();


            List<ElectricalDevice> availableDevices = new List<ElectricalDevice>()
            {
                new ElectricalDevice("televizor", 10),
                new ElectricalDevice("pegla", 5),
                new ElectricalDevice("bojler", 20),
                new ElectricalDevice("frizider", 30),
            };

            // potrosac 
            IConsumer consumer = new Consumer(distirbutionCenter, consumerLogger);
            consumer.SelectDevices(availableDevices);

            consumer.RequestEnergy();

            // unos prazne linije za kraj izvrsavanja programa 
            Console.ReadLine();
        }
    }
}
