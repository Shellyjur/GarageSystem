using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeRemainingInHours;
        private float m_MaximumBatteryTimeInHours;

        public ElectricVehicle(float i_BatteryTimeRemainingInHours, float i_MaximumBatteryTimeInHours, string i_ModelName, string i_Licensing) : 
                   base(i_ModelName, i_Licensing, (i_BatteryTimeRemainingInHours/i_MaximumBatteryTimeInHours)*100)
        {
            m_BatteryTimeRemainingInHours = i_BatteryTimeRemainingInHours;
            m_MaximumBatteryTimeInHours = i_MaximumBatteryTimeInHours;
        }
        ////Properties:
        public float BatteryTimeRemainingInHours
        {
            get
            {
                return m_BatteryTimeRemainingInHours;
            }
            set
            {
                m_BatteryTimeRemainingInHours = value;
            }
        }
        public float MaximumBatteryTimeInHours
        {
            get
            {
                return m_MaximumBatteryTimeInHours;
            }
            set
            {
                m_MaximumBatteryTimeInHours = value;
            }

        }
        //יכול להיות שלא צריך אבסטרקט כי אין
        //הבדל בין הרכבים שמונעות עי חשמל לעומת רכבים שמונעים עי דלק
        public abstract void BatteryCharging(float i_HoursToAdd);
        

    }
}
