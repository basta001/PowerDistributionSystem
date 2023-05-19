using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDataBase
    {
        void SaveSmallGeneratorChange(ISmallPowerGenerator smallPowerGenerator);
        void SaveHydroelectricPowerPlantChange(int percentage);
    }
}
