using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        static Garage m_GarageObj = new Garage();
        public Garage GarageObj
        {
            get
            {
                return m_GarageObj;
            }
        }
        public static void Main()
        {
            EntryPoint();
        }
        public static void EntryPoint()
        {
            PrintOptions();
            UserOption();
        }
        public static void PrintOptions()
        {
            Console.WriteLine("Please choose an option\n");
            Console.WriteLine("(1)---> Insert new vehicle into garage\n");
            Console.WriteLine("(2)---> Show licensing numbers\n");
            Console.WriteLine("(3)---> Change state of vehicle in garage\n");
            Console.WriteLine("(4)---> Inflate vehicle wheels to maximum\n");
            Console.WriteLine("(5)---> Refuel vehicle operated by fuel\n");
            Console.WriteLine("(6)---> Charge vehicle operated by electricity\n");
            Console.WriteLine("(7)---> Show vehicle full data\n");
        }
        public static void UserOption()
        {
            string userInput = String.Empty;
            int userPick;
            bool userOptionFlag = true;

            while (userOptionFlag)
            {
                try
                {
                    userInput = Console.ReadLine();
                    userPick = m_GarageObj.ValidationUserOption(userInput);
                    switch (userPick)
                    {
                        case 1:
                            InsertVehicleValidation();
                            userOptionFlag = DoYouWantToContinue();
                            if (userOptionFlag == true)
                            {
                                PrintOptions();
                            }
                            else
                            {
                                userOptionFlag = false;
                            }

                            break;
                        case 2:

                            FilterStatus();
                            userOptionFlag = DoYouWantToContinue();
                            if (userOptionFlag == true)
                            {
                                PrintOptions();
                            }
                            else
                            {
                                userOptionFlag = false;
                            }
                            break;
                        case 3:
                            ChangeVehicleStatus();
                            userOptionFlag = DoYouWantToContinue();
                            if (userOptionFlag == true)
                            {
                                PrintOptions();
                            }
                            else
                            {
                                userOptionFlag = false;
                            }
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;

                    }

                }
                catch (FormatException fex)
                {
                    Console.WriteLine("You entered a wrong input\n");
                    EntryPoint();
                }
            }
        }

        public static bool DoYouWantToContinue()
        {
            bool toContinue = false;
            string input = string.Empty;

            Console.WriteLine("Do you want to return to the main menu for more options ? \n1 -> yes OR 2 -> No\n ");
            input = Console.ReadLine();
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Wrong choice. Enter again");
                input = Console.ReadLine();
            }

            if (input == "1")
            {
                toContinue = true;
            }

            return toContinue;
        }

        public static void InsertVehicleValidation()
        {
            bool flag = false;
            //uint licenseNumber;
            string licenseInput = string.Empty;
            bool vehicleExists = false;
            string toContinue = string.Empty;


            while (!flag)
            {
                try
                {
                    Console.WriteLine("Please enter license number (5 digits)");
                    licenseInput = Console.ReadLine();
                    m_GarageObj.ValidateLicenseNumber(licenseInput);
                    vehicleExists = m_GarageObj.VehicleExists(licenseInput);
                    if (vehicleExists == true)
                    {
                        Console.WriteLine("The vehicle exists in the System. The status was updated.\n");
                        Console.WriteLine("Do you want to continue to other options ?\npress 1 for YES or 2 for NO\n");
                        toContinue = Console.ReadLine();
                        if (toContinue == "1")
                        {
                            //להתייחס לעובדה שאם הוא רוצה להמשיך אם אותו רכב. או שלא יזין עוד פעם מספר רישוי
                            EntryPoint();
                        }
                    }
                    else
                    {
                        WhichVehicleInsertToTheGarage(licenseInput);
                    }
                    flag = true;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("You entered an invalid license \n");
                }
            }
        }

        public static void WhichVehicleInsertToTheGarage(string licenseInput)
        {
            string userTypeChoice = string.Empty;
            string userConcreteVehicle = string.Empty;
            string customerName = string.Empty;
            string customerPhoneNumber = string.Empty;
            string vehicleModel = string.Empty;
            List<object> concreteVehicleParameters = new List<object>();
            List<object> wheelsInformation = new List<object>();

            GeneralInformation(out customerName, out customerPhoneNumber, licenseInput, out vehicleModel);
            VehicleInGarage temporaryVehicleInGarage = new VehicleInGarage(customerName, customerPhoneNumber);
            Console.WriteLine("Which type of vehicle you want to insert to the garage ?\n");
            Console.WriteLine("(1) electric vehicle\n(2) fuel vehicle");
            userTypeChoice = Console.ReadLine();
            while (userTypeChoice != "1" && userTypeChoice != "2")
            {
                Console.WriteLine("(1) electric vehicle\n(2) fuel vehicle");
                userTypeChoice = Console.ReadLine();
            }

            if (userTypeChoice == "1")
            {
                Console.WriteLine("Select :\n(1) electric car\n(2) electric motorcycle\n");
                userConcreteVehicle = Console.ReadLine();
                while (userConcreteVehicle != "1" && userConcreteVehicle != "2")
                {
                    Console.WriteLine("Select :\n(1) electric car\n(2) electric motorcycle");
                    userConcreteVehicle = Console.ReadLine();
                }

                if (userConcreteVehicle == "1")//electric car
                {
                    Enum amountOfDoors, colorOfCar;
                    float batteryTimeRemainingInHours, maximumBatteryTimeInHours = 3.2f;

                    ////wheels info function///////******
                    ///////create obj of electric car
                    //InformationAboutTheOwner(out customerName, out customerPhoneNumber, licenseInput);
                    InsertWheelsInformation(eAllVehicleTypes.ElectricCar, out wheelsInformation);
                    InformationAboutTheFuelAndElectricCar(out amountOfDoors, out colorOfCar);
                    CreateElectricVehicle(out batteryTimeRemainingInHours, maximumBatteryTimeInHours);
                    concreteVehicleParameters.Add(amountOfDoors);
                    concreteVehicleParameters.Add(colorOfCar);
                    concreteVehicleParameters.Add(batteryTimeRemainingInHours);
                    concreteVehicleParameters.Add(maximumBatteryTimeInHours);
                    concreteVehicleParameters.Add(vehicleModel);
                    concreteVehicleParameters.Add(licenseInput);
                    temporaryVehicleInGarage.CustomerVehicle = m_GarageObj.CreateVehicle(eAllVehicleTypes.ElectricCar, concreteVehicleParameters, wheelsInformation);

                    m_GarageObj.GarageInventory.Add(licenseInput, temporaryVehicleInGarage);
                }
                else
                {
                    ///////create obj of electric motorcycle
                    Enum licenceType;
                    int engineVolume;
                    float batteryTimeRemainingInHours, maximumBatteryTimeInHours = 1.8f;

                    InsertWheelsInformation(eAllVehicleTypes.ElectricMotorcycle, out wheelsInformation);
                    InformationAboutTheFuelAndElectricMotorcycle(out licenceType, out engineVolume);
                    CreateElectricVehicle(out batteryTimeRemainingInHours, maximumBatteryTimeInHours);
                    concreteVehicleParameters.Add(licenceType);
                    concreteVehicleParameters.Add(engineVolume);
                    concreteVehicleParameters.Add(batteryTimeRemainingInHours);
                    concreteVehicleParameters.Add(maximumBatteryTimeInHours);
                    concreteVehicleParameters.Add(vehicleModel);
                    concreteVehicleParameters.Add(licenseInput);
                    temporaryVehicleInGarage.CustomerVehicle = m_GarageObj.CreateVehicle(eAllVehicleTypes.ElectricMotorcycle, concreteVehicleParameters, wheelsInformation);
                    m_GarageObj.GarageInventory.Add(licenseInput, temporaryVehicleInGarage);
                }
            }

            if (userTypeChoice == "2")
            {
                Console.WriteLine("Select :\n(3) fuel car\n(4) fuel motorcycle\n(5) fuel truck");
                userConcreteVehicle = Console.ReadLine();
                while (userConcreteVehicle != "3" && userConcreteVehicle != "4" && userConcreteVehicle != "5")
                {
                    Console.WriteLine("Select :\n(3) fuel car\n(4) fuel motorcycle\n(5) fuel truck");
                    userConcreteVehicle = Console.ReadLine();
                }

                if (userConcreteVehicle == "3")//fuel car
                {
                    ///////create obj of fuel car
                    Enum amountOfDoors, colorOfCar;
                    float currentFuelAmount, maxFuelAmount;

                    maxFuelAmount = 45f;
                    InsertWheelsInformation(eAllVehicleTypes.FuelCar, out wheelsInformation);
                    InformationAboutTheFuelAndElectricCar(out amountOfDoors, out colorOfCar);
                    CreateFuelVehicle(out currentFuelAmount, maxFuelAmount);
                    concreteVehicleParameters.Add(amountOfDoors);
                    concreteVehicleParameters.Add(colorOfCar);
                    concreteVehicleParameters.Add(eFuelType.Octan95);
                    concreteVehicleParameters.Add(currentFuelAmount);
                    concreteVehicleParameters.Add(maxFuelAmount);
                    concreteVehicleParameters.Add(vehicleModel);
                    concreteVehicleParameters.Add(licenseInput);
                    temporaryVehicleInGarage.CustomerVehicle = m_GarageObj.CreateVehicle(eAllVehicleTypes.FuelCar, concreteVehicleParameters, wheelsInformation);
                    m_GarageObj.GarageInventory.Add(licenseInput, temporaryVehicleInGarage);

                }
                else if (userConcreteVehicle == "4")
                {
                    ///////create obj of fuel motorcycle
                    Enum licenceType;
                    //eLicenseType nullLicneseType = eLicenseType.Null;
                    //eFuelType nullFuelType = eFuelType.Null;
                    int engineVolume;
                    float currentFuelAmount;
                    float maxFuelAmount = 6f;

                    InsertWheelsInformation(eAllVehicleTypes.FuelMotorcycle, out wheelsInformation);
                    InformationAboutTheFuelAndElectricMotorcycle(out licenceType, out engineVolume);
                    CreateFuelVehicle(out currentFuelAmount, maxFuelAmount);
                    concreteVehicleParameters.Add(licenceType);
                    concreteVehicleParameters.Add(engineVolume);
                    concreteVehicleParameters.Add(eFuelType.Octan98);
                    concreteVehicleParameters.Add(currentFuelAmount);
                    concreteVehicleParameters.Add(maxFuelAmount);
                    concreteVehicleParameters.Add(vehicleModel);
                    concreteVehicleParameters.Add(licenseInput);
                    temporaryVehicleInGarage.CustomerVehicle = m_GarageObj.CreateVehicle(eAllVehicleTypes.FuelMotorcycle, concreteVehicleParameters, wheelsInformation);
                    m_GarageObj.GarageInventory.Add(licenseInput, temporaryVehicleInGarage);

                }
                else// 5
                {
                    //////create obj of fuel truck
                    bool dangerousSubstance;
                    float maximumCarryWeight, currentFuelAmount, maxFuelAmount;


                    maxFuelAmount = 120f;
                    InsertWheelsInformation(eAllVehicleTypes.FuelTruck, out wheelsInformation);
                    InformationAboutTheFuelTruck(out dangerousSubstance, out maximumCarryWeight);
                    CreateFuelVehicle(out currentFuelAmount, maxFuelAmount);
                    concreteVehicleParameters.Add(dangerousSubstance);
                    concreteVehicleParameters.Add(maximumCarryWeight);
                    concreteVehicleParameters.Add(eFuelType.Soler);
                    concreteVehicleParameters.Add(currentFuelAmount);
                    concreteVehicleParameters.Add(maxFuelAmount);
                    concreteVehicleParameters.Add(vehicleModel);
                    concreteVehicleParameters.Add(licenseInput);
                    temporaryVehicleInGarage.CustomerVehicle = m_GarageObj.CreateVehicle(eAllVehicleTypes.FuelTruck, concreteVehicleParameters, wheelsInformation);
                    m_GarageObj.GarageInventory.Add(licenseInput, temporaryVehicleInGarage);
                }
            }

        }

        public static List<object> InsertWheelsInformation(eAllVehicleTypes i_VehicleType, out List<object> i_WheelCollection)
        {
            string manufacturerName = string.Empty;
            i_WheelCollection = null;
            //float currentAirPressure = 0;

            Console.WriteLine("What is your manufacturer wheels name ? (up to 10 characters)");
            manufacturerName = Console.ReadLine();
            while (manufacturerName.Length > 10)
            {
                Console.WriteLine("You entered a wrong input");
                Console.WriteLine("What is your manufacturer wheels name ? (up to 10 characters)");
                manufacturerName = Console.ReadLine();
            }

            switch (i_VehicleType)
            {
                case eAllVehicleTypes.ElectricCar:
                //WheelsInformation(4, manufacturerName, out i_WheelCollection, 32f);
                //return i_WheelCollection;
                case eAllVehicleTypes.FuelCar:
                    WheelsInformation(4, manufacturerName, out i_WheelCollection, 32f);
                    return i_WheelCollection;
                case eAllVehicleTypes.ElectricMotorcycle:
                case eAllVehicleTypes.FuelMotorcycle:
                    WheelsInformation(2, manufacturerName, out i_WheelCollection, 30f);
                    return i_WheelCollection;
                case eAllVehicleTypes.FuelTruck:
                    WheelsInformation(16, manufacturerName, out i_WheelCollection, 26f);
                    return i_WheelCollection;
                default:
                    return i_WheelCollection;



            }



        }

        public static void GeneralInformation(out string o_CustomerName, out string o_CustomerPhoneNumber, string i_LicenseInput, out string o_VehicleModel)
        {
            o_CustomerName = string.Empty;
            o_CustomerPhoneNumber = string.Empty;
            o_VehicleModel = string.Empty;
            //NAME
            Console.WriteLine("What is your first and last name ? (up to 20 letters)");// just letters and length 20
            o_CustomerName = Console.ReadLine();

            while (!ValidateCustomerName(o_CustomerName))//while name isnt correct
            {
                Console.WriteLine("What is your name ? Please write correctly ! (up to 20 letters)");
                o_CustomerName = Console.ReadLine();
            }

            //PHONE NUMBER
            Console.WriteLine("What is your phone number ? Please write only digits (exactly 6 numbers)");// length 6 
            o_CustomerPhoneNumber = Console.ReadLine();

            while (!ValidateCustomerPhoneNumber(o_CustomerPhoneNumber))
            {
                Console.WriteLine("What is your phone number ? Please write correctly (exactly 6 numbers)");// length 6 
                o_CustomerPhoneNumber = Console.ReadLine();
            }

            //MODEL NAME
            Console.WriteLine("What is your vehicle's model up to 10 characters");
            o_VehicleModel = Console.ReadLine();
            while (o_VehicleModel.Length > 10)
            {
                Console.WriteLine("Wrong input! enter again\n");
                Console.WriteLine("What is your vehicle's model up to 10 characters");
                o_VehicleModel = Console.ReadLine();
            }

        }

        public static bool ValidateCustomerName(string i_CustomerName)
        {
            bool checkingName = true;

            if (i_CustomerName.Length > 21)
            {
                checkingName = false;
            }
            else
            {
                foreach (Char letter in i_CustomerName)
                {
                    if (letter != ' ' && !(Char.IsLetter(letter)))
                    {
                        checkingName = false;
                    }
                }
            }

            return checkingName;
        }

        public static bool ValidateCustomerPhoneNumber(string i_CustomerPhoneNumber)
        {
            bool checkingPhoneNumber = true;

            if (i_CustomerPhoneNumber.Length != 6)
            {
                checkingPhoneNumber = false;
            }
            else
            {
                foreach (Char digit in i_CustomerPhoneNumber)
                {
                    if (!(Char.IsDigit(digit)))
                    {
                        checkingPhoneNumber = false;
                    }
                }
            }

            return checkingPhoneNumber;

        }

        public static void InformationAboutTheFuelAndElectricMotorcycle(out Enum o_LicenseType, out int o_EngineVolume)
        {
            bool engineInputFlag = false;
            string engineInput = string.Empty;
            string licenseInput = string.Empty;
            o_EngineVolume = 0;

            while (!engineInputFlag)
            {
                Console.WriteLine("What is your engine volume \n");
                engineInput = Console.ReadLine();
                try
                {
                    if (!int.TryParse(engineInput, out o_EngineVolume))
                    {
                        throw new FormatException();
                    }
                    engineInputFlag = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You entered an invalid input. Please try again.");
                }
            }

            Console.WriteLine("Enter licence type: A, B1, AA, BB (with UPPER CASE letters)\n");
            licenseInput = Console.ReadLine();
            while (licenseInput != "A" && licenseInput != "B1" && licenseInput != "BB" && licenseInput != "BB")
            {
                Console.WriteLine("Wrong input. Enter licence type: A, B1, AA, BB (with UPPER CASE)\n");
                licenseInput = Console.ReadLine();
            }

            o_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), licenseInput);
        }

        public static void InformationAboutTheFuelAndElectricCar(out Enum o_AmountOfDoors, out Enum o_ColorOfCar)//color and doors
        {
            string color = string.Empty;
            string doors = string.Empty;
            string updatedColor = string.Empty;

            //COLOR
            Console.WriteLine("What is the color of the car ?\nred/ silver/ white, black");
            color = Console.ReadLine();
            while (color != "red" && color != "silver" && color != "white" && color != "black")
            {
                Console.WriteLine("Please enter a correct color !\nred/ silver/ white, black");
                color = Console.ReadLine();
            }

            updatedColor += char.ToUpper(color[0]);
            for (int i = 1; i < color.Length; i++)
            {
                updatedColor += color[i];
            }

            // userChoiceForVehicleType = (eVehicleTypes)Enum.Parse(typeof(RegularVehicle.eTypeOfFuel), i_UserChoice);
            o_ColorOfCar = (eColorOfTheCar)Enum.Parse(typeof(eColorOfTheCar), updatedColor);
            //DOORS
            Console.WriteLine("How many doors the car has ? 2/ 3/ 4/ 5");
            doors = Console.ReadLine();
            while (doors != "2" && doors != "3" && doors != "4" && doors != "5")
            {
                Console.WriteLine("Please enter a correct amount of doors ! 2/ 3/ 4/ 5");
                doors = Console.ReadLine();
            }

            o_AmountOfDoors = (eAmountOfDoors)Enum.Parse(typeof(eAmountOfDoors), doors);
            //CreateFuelCar(color, doors, i_CustomerName, i_CustomerPhoneNumber, i_LicenseInput);

        }

        public static void CreateElectricVehicle(out float o_BatteryTimeRemainingInHours, float i_MaximumBatteryTimeInHours)
        {
            string timeRemaining = string.Empty;
            bool timeRemainingFlag = false;

            o_BatteryTimeRemainingInHours = 0;
            while (!timeRemainingFlag)
            {
                try
                {
                    if (i_MaximumBatteryTimeInHours == 3.2f)
                    {
                        Console.WriteLine("How much battry time remaining in hours (0-3.2) ?");
                    }

                    if (i_MaximumBatteryTimeInHours == 1.8f)
                    {
                        Console.WriteLine("How much battry time remaining in hours (0-1.8) ?");
                    }

                    timeRemaining = Console.ReadLine();
                    if (!float.TryParse(timeRemaining, out o_BatteryTimeRemainingInHours))
                    {
                        throw new FormatException();
                    }

                    if (o_BatteryTimeRemainingInHours > i_MaximumBatteryTimeInHours)
                    {
                        throw new ValueOutOfRangeException(0, i_MaximumBatteryTimeInHours);
                    }

                    timeRemainingFlag = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You entered an invalid input. Please try again.");
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine("You entered amount out of range. Please try again.");
                }
            }
        }


        public static void CreateFuelVehicle(out float o_CurrentFuelAmount, float i_MaxFuelAmount)
        {
            string typeOfFuel = string.Empty;
            string maxFuel = string.Empty;
            string currentFuel = string.Empty;
            bool fuelTypeFlag = false;
            bool maxFuelFlag = false;
            bool currentFuelFlag = false;
            //o_MaxFuelAmount = 45;
            o_CurrentFuelAmount = 0;

            ////FUEL TYPE
            //Console.WriteLine("Please enter the fuel type : Soler/ Octan95/ Octan96/ Octan98");
            //typeOfFuel = Console.ReadLine();
            //while (!fuelTypeFlag)
            //{
            //    if (typeOfFuel != "Soler" && typeOfFuel != "Octan95" && typeOfFuel != "Octan96" && typeOfFuel != "Octan98")
            //    {
            //        Console.WriteLine("Please enter the  CORRECT fuel type : Soler/ Octan95/ Octan96/ Octan98");
            //        typeOfFuel = Console.ReadLine();
            //    }
            //    else
            //    {
            //        fuelTypeFlag = true;
            //    }
            //}

            //o_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), typeOfFuel);
            ////MAX FUEL
            //while (!maxFuelFlag)
            //{
            //    try
            //    {
            //        Console.WriteLine("Please enter the max amount of fuel in liters");
            //        maxFuel = Console.ReadLine();
            //        if (!float.TryParse(maxFuel, out o_MaxFuelAmount))
            //        {
            //            throw new FormatException();
            //        }

            //        if (o_MaxFuelAmount < 0f)
            //        {
            //            throw new ValueOutOfRangeException(0, 45f);
            //        }
            //        maxFuelFlag = true;
            //    }
            //    catch (FormatException ex)
            //    {
            //        Console.WriteLine("You entered an invalid amount. Please try again.");
            //    }
            //    catch (ValueOutOfRangeException voore)
            //    {
            //        Console.WriteLine("You entered amount out of range. Please try again.");
            //    }
            //}

            //CURRENT FUEL
            while (!currentFuelFlag)
            {
                try
                {
                    if (i_MaxFuelAmount == 6f)
                    {
                        Console.WriteLine("Please enter the current amount of fuel in the motorcycle (0-6)");
                    }

                    if (i_MaxFuelAmount == 45f)
                    {
                        Console.WriteLine("Please enter the current amount of fuel in the car (0-45)");
                    }

                    if (i_MaxFuelAmount == 120f)
                    {
                        Console.WriteLine("Please enter the current amount of fuel in the car (0-120)");
                    }

                    currentFuel = Console.ReadLine();
                    if (!float.TryParse(currentFuel, out o_CurrentFuelAmount))
                    {
                        throw new FormatException();
                    }

                    if (o_CurrentFuelAmount < 0 || o_CurrentFuelAmount > i_MaxFuelAmount)
                    {
                        throw new ValueOutOfRangeException(0, i_MaxFuelAmount);
                    }

                    currentFuelFlag = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You entered a wrong input. Please try again.");
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine("You entered a unreasonable value. Please try again.");
                }
            }
        }

        public static void InformationAboutTheFuelTruck(out bool o_DangerousSubstance, out float o_MaximumCarryWeight)
        {
            string dangerousSubstanceInput = string.Empty;
            bool maximumCarryWeightFlag = false;
            string maximumCarryInput = string.Empty;

            o_DangerousSubstance = false;
            o_MaximumCarryWeight = 0;
            Console.WriteLine("Does the truck carry dangerous substance: yes OR no (only lower case letters)\n");
            dangerousSubstanceInput = Console.ReadLine();
            while (dangerousSubstanceInput != "yes" && dangerousSubstanceInput != "no")
            {
                Console.WriteLine("you entered a wrong choice. Does the truck carry dangerous substance: yes OR no\n");
                dangerousSubstanceInput = Console.ReadLine();
            }

            if (dangerousSubstanceInput == "yes")
            {
                o_DangerousSubstance = true;
            }

            while (!maximumCarryWeightFlag)
            {
                try
                {
                    Console.WriteLine("What is the maximum carry weight ? \n");
                    maximumCarryInput = Console.ReadLine();
                    if (!float.TryParse(maximumCarryInput, out o_MaximumCarryWeight))
                    {
                        throw new FormatException();
                    }

                    maximumCarryWeightFlag = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You entered a wrong input. Please try again.");
                }
            }
        }

        public static void WheelsInformation(int i_NumberOfWheels, string i_ManufacturerName, out List<object> i_WheelCollection, float i_MaxAirPressure)
        {
            float currentAirPressureUpdate = 0;
            string currentAirPressure = string.Empty;
            bool currentAirFlag = false;

            i_ManufacturerName = string.Empty;
            i_WheelCollection = new List<object>();
            while (!currentAirFlag)
            {
                Console.WriteLine("What is your wheel current air pressure (0, " + i_MaxAirPressure + ") ?");
                currentAirPressure = Console.ReadLine();
                try
                {
                    if (!float.TryParse(currentAirPressure, out currentAirPressureUpdate))
                    {
                        throw new FormatException();
                    }

                    if (currentAirPressureUpdate < 0f || currentAirPressureUpdate > i_MaxAirPressure)
                    {
                        throw new ValueOutOfRangeException(0, i_MaxAirPressure);
                    }
                    currentAirFlag = true;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("You entered an invalid license \n");

                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine("You entered amount out of range. Please try again.");
                }
            }

            i_WheelCollection.Add(i_ManufacturerName);
            i_WheelCollection.Add(currentAirPressureUpdate);
            i_WheelCollection.Add(i_MaxAirPressure);
            i_WheelCollection.Add(i_NumberOfWheels);
        }

        //// SEIF 2
        public static void FilterStatus()
        {
            string withFilter = string.Empty;

            Console.WriteLine("Do you want to see the data filtered by specific status or not. press:\n1 -> yes\n2-> no");
            withFilter = Console.ReadLine();
            while (withFilter != "1" && withFilter != "2")
            {
                Console.WriteLine("Wrong input try again");
                Console.WriteLine("Do you want to see the data filtered by specific status or not. press:\n1 -> yes\n2-> no");
                withFilter = Console.ReadLine();
            }
            ShowVehiclesLicensingNumbers(withFilter);
        }
        public static void ShowVehiclesLicensingNumbers(string i_WithFilter)
        {
            string statusChoice = string.Empty;

            if (i_WithFilter == "1")
            {
                eVehicleFixingStatus vehicleStatus;

                Console.WriteLine("Which status you want to filter by: \n(1) -> Fixed\n(2) -> InRepairing\n(3) -> Paid");
                statusChoice = Console.ReadLine();
                while (statusChoice != "1" && statusChoice != "2" && statusChoice != "3")
                {
                    Console.WriteLine("You enterd wrong input. Please try again");
                    Console.WriteLine("Which status you want to filter by: \n(1) -> Fixed\n(2) -> InRepairing\n(3) -> Paid");
                    statusChoice = Console.ReadLine();
                }

                vehicleStatus = (eVehicleFixingStatus)Enum.Parse(typeof(eVehicleFixingStatus), statusChoice);
                Console.WriteLine("The licenses that match the chosen status: " + vehicleStatus + " are:");
                foreach (KeyValuePair<string, VehicleInGarage> valueObject in m_GarageObj.GarageInventory)
                {
                    if (valueObject.Value.Status == vehicleStatus)
                    {
                        Console.WriteLine(valueObject.Key);
                    }
                }
            }
            else
            {
                Console.WriteLine("The licenses are:");
                foreach (KeyValuePair<string, VehicleInGarage> valueObject in m_GarageObj.GarageInventory)
                {
                    Console.WriteLine(valueObject.Key + " - " + valueObject.Value.Status);
                }
            }
        }
        public static void ChangeVehicleStatus()
        {
            string licenseId = string.Empty;

            Console.WriteLine("Please enter the vehicle license which you want to change status");
            licenseId = Console.ReadLine();
            if (m_GarageObj.VehicleExists(licenseId))
            {
                string userChoice = string.Empty;

                Console.WriteLine("To which status you would like to change:\n(1)Fixed\n(2)InRepairing\n(3)Paid");
                userChoice = Console.ReadLine();
                while (userChoice != "1" && userChoice != "2" && userChoice != "3")
                {
                    Console.WriteLine("Wrong choice");
                    Console.WriteLine("To which status you would like to change:\n(1)Fixed\n(2)InRepairing\n(3)Paid");
                    userChoice = Console.ReadLine();
                }
                foreach (KeyValuePair<string, VehicleInGarage> valueObject in m_GarageObj.GarageInventory)
                {
                    if (valueObject.Key == licenseId)
                    {
                        if (valueObject.Value.Status == (eVehicleFixingStatus)Enum.Parse(typeof(eVehicleFixingStatus), userChoice))
                        {
                            Console.WriteLine("This status is already exsist for this vehicle");
                        }
                        else
                        {
                            valueObject.Value.Status = (eVehicleFixingStatus)Enum.Parse(typeof(eVehicleFixingStatus), userChoice);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("This license does not exsist in the system hence we can't change the status");
            }
        }
    }
}
