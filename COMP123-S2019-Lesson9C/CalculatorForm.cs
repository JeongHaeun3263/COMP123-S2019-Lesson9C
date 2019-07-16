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
        // CLASS PROPERTIES
        public string outputString { get; set; }
        public float outputValue  { get; set; }
        public bool decimalExists { get; set; }


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
            Button TheButton = sender as Button;
            var tag = TheButton.Tag.ToString();
            int numericValue = 0;
            
            bool numericResult = int.TryParse(tag, out numericValue);

            if(numericResult)
            {
                if (outputString == "0")
                {
                    outputString = tag;
                }
                else
                {
                    outputString += tag;
                }                
                ResultLabel.Text = outputString;
            }
            else
            {
                switch(tag)
                {
                    case "back":
                        break;
                    case "done":
                        break;
                    case "clear":
                        ResultLabel.Text = "0";
                        outputString = "0";
                        outputValue = 0.0f;
                        decimalExists = false;
                        break;
                    case "decimal":
                        break;
                }
            }
        }
    }
}
