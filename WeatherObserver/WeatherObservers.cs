using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace WeatherObserver
{
    public class WeatherObservers : IWeatherObserver
    {
        private readonly Timer _timer;
        private readonly List<ISmallPowerGenerator> _smallPowerGenerators = new List<ISmallPowerGenerator>();

        public WeatherObservers(int weatherChangeIntervalInSec)
        {
            _timer = new Timer(weatherChangeIntervalInSec * 1000);
            _timer.Elapsed += ProccessWeatherChange;
            _timer.AutoReset = true;
        }

        private void ProccessWeatherChange(object sender, ElapsedEventArgs e)
        {
            var random = new Random();
            foreach (var item in _smallPowerGenerators)
            {
                item.PowerPercentage = random.Next(0, 100);
            }
        }

        public void RegisterSmallPowerGenerator(ISmallPowerGenerator smallPowerGenerator)
        {
            _smallPowerGenerators.Add(smallPowerGenerator);
        }

        public void StartObserving()
        {
            _timer.Start();
        }

        public void StopObserving()
        {
            _timer.Stop();
        }
    }
}
