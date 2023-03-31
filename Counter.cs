using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Counter
    {
        private int value = 1;
        private int digits = 1;
        private int lower_bound_value;
        private int upper_bound_value;
        private bool lower_bound_set = false;
        private bool upper_bound_set = false;

        public int Value 
        {
            get { return value; }
            set { this.value = value; }
        }

        public int LowerBoundValue 
        {
            get { return lower_bound_value; }
            set 
            {
                lower_bound_value = value;
                lower_bound_set = true;
            }
        }

        public int UpperBoundValue
        {
            get { return upper_bound_value; }
            set
            {
                upper_bound_value = value;
                upper_bound_set = true;
            }
        }

        public Counter(int start_value, int digits)
        {
            this.value = start_value;
            this.digits = digits;
        }

        public string GetInDigitalFormat()
        {
            if (value.ToString().Length > digits)
            {
                string to_be_returned = "";

                for (int i = 0; i < digits; i++)
                {
                    to_be_returned += "9";
                }
                if (value > 0)
                {
                    return to_be_returned;
                }
                else
                {
                    return "-" + to_be_returned;
                }
            }
            string leftPadding = "";

            for (int i = 0; i < digits - value.ToString().Length; i++)
            {
                leftPadding += "0";
            }
            return leftPadding + value.ToString();
        }

        public void Decrement()
        {
            if (value - 1 < lower_bound_value && lower_bound_set)
            {
                if (upper_bound_set)
                {
                    value = upper_bound_value;
                }
                else
                {
                    value = int.MaxValue;
                }
            }
            else
            {
                value--;
            }
        }

        public void Increment()
        {
            if (value + 1 > upper_bound_value && upper_bound_set)
            {
                if (lower_bound_set)
                {
                    value = lower_bound_value;
                }
                else
                {
                    value = int.MinValue;
                }
            }
            else
            {
                value++;
            }
        }
    }
}
