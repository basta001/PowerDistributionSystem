using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallPowerGenerator
{
    public class SmallPowerGenerators : ISmallPowerGenerator
    {
        private readonly IDistributionCenter _distirbutionCenter;
        private readonly IDataBase _dataBase;

        private static int _idGenerator = 0;

        private readonly int _id;
        private readonly SmallPowerGeneratorType _type;
        private int _powerPercentage;

        public SmallPowerGenerators(SmallPowerGeneratorType generatorType, IDistributionCenter distirbutionCenter, IDataBase dataBase, int? powerPercentage = null)
        {
            _id = _idGenerator++;
            _type = generatorType;
            _powerPercentage = powerPercentage ?? new Random().Next(0, 100);
            _dataBase = dataBase;
            _distirbutionCenter = distirbutionCenter;

            _distirbutionCenter.ProcessEnergyProductonChange(this);
        }

        public SmallPowerGeneratorType Type => _type;

        public int ID => _id;

        public int PowerPercentage
        {
            get { return _powerPercentage; }
            set
            {
                _powerPercentage = value;
                //_dataBase.SaveSmallGeneratorChange(this);
                _distirbutionCenter.ProcessEnergyProductonChange(this);
            }
        }
    }
}
