using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        //private List<VehicleInGarage> m_GarageInventory;
        private readonly Dictionary<string, VehicleInGarage> m_GarageInventory;

        //public static void Main()
        //{
            
        //}

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
            //set
            //{
            //    m_GarageInventory = new List<Vehicle>();
            //}
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

        public void ShowLicensingNumbers(Enum i_StateToFilter)
        {
            string temporaryOutPut = String.Empty;
            StringBuilder presntingSummeryOfLicensel = new StringBuilder();
            foreach (KeyValuePair<string, VehicleInGarage> CustomerVehicleCard in m_GarageInventory)
            {
                temporaryOutPut = String.Format("The state of license number {0} is {1}", CustomerVehicleCard.Value.CustomerVehicle.Licensing,
                    CustomerVehicleCard.Value.Status);
                presntingSummeryOfLicensel.Append(temporaryOutPut).Append("\n");
                temporaryOutPut = String.Empty;//do we need to erase or not?
            }
        }
        public void ChangeStateOfVehicle(String i_Licensing, Enum i_NewStatus)
        {
            foreach (KeyValuePair<string, VehicleInGarage> CustomerVehicleCard in m_GarageInventory)
            {
                if (CustomerVehicleCard.Value.CustomerVehicle.Licensing == i_Licensing)
                {
                    CustomerVehicleCard.Value.Status = (eVehicleFixingStatus) i_NewStatus;
                    break;
                }
            }
        }

        public void ToInflateWheelsToMaximum(String i_Licensing)
        {
            foreach (KeyValuePair<string, VehicleInGarage> CustomerVehicleCard in m_GarageInventory)
            {
                if (CustomerVehicleCard.Value.CustomerVehicle.Licensing == i_Licensing)
                {
                    foreach (Wheels wheel in CustomerVehicleCard.Value.CustomerVehicle.WheelCollection)
                    {
                        wheel.Inflation(wheel.MaximumAirPressureByManufacturer - wheel.CurrentAirPressure);   
                    }
                }
            }
        }

        public void RefuelFuel(String i_Licensing, Enum i_FuelType, float i_AmountToFill)//משאית או מכונית או אופנוע
        {
           // Type typeOfVehicle;
            foreach (KeyValuePair<string, VehicleInGarage> CustomerVehicleCard in m_GarageInventory)
            {
                if (CustomerVehicleCard.Value.CustomerVehicle.Licensing == i_Licensing)
                {
                    //FuelVehicle <-- vechile <-- veichleingarage
                    //FuelVehicle casting = GetType(CustomerVehicleCard.Value.CustomerVehicle)is FuelVehicle;
                    //Vehicle paka = CustomerVehicleCard.Value.CustomerVehicle;
                    //FuelVehicle pakapa = (FuelVehicle)paka;
                    
                    FuelVehicle casting = (CustomerVehicleCard.Value.CustomerVehicle) as FuelVehicle;
                    if ((eFuelType)i_FuelType == casting.FuelType)///?????do we need
                    {
                        if(casting is FuelCar)
                        {
                            FuelCar trycast = casting as FuelCar;
                            trycast.ToRefuelWithFuel(i_AmountToFill);
                        }
                        else if(casting is FuelMotorcycle)
                        {
                            FuelMotorcycle trycast = casting as FuelMotorcycle;
                            trycast.ToRefuelWithFuel(i_AmountToFill);
                        }
                        else
                        {
                            FuelTruck trycast = casting as FuelTruck;
                            trycast.ToRefuelWithFuel(i_AmountToFill);
                        }
                        //FuelCar trycast = casting as FuelCar;
                        //if (trycast != null)
                        //{
                        //    trycast.ToRefuelWithFuel(i_AmountToFill);
                        //    break;
                        //}
                        ///לשלוח לאוביקט הרלוונטי את הדלק שצריך למלא
                        //if(CustomerVehicleCard.CustomerVehicle is 
                        //typeOfVehicle = CustomerVehicleCard.CustomerVehicle.GetType();
                        //if(CustomerVehicleCard.CustomerVehicle.GetType() == this.GetType())
                    }
                    else
                    {
                        //****wrong fuel type****//
                    }
                }  
            }     
        }

        public void ToChargeElectricVehicle(String i_Licensing, float i_MinutesToCharge)
        {
            foreach (KeyValuePair<string, VehicleInGarage> CustomerVehicleCard in m_GarageInventory)
            {
                if (CustomerVehicleCard.Value.CustomerVehicle.Licensing == i_Licensing)
                {
                    ElectricVehicle casting = (CustomerVehicleCard.Value.CustomerVehicle) as ElectricVehicle;
                    if(casting is ElectricCar)
                    {
                        ElectricCar trycast = casting as ElectricCar;
                        trycast.BatteryCharging(i_MinutesToCharge);
                    }
                    else if(casting is ElectricMotorcycle)
                    {
                        ElectricMotorcycle trycast = casting as ElectricMotorcycle;
                        trycast.BatteryCharging(i_MinutesToCharge);
                    }
                }
            }
        }

        public StringBuilder ShowFullData(String i_Licensing)
        {
            StringBuilder vehicleFullData = new StringBuilder();
            string temp = string.Empty;
            foreach(KeyValuePair<string, VehicleInGarage> customerVehicleCard in m_GarageInventory)
            {
               
                if(customerVehicleCard.Key== i_Licensing)
                {
                    Vehicle vehicleInfo = customerVehicleCard.Value.CustomerVehicle;
                    vehicleFullData.Append("The license number is: ").Append(vehicleInfo.Licensing).Append("\n");
                    vehicleFullData.Append("The model of the Vehicle is: ").Append(vehicleInfo.ModelName).Append("\n");
                    vehicleFullData.Append("The status of the vehicle in the garage is: ").Append(customerVehicleCard.Value.Status).Append("\n");
                    foreach (Wheels wheel in customerVehicleCard.Value.CustomerVehicle.WheelCollection)
                    {
                        temp = string.Format("The Manufacturer is: {0} and the air pressure is: {1}\n", wheel.Manufacturer, wheel.CurrentAirPressure);
                        vehicleFullData.Append(temp);
                        temp = string.Empty;

                    }

                    if (vehicleInfo is ElectricVehicle)
                    {
                        vehicleFullData.Append("The battery time remaining in hours: ").Append((vehicleInfo as ElectricVehicle).BatteryTimeRemainingInHours).Append("\n");
                        //ElectricVehicle info = vehicleInfo as ElectricVehicle;
                        if(vehicleInfo is ElectricCar)
                        {
                            vehicleFullData.Append("The amount of doors in electric car: ").Append((vehicleInfo as ElectricCar).CarDoors).Append("\n");
                            vehicleFullData.Append("The color of the electric car: ").Append((vehicleInfo as ElectricCar).CarColor).Append("\n");
                        }
                        else///electric motorcycle
                        {
                            vehicleFullData.Append("The license type is: ").Append((vehicleInfo as ElectricMotorcycle).License).Append("\n");
                            vehicleFullData.Append("The engine volume is: ").Append((vehicleInfo as ElectricMotorcycle).EngineVolume).Append("\n");
                        }
                    }
                    else if (vehicleInfo is FuelVehicle)
                    {
                        vehicleFullData.Append("The current amount of fuel in litters: ").Append((vehicleInfo as FuelVehicle).CurrentAmountOfFuelLiters).Append("\n");
                        if(vehicleInfo is FuelCar)
                        {
                            vehicleFullData.Append("The amount of doors in electric car: ").Append((vehicleInfo as FuelCar).CarDoors).Append("\n");
                            vehicleFullData.Append("The color of the electric car: ").Append((vehicleInfo as FuelCar).CarColor).Append("\n");
                        }
                        else if(vehicleInfo is FuelMotorcycle)
                        {
                            vehicleFullData.Append("The license type is: ").Append((vehicleInfo as FuelMotorcycle).License).Append("\n");
                            vehicleFullData.Append("The engine volume is: ").Append((vehicleInfo as FuelMotorcycle).EngineVolume).Append("\n");
                        }
                        else//truck
                        {
                            vehicleFullData.Append("Does the truck carry dangerous substance? ").Append((vehicleInfo as FuelTruck).DangerousSubstance).Append("\n");
                            vehicleFullData.Append("The maximum carry weight is: ").Append((vehicleInfo as FuelTruck).MaximumCarryWeight).Append("\n");
                        }
                    }
                }
            }
            return vehicleFullData;
        }

        public uint ValidateLicenseNumber(string i_inputLicense)
        {
            uint output=0;
            if (i_inputLicense.Length != 5)
            {
                throw new FormatException("You entered a wrong input.Please try again.");
            }
            else if(i_inputLicense[0] == '0'||!uint.TryParse(i_inputLicense, out output))
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

        public int ValidationUserOption(string userInput)
        {
            int userInputParsed = 0;

            if (!int.TryParse(userInput, out userInputParsed) || (userInputParsed > 7 || userInputParsed < 1))
            {
                throw new FormatException("You entered a wrong input.Please try again.");
            }

            return userInputParsed;
        }

        public  Vehicle CreateVehicle(Enum i_ConcreteVehicleType, List<object> i_ConcreteVehicleParameters, List<object> i_WheelsInformation)
        {
            // זה האינם של הסוגים
            //  eVehicleTypes userChoiceForVehicleType;
            // userChoiceForVehicleType = (eVehicleTypes)Enum.Parse(typeof(RegularVehicle.eTypeOfFuel), i_UserChoice);
            //VehicleInGarage temp = new VehicleInGarage();
            //FuelCar temp = new FuelCar(eAmountOfDoors.Five,eColorOfTheCar.Black, eFuelType.Octan95,0,0);
            //temp.CustomerVehicle = CreateObject.CreateConcretVehicle();
            //temp.CustomerVehicle = new FuelCar(eAmountOfDoors.Three,eColorOfTheCar.Black,eFuelType.Octan95,0,0);
            //(temp.CustomerVehicle as FuelVehicle).
            //(FuelCar)temp.CustomerVehicle = CreateObject.CreateConcretVehicle;
            Vehicle tempConcreteVehicle;
            switch ((eAllVehicleTypes)i_ConcreteVehicleType)
            {

                case eAllVehicleTypes.ElectricCar:
                    tempConcreteVehicle = CreateObject.CreateElectricCar(i_ConcreteVehicleParameters);
                    //tempConcreteVehicle.ModelName = (string)i_ConcreteVehicleParameters[i_ConcreteVehicleParameters.Count-1];
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.FuelCar:
                    tempConcreteVehicle = CreateObject.CreateFuelCar(i_ConcreteVehicleParameters);
                    //tempConcreteVehicle.ModelName = (string)i_ConcreteVehicleParameters[i_ConcreteVehicleParameters.Count - 1];
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.ElectricMotorcycle:
                    tempConcreteVehicle = CreateObject.CreateElectricMotorcycle(i_ConcreteVehicleParameters);
                    //tempConcreteVehicle.ModelName = (string)i_ConcreteVehicleParameters[i_ConcreteVehicleParameters.Count - 1];
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.FuelMotorcycle:
                    tempConcreteVehicle = CreateObject.CreateFuelMotorcycle(i_ConcreteVehicleParameters);
                    //tempConcreteVehicle.ModelName = (string)i_ConcreteVehicleParameters[i_ConcreteVehicleParameters.Count - 1];
                    tempConcreteVehicle.WheelCollection = CreateWheelList(i_WheelsInformation);
                    return tempConcreteVehicle;
                case eAllVehicleTypes.FuelTruck:
                    tempConcreteVehicle = CreateObject.CreateFuelTruck(i_ConcreteVehicleParameters);
                    //tempConcreteVehicle.ModelName = (string)i_ConcreteVehicleParameters[i_ConcreteVehicleParameters.Count - 1];
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
                //wheel.Manufacturer = (string)i_WheelsParameters[0];
                //wheel.CurrentAirPressure = (float)i_WheelsParameters[1];
                //wheel.MaximumAirPressureByManufacturer = (float)i_WheelsParameters[2];
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
                            wheel.Inflation(30f);
                        }
                    }

                    if (valueObject.Value.CustomerVehicle is FuelTruck)
                    {
                        foreach (Wheels wheel in valueObject.Value.CustomerVehicle.WheelCollection)
                        {
                            wheel.Inflation(26f);
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
        // seif 5
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
                        //float maximumAmount = ((valueObject.Value.CustomerVehicle) as FuelCar).MaximumAmountOfFuelLiters;
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
        //seif 6
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
        //seif 7
        public void AllInformation(out string i_GeneralInformation, string i_LicenseId)
        {
            i_GeneralInformation = string.Empty;
            // מספר טלפון, שם בעלים, מצב במוסך, מספר רישוי, דגם, פירוט גלגלים
            //גלגלים- מספר, יצרן, אוויר נוכחי, אוויר מקסימלי
            //מצב דלק + סוג דלק ----- מצב חשמל + סוג חשמל
            //אוטו - דלתות וצבע, אופנוע - נפח מנוע ורישיון, משאית - חומרים מסוכנים ומשקל נשיאה מקסימלי

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
