using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IWeatherObserver
    {
        void StartObserving();
        void StopObserving();
        void RegisterSmallPowerGenerator(ISmallPowerGenerator smallPowerGenerator);
    }
}
