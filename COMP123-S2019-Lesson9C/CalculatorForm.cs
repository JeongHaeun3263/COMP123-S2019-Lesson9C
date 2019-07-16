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
                int maxSize = (decimalExists) ? 5 : 3;
                
                if (outputString == "0")
                {
                    outputString = tag;
                }
                else
                {
                    if(outputString.Length < maxSize)
                    {
                        outputString += tag;
                    }
                }                
                ResultLabel.Text = outputString;
            }
            else
            {
                switch(tag)
                {
                    case "back":
                        removeLastCaracterFromResultLabel();
                        break;
                    case "done":
                        FinalizeOutput();
                        break;
                    case "clear":
                        ClearNumericKeyboard();
                        break;
                    case "decimal":
                        addDecimalToResultLabel();
                        break;
                }
            }
        }

        /// <summary>
        /// This method adds a decimal point to the resultLabel
        /// </summary>
        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                outputString += ".";
                decimalExists = true;
            }
        }

        /// <summary>
        /// This method finalizes and converts the outputString to a floating point value
        /// </summary>
        private void FinalizeOutput()
        {
            outputValue = float.Parse(outputString);
            outputValue = (float)Math.Round(outputValue, 1);

            if (outputValue < 0.1f)
            {
                outputValue = 0.1f;
            }
            HeightLabel.Text = outputValue.ToString();
            ClearNumericKeyboard();
            NumberButtonTableLayourPanel.Visible = false;
        }
        
        /// <summary>
        /// This method removes the last character from the Result Label
        /// </summary>
        private void removeLastCaracterFromResultLabel()
        {
            var lastChar = outputString.Substring(outputString.Length - 1);
            if (lastChar == ".")
            {
                decimalExists = false;
            }
            outputString = outputString.Remove(outputString.Length - 1);

            if (outputString.Count() == 0)
            {
                outputString = "0";
            }

            ResultLabel.Text = outputString;
        }


        /// <summary>
        /// This method resets the numeric keyboard and related variable
        /// </summary>
        private void ClearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = "0";
            outputValue = 0.0f;
            decimalExists = false;
        }


        /// <summary>
        /// This it the event handler for the form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            ClearNumericKeyboard();
            NumberButtonTableLayourPanel.Visible = false;
        }


        /// <summary>
        /// This is the event handler for the HeighLabel click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeightLabel_Click(object sender, EventArgs e)
        {
            NumberButtonTableLayourPanel.Visible = true;
        }
    }
}
