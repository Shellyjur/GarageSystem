using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private readonly String m_Manufacturer;//static same model to all
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
            //set
            //{
            //    m_Manufacturer = value;
            //}
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
            //set
            //{
            //    m_MaximumAirPressureByManufacturer = value;
            //}
        }



        //not static - check why
        public void Inflation(float i_MaxAir)//after exeption check? no exeption in air pressure
        {
            this.CurrentAirPressure = i_MaxAir;
        }
    }
}
