using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Counter counter;

        public Form1()
        {
            InitializeComponent();

            counter = new Counter(0, 5);
            Counter_label.Text = counter.GetInDigitalFormat();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                counter = CreateCounterFromUserInputs();

                Counter_label.Text = counter.GetInDigitalFormat();

                CounterTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Counter CreateCounterFromUserInputs()
        {
            Counter created_counter = new Counter(int.Parse(start_value.Text), int.Parse(digits.Text));
            if (!string.IsNullOrEmpty(lower_bound.Text))
            {
                created_counter.LowerBoundValue = int.Parse(lower_bound.Text);
            }

            if (!string.IsNullOrEmpty(upper_bound.Text))
            {
                created_counter.UpperBoundValue = int.Parse(upper_bound.Text);
            }
            return created_counter;
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CounterTimer.Enabled = false;
        }

        private void increment_btn_Click(object sender, EventArgs e)
        {
            if (counter != null)
            {
                counter.Increment();
                Counter_label.Text = counter.GetInDigitalFormat();
            }
        }

        private void decrement_btn_Click(object sender, EventArgs e)
        {
            if (counter != null)
            { 
                counter.Decrement();
                Counter_label.Text = counter.GetInDigitalFormat();
            }
        }

        private void CounterTimer_Tick(object sender, EventArgs e)
        {
            Counter_label.Text = counter.GetInDigitalFormat();
            counter.Increment();
        }
    }
}
