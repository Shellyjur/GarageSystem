using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly String m_ModelName;
        private readonly String m_Licensing;
        private float m_PercentageOfEnergyLeft;
        private List<Wheels> m_WheelCollection;

        public Vehicle(string i_ModelName, string i_Licensing, float i_PercentageOfEnergyLeft)
        {
            m_ModelName = i_ModelName;
            m_Licensing = i_Licensing;
            m_PercentageOfEnergyLeft = i_PercentageOfEnergyLeft;//the calculation will come next
            m_WheelCollection = new List<Wheels>();
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string Licensing
        {
            get
            {
                return m_Licensing;
            }
        }

        public float PercentageOfEnergyleft
        {
            get
            {
                return m_PercentageOfEnergyLeft;
            }

            set
            {
                m_PercentageOfEnergyLeft = value;
            }
        }

        public List<Wheels> WheelCollection
        {
            get
            {
                return m_WheelCollection;
            }

            set 
            {
                m_WheelCollection = value;
            }
        }
    }
}
