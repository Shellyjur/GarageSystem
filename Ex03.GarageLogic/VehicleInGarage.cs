using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private Vehicle m_CustomerVehicle;
        private string m_VehicleOwner;
        private string m_OwnerPhone;
        private eVehicleFixingStatus m_Status;

        //public VehicleInGarage()
        //{
        //    m_Status = eVehicleFixingStatus.InRepairing;
        //}
        public VehicleInGarage(string i_VehicleOwner, string i_OwnerPhone)
        {
            m_VehicleOwner = i_VehicleOwner;
            m_OwnerPhone = i_OwnerPhone;
            m_Status = eVehicleFixingStatus.InRepairing;
        }
        public VehicleInGarage(Vehicle i_CustomerVehicle, string i_VehicleOwner,
                    string i_OwnerPhone)
        {
            m_CustomerVehicle = i_CustomerVehicle;
            m_VehicleOwner = i_VehicleOwner;
            m_OwnerPhone = i_OwnerPhone;
            m_Status = eVehicleFixingStatus.InRepairing;
        }

        //properties
        public Vehicle CustomerVehicle
        {
            get
            {
                return m_CustomerVehicle;
            }

            set
            {
                m_CustomerVehicle = value;
            }
        }

        public string CarOwner
        {
            get
            {
                return m_VehicleOwner;
            }

            set
            {
                m_VehicleOwner = value;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }

            set
            {
                m_OwnerPhone = value;
            }
        }

        public eVehicleFixingStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }
    }
}
