using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private eAmountOfDoors m_CarDoors;
        private eColorOfTheCar m_CarColor;
        public ElectricCar(Enum i_CarDoors, Enum i_CarColor, float i_BatteryTimeRemainingInHours, float i_MaximumBatteryTimeInHours, string i_ModelName, string i_Licensing) : 
            base(i_BatteryTimeRemainingInHours, i_MaximumBatteryTimeInHours, i_ModelName, i_Licensing)
        {
            m_CarDoors = (eAmountOfDoors)i_CarDoors;
            m_CarColor = (eColorOfTheCar)i_CarColor;
        }

        public override void BatteryCharging(float i_HoursToAdd)
        {
            BatteryTimeRemainingInHours += i_HoursToAdd;
        }

        ////Properties:
        public eAmountOfDoors CarDoors
        {
            get
            {
                return m_CarDoors;
            }

            set
            {
                m_CarDoors = value;
            }
        }

        public eColorOfTheCar CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }
    }
}
