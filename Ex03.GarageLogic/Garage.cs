using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        //private List<VehicleInGarage> m_GarageInventory;
        private Dictionary<string, VehicleInGarage> m_GarageInventory;

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
                throw new FormatException();
            }
            else if(i_inputLicense[0] == '0'||!uint.TryParse(i_inputLicense, out output))
            {
                throw new FormatException();
            }
            return output;
        }
        public bool VehicleExists(string i_LicenseNumber)
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
                throw new FormatException();
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
                Wheels wheel = new Wheels();
                wheel.Manufacturer = (string)i_WheelsParameters[0];
                wheel.CurrentAirPressure = (float)i_WheelsParameters[1];
                wheel.MaximumAirPressureByManufacturer = (float)i_WheelsParameters[2];
                wheelsCollection.Add(wheel);
            }

            return wheelsCollection;
        }
        
    }
}
