using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private readonly String m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float m_MaximumAirPressureByManufacturer;
        
        public Wheels(string i_Manufacturer, float i_CurrentAirPressure, float i_MaximumAirPressureByManufacturer)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaximumAirPressureByManufacturer = i_MaximumAirPressureByManufacturer;
        }

        ////Properties:
        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaximumAirPressureByManufacturer
        {
            get
            {
                return m_MaximumAirPressureByManufacturer;
            }
        }
    }
}
