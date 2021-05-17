using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    sealed class FuelTruck : FuelVehicle
    {
        private bool m_DangerousSubstance;
        private float m_MaximumCarryWeight;

        public FuelTruck(bool i_DangerousSubstance, float i_MaximumCarryWeight, eFuelType i_FuelType, float i_CurrentAmountOfFuelLiters, float i_MaximumAmountOfFuelLiters, string i_ModelName, string i_Licensing) :
            base(i_FuelType, i_CurrentAmountOfFuelLiters, i_MaximumAmountOfFuelLiters, i_ModelName, i_Licensing)
        {
            m_DangerousSubstance = i_DangerousSubstance;
            m_MaximumCarryWeight = i_MaximumCarryWeight;
        }

        public bool DangerousSubstance
        {
            get
            {
                return m_DangerousSubstance;
            }

            set
            {
                m_DangerousSubstance = value;
            }
        }

        public float MaximumCarryWeight
        {
            get
            {
                return m_MaximumCarryWeight;
            }

            set
            {
                m_MaximumCarryWeight = value;
            }
        }
        public override void ToRefuelWithFuel(float i_AmountOfLitersToAdd)
        {
            CurrentAmountOfFuelLiters += i_AmountOfLitersToAdd;
        }
    }
}
