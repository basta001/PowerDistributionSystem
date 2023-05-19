using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroelectricPowerPlant
{
    public class HydroelectricPowerPlants : IHydroelectricPowerPlant
    {
        private int _productionPercentage;
        private readonly IDataBase _dataBase;

        public HydroelectricPowerPlants(int productionPercentage, IDataBase dataBase)
        {
            if (productionPercentage < 0 || productionPercentage > 100)
            {
                throw new ArgumentException();
            }
            _productionPercentage = productionPercentage;
            _dataBase = dataBase;
        }

        public int ProductionPercentage
        {
            get => _productionPercentage;
            set
            {
                _productionPercentage = value;
                _dataBase.SaveHydroelectricPowerPlantChange(value);
            }
        }
    }
}
