using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum SmallPowerGeneratorType
    {
        SolarPanel,
        WindGenerator
    }
    public interface ISmallPowerGenerator
    {
        SmallPowerGeneratorType Type { get; }
        int ID { get; }
        int PowerPercentage { get; set; }
    }
}
