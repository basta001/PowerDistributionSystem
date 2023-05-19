using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ElectricalDevice
    {
        private readonly string name;
        private readonly int electricityConsumption;

        public ElectricalDevice(string name, int electricityConsumption)
        {
            this.name = name;
            this.electricityConsumption = electricityConsumption;
        }

        public string Name => name;
        public int ElectricityConsumptionPerHourInKW => electricityConsumption;

        public override string ToString()
        {
            return $"{Name} - {ElectricityConsumptionPerHourInKW} kWh";
        }
    }
}
