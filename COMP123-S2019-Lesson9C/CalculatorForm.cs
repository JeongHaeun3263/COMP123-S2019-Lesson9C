using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lesson9C
{
    public partial class CalculatorForm : Form
    {
        /// <summary>
        /// This is the contructor for the CalculatorForm
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
        }


   

        /// <summary>
        /// This is a shared event handler for the Calculatorutton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            /* ugly syntax
            var TheButton = (Button)sender;
            */
            var TheButton = sender as Button;

            int ButtonValue;
            bool Result = int.TryParse(TheButton.Text, out ButtonValue);

            if(Result)
            {
                ResultLabel.Text = TheButton.Text;
            }
            else
            {
                ResultLabel.Text = "Not a Number (NAN)";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
