using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    sealed class FuelCar : FuelVehicle
    {
        private eAmountOfDoors m_CarDoors;
        private eColorOfTheCar m_CarColor;
       
        public FuelCar(Enum i_CarDoors, Enum i_CarColor,eFuelType i_FuelType, float i_CurrentAmountOfFuelLiters, float i_MaximumAmountOfFuelLiters, string i_ModelName, string i_Licensing) :
            base(i_FuelType, i_CurrentAmountOfFuelLiters, i_MaximumAmountOfFuelLiters, i_ModelName, i_Licensing)//סתם שלחנו דברים
        {
            m_CarDoors = (eAmountOfDoors)i_CarDoors;
            m_CarColor = (eColorOfTheCar)i_CarColor;
        }

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
        //enum eColorOfTheCar
        //{
        //    Red,
        //    Silver,
        //    White,
        //    Black,
        //}

        //enum eAmountOfDoors
        //{
        //    Two,
        //    Three,
        //    Four,
        //    Five,
        //}
        public override void ToRefuelWithFuel(float i_AmountOfLitersToAdd)
        {
            CurrentAmountOfFuelLiters += i_AmountOfLitersToAdd;
        }
    }
}
