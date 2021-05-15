using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private String m_ModelName;
        private String m_Licensing;
        private float m_PercentageOfEnergyleft;
        //Wheels m_wheels;
        private List<Wheels> m_WheelCollection;
        //private eVehicleFixingStatus m_Status;

        public Vehicle(){ }        
        public Vehicle(string i_ModelName, string i_Licensing, float i_PercentageOfEnergyleft)
        {
            m_ModelName = i_ModelName;
            m_Licensing = i_Licensing;
            m_PercentageOfEnergyleft = 0;//the calculation will come next
            m_WheelCollection = new List<Wheels>();
            //m_Status = i_status;
        }
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }
        public string Licensing
        {
            get
            {
                return m_Licensing;
            }
            set
            {
                m_Licensing = value;
            }
        }
        public float PercentageOfEnergyleft////איך לפצל לילדים שלכל אחד יש מקור אנרגייה אחר חשמל או דלק
        {
            get
            {
                return m_PercentageOfEnergyleft;
            }
            set
            {
                m_PercentageOfEnergyleft = value;
            }
        }

        public List<Wheels> WheelCollection
        {
            get
            {
                return m_WheelCollection;
            }
            set// אוטו - 4 גלגלים 
            {
                m_WheelCollection = value;
            }
         }

        //public eVehicleFixingStatus Status
        //{
        //    get
        //    {
        //        return m_Status;
        //    }

        //    set
        //    {
        //        m_Status = value; 
        //    }
        //}

        public void AddWheelsToList(Wheels wheel)//נגיד שיש אוטו עם 4 גלגלים אז נוסיף את ה 4 גלגלים לליסט של האוטו
        {
            m_WheelCollection.Add(wheel);
        }

        

    }
}
