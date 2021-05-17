using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class CreateObject
    {
        internal static ElectricCar CreateElectricCar(List<object> i_ElectricCarInfo)
        {
            ElectricCar electricCarObj = new ElectricCar((eAmountOfDoors)i_ElectricCarInfo[0], (eColorOfTheCar)i_ElectricCarInfo[1], (float)i_ElectricCarInfo[2], (float)i_ElectricCarInfo[3], (string)i_ElectricCarInfo[4], (string)i_ElectricCarInfo[5]);
            return electricCarObj;
        }

        internal static FuelCar CreateFuelCar(List<object> i_FuelCarInfo)
        {
            FuelCar fuelCarObj = new FuelCar((eAmountOfDoors)i_FuelCarInfo[0], (eColorOfTheCar)i_FuelCarInfo[1], (eFuelType)i_FuelCarInfo[2], (float)i_FuelCarInfo[3], (float)i_FuelCarInfo[4], (string)i_FuelCarInfo[5], (string)i_FuelCarInfo[6]);
            return fuelCarObj;
        }

        internal static ElectricMotorcycle CreateElectricMotorcycle(List<object> i_ElectricMotorcycleInfo)
        {
            ElectricMotorcycle electricMotorcycleObj = new ElectricMotorcycle((eLicenseType)i_ElectricMotorcycleInfo[0], (int)i_ElectricMotorcycleInfo[1], (float)i_ElectricMotorcycleInfo[2], (float)i_ElectricMotorcycleInfo[3], (string)i_ElectricMotorcycleInfo[4], (string)i_ElectricMotorcycleInfo[5]);
            return electricMotorcycleObj;
        }

        internal static FuelMotorcycle CreateFuelMotorcycle(List<object> i_FuelMotorcycleInfo)
        {
            FuelMotorcycle fuelMotorcycleObj = new FuelMotorcycle((eLicenseType)i_FuelMotorcycleInfo[0], (int)i_FuelMotorcycleInfo[1],(eFuelType)i_FuelMotorcycleInfo[2], (float)i_FuelMotorcycleInfo[3], (float)i_FuelMotorcycleInfo[4], (string)i_FuelMotorcycleInfo[5], (string)i_FuelMotorcycleInfo[6]);
            return fuelMotorcycleObj;
        }

        internal static FuelTruck CreateFuelTruck(List<object> i_FuelTruckInfo)
        {
            FuelTruck fuelTruckObj = new FuelTruck((bool)i_FuelTruckInfo[0], (float)i_FuelTruckInfo[1], (eFuelType)i_FuelTruckInfo[2], (float)i_FuelTruckInfo[3], (float)i_FuelTruckInfo[4], (string)i_FuelTruckInfo[5],(string)i_FuelTruckInfo[6]);
            return fuelTruckObj;
        }
    }
}
