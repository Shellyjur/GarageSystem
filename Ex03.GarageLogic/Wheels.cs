using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public struct Wheels
    {
        private String m_Manufacturer;//static same model to all
        private float m_CurrentAirPressure;
        private float m_MaximumAirPressureByManufacturer;
        
        ////Properties:
        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
            set
            {
                m_Manufacturer = value;
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
            set
            {
                m_MaximumAirPressureByManufacturer = value;
            }
        }



        //not static - check why
        public void Inflation(float i_AirToAdd)//after exeption check? no exeption in air pressure
        {
            this.m_CurrentAirPressure += i_AirToAdd;
        }
    }
}
