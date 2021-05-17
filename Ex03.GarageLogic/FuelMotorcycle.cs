using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelMotorcycle: FuelVehicle
    {
        private eLicenseType m_License;
        private int m_EngineVolume;

        public FuelMotorcycle(Enum i_License, int i_EngineVolume, eFuelType i_FuelType, float i_CurrentAmountOfFuelLiters, float i_MaximumAmountOfFuelLiters, string i_ModelName, string i_Licensing) : 
            base(i_FuelType, i_CurrentAmountOfFuelLiters, i_MaximumAmountOfFuelLiters, i_ModelName, i_Licensing)
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

        public override void ToRefuelWithFuel(float i_AmountOfLitersToAdd)
        {
            CurrentAmountOfFuelLiters += i_AmountOfLitersToAdd;
        }
    }
}
