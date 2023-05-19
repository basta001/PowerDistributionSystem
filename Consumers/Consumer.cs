using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumers
{
    public class Consumer : IConsumer
    {
        private readonly IDistributionCenter _distirbutionCenter;
        private readonly ILogger _logger;

        private readonly IList<ElectricalDevice> _devices = new List<ElectricalDevice>();

        public Consumer(IDistributionCenter distirbutionCenter, ILogger logger)
        {
            _distirbutionCenter = distirbutionCenter ?? throw new ArgumentNullException(nameof(distirbutionCenter));
            _logger = logger;
        }
        public IEnumerable<ElectricalDevice> Devices => _devices;

        public void RequestEnergy()
        {
            int neededEnergy = Devices.Sum(d => d.ElectricityConsumptionPerHourInKW);
            int price = _distirbutionCenter.ProvideEnergy(neededEnergy);

            _logger.Info($"Korisnik je dobio energiju po ceni {price} po kWh");
        }

        public void SelectDevices(IList<ElectricalDevice> allDevices)
        {
            _devices.Clear();
            PrintDevices(allDevices);
            ReadUserInput(allDevices);

            if (_devices.Count == 0)
            {
                _logger.Warn("Korisnik nije odabrao nijedan uredjaj!");
            }
            else
            {
                _logger.Info("Korisnik je uspesno odabrao uredjaje.");
            }
        }

        private void PrintDevices(IList<ElectricalDevice> devices)
        {
            Console.WriteLine("Odaberite elektricne uredjaje koje zelite da prikljucite");
            for (int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine($"{i}: {devices[i]}");
            }
        }

        private void ReadUserInput(IList<ElectricalDevice> devices)
        {
            Console.WriteLine("Unesite redni broj uredjaja u novom redu za svaki uredjaj koji zelite da dodate.\n!!!Za kraj unosa unesite prazan red.!!!");
            var line = Console.ReadLine();
            while (!String.IsNullOrEmpty(line))
            {
                if (int.TryParse(line, out int index))
                {
                    // TO DO: dodati proveru za opseg indeksa >= 0, < devices.Count i log.Warn
                    if (index >= 0 && index < devices.Count)
                    {
                        _devices.Add(devices[index]);
                    }
                    else
                    {
                        _logger.Warn("Korisnik je uneo indeks van opsega!");
                    }
                }
                else
                {
                    // TO DO: nije unet broj log.Info ili Warn
                    _logger.Warn("Broj nije unet!!!");
                }
                line = Console.ReadLine();
            }
        }
    }
}
