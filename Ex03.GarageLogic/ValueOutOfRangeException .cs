using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float m_MaxValue;
        private readonly float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue):
                   base("The value need to be between the " + i_MinValue + " and " + i_MaxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        //properties
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }
    }
}
