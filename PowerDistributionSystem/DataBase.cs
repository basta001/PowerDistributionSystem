using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerDistributionSystem
{
    internal class DataBase : IDataBase
    {
        public void SaveHydroelectricPowerPlantChange(int percentage)
        {
            Dictionary<string, string> power = new Dictionary<string, string>();
        }

        public void SaveSmallGeneratorChange(ISmallPowerGenerator smallPowerGenerator)
        {
            Dictionary<string, string> generators = new Dictionary<string, string>();
        }
    }
}
