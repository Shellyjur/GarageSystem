using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleInGarage> m_GarageInventory;

        public Garage()
        { 
            m_GarageInventory = new Dictionary<string, VehicleInGarage>();
        }

        ////Properties:
        public Dictionary<string, VehicleInGarage> GarageInventory
        {
            get
            {
                return m_GarageInventory;
            }
        }
        
        public void InsertNewVehiclesIntoGrage(VehicleInGarage i_CustomerVehicle)
        {
            if (GarageInventory.ContainsKey(i_CustomerVehicle.CustomerVehicle.Licensing))
            {
                i_CustomerVehicle.Status = eVehicleFixingStatus.InRepairing;
            }
            else
            {
                m_GarageInventory.Add(i_CustomerVehicle.CustomerVehicle.Licensing, i_CustomerVehicle);
            }  
        }

        public uint ValidateLicenseNumber(string i_InputLicense)
        {
            uint output = 0;

            if (i_InputLicense.Length != 5)
            {
                throw new FormatException("You entered a wrong input.Please try again.");
            }
            else if(i_InputLicense[0] == '0' || !uint.TryParse(i_InputLicense, out output))
            {
                throw new FormatException("You entered a wrong input.Please try again.");
            }

            return output;
        }

        public bool VehicleExists(string i_LicenseNumber)
        {
            bool existsOrNot = false;

            if (GarageInventory.ContainsKey(i_LicenseNumber))
            {
                existsOrNot = true;
            }

            return existsOrNot;
        }

        public bool IsInSystem(string i_LicenseNumber)
        {
            bool existsOrNot = false;

            if (GarageInventory.ContainsKey(i_LicenseNumber))
            {
                existsOrNot = true;
                GarageInventory[i_LicenseNumber].Status = eVehicleFixingStatus.InRepairing;
            }

            return existsOrNot;
        }

        public int ValidationUserOption(string i_UserInput)
        {
            int userInputParsed = 0;

            if (!int.TryParse(i_UserInput, out userInputParsed) || (userInputParsed > 8 || userInputParsed < 1))
            {
                throw new FormatException("You entered a wrong input.Please try again.");
            }

            return userInputParsed;
        }

        public  Vehicle CreateVehicle(Enum i_ConcreteVehicleType, List<object> i_ConcreteVehicleParameters, List<object> i_WheelsInformation)
        {
            Vehicle tempConcreteVehicle;

            switch ((eAllVehicleTypes)i_ConcreteVehicleType)
            {

                case eAllVehicleTypes.ElectricCar:
                    tempConcreteVehicle = CreateObject.CreateElectricCar(i_ConcreteVehicleParameters);
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.FuelCar:
                    tempConcreteVehicle = CreateObject.CreateFuelCar(i_ConcreteVehicleParameters);
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.ElectricMotorcycle:
                    tempConcreteVehicle = CreateObject.CreateElectricMotorcycle(i_ConcreteVehicleParameters);
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.FuelMotorcycle:
                    tempConcreteVehicle = CreateObject.CreateFuelMotorcycle(i_ConcreteVehicleParameters);
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.FuelTruck:
                    tempConcreteVehicle = CreateObject.CreateFuelTruck(i_ConcreteVehicleParameters);
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                default:
                    return null;
            }
        }

        public static List<Wheels> CreateWheelList(List<object> i_WheelsParameters)
        {
            List<Wheels> wheelsCollection = new List<Wheels>();
            
            for (int i = 0 ; i < (int)i_WheelsParameters[i_WheelsParameters.Count - 1] ; i++)
            {
                Wheels wheel = new Wheels((string)i_WheelsParameters[0], (float)i_WheelsParameters[1], (float)i_WheelsParameters[2]);
                wheelsCollection.Add(wheel);
            }

            return wheelsCollection;
        }

        public void InflateToMaximum(string i_LicenseID)
        {
            foreach (KeyValuePair<string, VehicleInGarage> valueObject in GarageInventory)
            {
                if (valueObject.Key == i_LicenseID)
                {
                    if ((valueObject.Value.CustomerVehicle is ElectricCar) ||
                        (valueObject.Value.CustomerVehicle is FuelCar))
                    {
                        foreach (Wheels wheel in valueObject.Value.CustomerVehicle.WheelCollection)
                        {
                            wheel.CurrentAirPressure = 32f;
                        }
                    }

                    if ((valueObject.Value.CustomerVehicle is ElectricMotorcycle) ||
                        (valueObject.Value.CustomerVehicle is ElectricMotorcycle))
                    {
                        foreach (Wheels wheel in valueObject.Value.CustomerVehicle.WheelCollection)
                        {
                            wheel.CurrentAirPressure = 30f;
                        }
                    }

                    if (valueObject.Value.CustomerVehicle is FuelTruck)
                    {
                        foreach (Wheels wheel in valueObject.Value.CustomerVehicle.WheelCollection)
                        {
                            wheel.CurrentAirPressure = 26f;
                        }
                    }
                }  
            }   
        }

        public void FuelTypeMatch(string i_LicenseID, eFuelType i_FuelType)
        {
            foreach (KeyValuePair<string, VehicleInGarage> valueObject in GarageInventory)
            {
                if (valueObject.Key == i_LicenseID)
                {
                    if ((valueObject.Value.CustomerVehicle) is FuelCar)
                    {
                        if (((valueObject.Value.CustomerVehicle) as FuelCar).FuelType != i_FuelType)
                        {
                            throw new ArgumentException("This fuel type does not match the fuel type of the vehicle");
                        }
                    }

                    if ((valueObject.Value.CustomerVehicle) is FuelMotorcycle)
                    {
                        if (((valueObject.Value.CustomerVehicle) as FuelMotorcycle).FuelType != i_FuelType)
                        {
                            throw new ArgumentException("This fuel type does not match the fuel type of the vehicle");
                        }
                    }

                    if ((valueObject.Value.CustomerVehicle) is FuelTruck)
                    {
                        if (((valueObject.Value.CustomerVehicle) as FuelTruck).FuelType != i_FuelType)
                        {
                            throw new ArgumentException("This fuel type does not match the fuel type of the vehicle");
                        }
                    }
                }
            }
        }

        public void CheckFuelAmount(string i_FuelAmount, string i_LicenseID)
        {
            float updatedFuelAmount = 0;

            if (!float.TryParse(i_FuelAmount, out updatedFuelAmount))
            {
                throw new FormatException("You entered a wrong input.Please try again.");
            }

            foreach (KeyValuePair<string, VehicleInGarage> valueObject in GarageInventory)
            {
                if (valueObject.Key == i_LicenseID)
                {
                    if (valueObject.Value.CustomerVehicle is FuelCar)
                    {
                        float calculateAmount = ((valueObject.Value.CustomerVehicle) as FuelCar).CurrentAmountOfFuelLiters + updatedFuelAmount;
                        if (updatedFuelAmount < 0f || calculateAmount > 45f)
                        {
                            throw new ValueOutOfRangeException(0f, 45f);
                        }

                        ((valueObject.Value.CustomerVehicle) as FuelCar).CurrentAmountOfFuelLiters += updatedFuelAmount;
                        ((valueObject.Value.CustomerVehicle) as FuelCar).PercentageOfEnergyleft += (updatedFuelAmount / 45f) * 100;
                    }

                    if (valueObject.Value.CustomerVehicle is FuelMotorcycle)
                    {
                        float calculateAmount = ((valueObject.Value.CustomerVehicle) as FuelMotorcycle).CurrentAmountOfFuelLiters + updatedFuelAmount;
                        if (updatedFuelAmount < 0f || calculateAmount > 6f)
                        {
                            throw new ValueOutOfRangeException(0f, 6f);
                        }

                        ((valueObject.Value.CustomerVehicle) as FuelMotorcycle).CurrentAmountOfFuelLiters += updatedFuelAmount;
                        ((valueObject.Value.CustomerVehicle) as FuelMotorcycle).PercentageOfEnergyleft += (updatedFuelAmount / 6f) * 100;
                    }

                    if (valueObject.Value.CustomerVehicle is FuelTruck)
                    {
                        float calculateAmount = ((valueObject.Value.CustomerVehicle) as FuelTruck).CurrentAmountOfFuelLiters + updatedFuelAmount;
                        if (updatedFuelAmount < 0f || calculateAmount > 120f)
                        {
                            throw new ValueOutOfRangeException(0f, 120f);
                        }

                        ((valueObject.Value.CustomerVehicle) as FuelTruck).CurrentAmountOfFuelLiters += updatedFuelAmount;
                        ((valueObject.Value.CustomerVehicle) as FuelTruck).PercentageOfEnergyleft += (updatedFuelAmount / 120f) * 100;
                    }
                }
            }   
        }

        public void CheckMinutesAmount(string i_MinutesToCharge, string i_LicenseID)
        {
            float updatedMinutesToCharge = 0;
            float convertMinutesToHours = 0f;

            if (!float.TryParse(i_MinutesToCharge, out updatedMinutesToCharge))
            {
                throw new FormatException("You entered a wrong input.Please try again.");
            }

            convertMinutesToHours = updatedMinutesToCharge / 60f;
            foreach (KeyValuePair<string, VehicleInGarage> valueObject in GarageInventory)
            {
                if (valueObject.Key == i_LicenseID)
                {
                    if (valueObject.Value.CustomerVehicle is ElectricCar)
                    {
                        float calculateAmount = ((valueObject.Value.CustomerVehicle) as ElectricCar).BatteryTimeRemainingInHours + convertMinutesToHours;
                        if (convertMinutesToHours < 0f || calculateAmount > 3.2f)
                        {
                            throw new ValueOutOfRangeException(0, 3.2f);
                        }

                        ((valueObject.Value.CustomerVehicle) as ElectricCar).BatteryTimeRemainingInHours += convertMinutesToHours;
                        ((valueObject.Value.CustomerVehicle) as ElectricCar).PercentageOfEnergyleft += (convertMinutesToHours / 3.2f) * 100;
                    }

                    if (valueObject.Value.CustomerVehicle is ElectricMotorcycle)
                    {
                        float calculateAmount = ((valueObject.Value.CustomerVehicle) as ElectricMotorcycle).BatteryTimeRemainingInHours + convertMinutesToHours;
                        if (convertMinutesToHours < 0f || calculateAmount > 1.8f)
                        {
                            throw new ValueOutOfRangeException(0, 1.8f);
                        }

                        ((valueObject.Value.CustomerVehicle) as ElectricMotorcycle).BatteryTimeRemainingInHours += convertMinutesToHours;
                        ((valueObject.Value.CustomerVehicle) as ElectricMotorcycle).PercentageOfEnergyleft += (convertMinutesToHours / 1.8f) * 100;
                    }
                }
            }
        }

        public void AllInformation(out string i_GeneralInformation, string i_LicenseId)
        {
            i_GeneralInformation = string.Empty;
            i_GeneralInformation += string.Format("The license number is: {0}\n", i_LicenseId);
            i_GeneralInformation += string.Format("The vehicle owner name is: {0}\n", GarageInventory[i_LicenseId].CarOwner);
            i_GeneralInformation += string.Format("The vehicle owner phone number is: {0}\n", GarageInventory[i_LicenseId].OwnerPhone);
            i_GeneralInformation += string.Format("The vehicle status is: {0}\n", GarageInventory[i_LicenseId].Status);
            i_GeneralInformation += string.Format("The vehicle model is: {0}\n", GarageInventory[i_LicenseId].CustomerVehicle.ModelName);
            i_GeneralInformation += string.Format("The percentage of energy left is: {0:0.00}%\n", GarageInventory[i_LicenseId].CustomerVehicle.PercentageOfEnergyleft);
            i_GeneralInformation += string.Format("The wheel air pressure is: {0} and the manufacturer is: {1}\n", GarageInventory[i_LicenseId].CustomerVehicle.WheelCollection[0].CurrentAirPressure, GarageInventory[i_LicenseId].CustomerVehicle.WheelCollection[0].Manufacturer);
            if (GarageInventory[i_LicenseId].CustomerVehicle is ElectricVehicle)
            {
                i_GeneralInformation += string.Format("The remaining battery is: {0}\n", (GarageInventory[i_LicenseId].CustomerVehicle as ElectricVehicle).BatteryTimeRemainingInHours);
                if(GarageInventory[i_LicenseId].CustomerVehicle is ElectricCar)
                {
                    i_GeneralInformation += string.Format("The amount of doors is: {0} and the vehicle car is: {1}\n", (GarageInventory[i_LicenseId].CustomerVehicle as ElectricCar).CarDoors, (GarageInventory[i_LicenseId].CustomerVehicle as ElectricCar).CarColor);
                }

                if(GarageInventory[i_LicenseId].CustomerVehicle is ElectricMotorcycle)
                {
                    i_GeneralInformation += string.Format("The license type is: {0} and the engine volume of the motorcycle is: {1}\n", (GarageInventory[i_LicenseId].CustomerVehicle as ElectricMotorcycle).License, (GarageInventory[i_LicenseId].CustomerVehicle as ElectricMotorcycle).EngineVolume);
                }   
            }

            if (GarageInventory[i_LicenseId].CustomerVehicle is FuelVehicle)
            {
                i_GeneralInformation += string.Format("The current amount of fuel type {0} is: {1}\n", (GarageInventory[i_LicenseId].CustomerVehicle as FuelVehicle).FuelType, (GarageInventory[i_LicenseId].CustomerVehicle as FuelVehicle).CurrentAmountOfFuelLiters);
                if (GarageInventory[i_LicenseId].CustomerVehicle is FuelCar)
                {
                    i_GeneralInformation += string.Format("The amount of doors is: {0} and the vehicle car is: {1}\n", (GarageInventory[i_LicenseId].CustomerVehicle as FuelCar).CarDoors, (GarageInventory[i_LicenseId].CustomerVehicle as FuelCar).CarColor);
                }

                if (GarageInventory[i_LicenseId].CustomerVehicle is FuelMotorcycle)
                {
                    i_GeneralInformation += string.Format("The license type is: {0} and the engine volume of the motorcycle is: {1}\n", (GarageInventory[i_LicenseId].CustomerVehicle as FuelMotorcycle).License, (GarageInventory[i_LicenseId].CustomerVehicle as FuelMotorcycle).EngineVolume);
                }

                if (GarageInventory[i_LicenseId].CustomerVehicle is FuelTruck)
                {
                    i_GeneralInformation += string.Format("Does the truck carry dangerous substances? {0} The carry weight is: {1}\n", (GarageInventory[i_LicenseId].CustomerVehicle as FuelTruck).DangerousSubstance, (GarageInventory[i_LicenseId].CustomerVehicle as FuelTruck).MaximumCarryWeight);
                }
            }
        }

        public bool IsFuelOperated(string i_LicenseId)
        {
            bool isFuel = false;

            if(GarageInventory[i_LicenseId].CustomerVehicle is FuelVehicle)
            {
                isFuel = true;
            }

            return isFuel;
        }

        public bool IsOperatedbyElectricity(string i_LicenseId)
        {
            bool isElectrical = false;

            if (GarageInventory[i_LicenseId].CustomerVehicle is ElectricVehicle)
            {
                isElectrical = true;
            }

            return isElectrical;
        }
    }
}
