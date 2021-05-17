using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private readonly eFuelType m_FuelType;
        private float m_CurrentAmountOfFuelLiters;
        private readonly float m_MaximumAmountOfFuelLiters;

        public FuelVehicle(Enum i_FuelType, float i_CurrentAmountOfFuelLiters, 
                   float i_MaximumAmountOfFuelLiters, string i_ModelName, string i_Licensing) : base(i_ModelName, i_Licensing, (i_CurrentAmountOfFuelLiters/ i_MaximumAmountOfFuelLiters)*100)//check what we send to the base class
        {
            m_FuelType = (eFuelType) i_FuelType;
            m_CurrentAmountOfFuelLiters = i_CurrentAmountOfFuelLiters;
            m_MaximumAmountOfFuelLiters = i_MaximumAmountOfFuelLiters;
        }
        //properties
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            //set
            //{
            //    m_FuelType = value;
            //}
        }

        public float CurrentAmountOfFuelLiters
        {
            get
            {
                return m_CurrentAmountOfFuelLiters;
            }
            set
            {
                m_CurrentAmountOfFuelLiters = value;
            }
        }

        public float MaximumAmountOfFuelLiters
        {
            get
            {
                return m_MaximumAmountOfFuelLiters;
            }
            //set
            //{
            //    m_MaximumAmountOfFuelLiters = value;
            //}
        }

        public abstract void ToRefuelWithFuel(float i_AmountOfLitersToAdd);
    }
}
