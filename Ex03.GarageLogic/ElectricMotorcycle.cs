using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private eLicenseType m_License;
        private int m_EngineVolume;

        public ElectricMotorcycle(Enum i_License, int i_EngineVolume, float i_BatteryTimeRemainingInHours, float i_MaximumBatteryTimeInHours, string i_ModelName, string i_Licensing) :
            base(i_BatteryTimeRemainingInHours, i_MaximumBatteryTimeInHours, i_ModelName, i_Licensing)
        {
            m_License = (eLicenseType)i_License;
            m_EngineVolume = i_EngineVolume;
        }

        public eLicenseType License
        {
            get
            {
                return m_License;
            }

            set
            {
                m_License = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public override void BatteryCharging(float i_HoursToAdd)
        {
            BatteryTimeRemainingInHours += i_HoursToAdd;
        }
    }
}
