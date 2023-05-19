using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IConsumer
    {
        IEnumerable<ElectricalDevice> Devices { get; }
        void SelectDevices(IList<ElectricalDevice> allDevices);
        void RequestEnergy();
    }
}
