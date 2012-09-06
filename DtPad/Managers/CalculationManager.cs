using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using DtPad.Exceptions;
using DtPad.UserControls;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Calculator user control manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class CalculationManager
    {
        private bool useThousandsSeparator = true;
        private Button previousButton;
        private Button previousOperation;
        private decimal previousValue;
        private readonly CultureInfo culture;
        private readonly CalculatorPanel panel;
        private const int defaultLenght = 2;
        private const String className = "CalculationManager";
        private Enum alreadyMadeEqual;

        private enum AlreadyMadeEqual
        {
            [Description("Equal operator has not been executed")]
            No = 0,
            [Description("Equal operator has been executed by operation")]
            MadeByOperator = 1,
            [Description("Equal operator has been executed by equal")]
            MadeByEqual = 2
        }

        internal CalculationManager(CalculatorPanel panel, CultureInfo culture)
        {
            TextBox calcTextBox = panel.calcTextBox;
            
            this.panel = panel;
            this.culture = culture;
            calcTextBox.Text = GetDefaultValue();
        }

        #region Internal Instance Properties

        internal Button PreviousButton
        {
            set { previousButton = value; }
            //get { return previousButton; }
        }

        internal bool UseThousandsSeparator
        {
            set { useThousandsSeparator = value; }
            private get { return useThousandsSeparator; }
        }

        #endregion Internal Instance Properties

        #region Number Methods

        internal void NumberPressed(Button numberButton)
        {
            TextBox calcTextBox = panel.calcTextBox;
            Button commaButton = panel.commaButton;
            Button plusButton = panel.plusButton;
            Button minusButton = panel.minusButton;
            Button starButton = panel.starButton;
            Button barButton = panel.barButton;

            if (previousButton == plusButton || previousButton == minusButton || previousButton == starButton || previousButton == barButton)
            {
                calcTextBox.Text = GetDefaultValue();
            }
            
            if (previousButton == commaButton)
            {
                calcTextBox.Text += numberButton.Text;
            }
            else
            {
                if (calcTextBox.Text == GetDefaultValue())
                {
                    calcTextBox.Text = numberButton.Text + culture.NumberFormat.NumberDecimalSeparator;
                }
                else if (calcTextBox.Text.EndsWith(culture.NumberFormat.NumberDecimalSeparator))
                {
                    calcTextBox.Text = calcTextBox.Text.Substring(0, calcTextBox.Text.Length - 1) + numberButton.Text + culture.NumberFormat.NumberDecimalSeparator;
                }
                else
                {
                    calcTextBox.Text += numberButton.Text;
                }
            }

            previousButton = null;
            alreadyMadeEqual = AlreadyMadeEqual.No;
        }

        #endregion Number Methods

        #region Function Methods

        internal void BackspacePressed()
        {
            TextBox calcTextBox = panel.calcTextBox;

            if (calcTextBox.Text.Length > defaultLenght && calcTextBox.Text != GetDefaultValue())
            {
                if (calcTextBox.Text.EndsWith(culture.NumberFormat.NumberDecimalSeparator))
                {
                    calcTextBox.Text = calcTextBox.Text.Substring(0, calcTextBox.Text.Length - defaultLenght) + culture.NumberFormat.NumberDecimalSeparator;
                }
                else
                {
                    calcTextBox.Text = calcTextBox.Text.Substring(0, calcTextBox.Text.Length - 1);
                }
            }
            else if (calcTextBox.Text.Length == defaultLenght && calcTextBox.Text != GetDefaultValue())
            {
                calcTextBox.Text = GetDefaultValue();
            }
        }

        internal void Reset()
        {
            TextBox calcTextBox = panel.calcTextBox;
            TextBox calculationTextBox = panel.calculationTextBox;

            if (!String.IsNullOrEmpty(calculationTextBox.Text) && !calculationTextBox.Text.EndsWith(ConstantUtil.calculatorSeparator + Environment.NewLine))
            {
                UpdateCalculationTextBox(ConstantUtil.calculatorSeparator);
            }

            calcTextBox.Text = GetDefaultValue();
            previousButton = null;
            previousOperation = null;
            previousValue = 0;
            alreadyMadeEqual = AlreadyMadeEqual.No;
        }

        internal void SignPressed()
        {
            TextBox calcTextBox = panel.calcTextBox;

            if (calcTextBox.Text.StartsWith("-"))
            {
                calcTextBox.Text = calcTextBox.Text.Substring(1);
            }
            else
            {
                calcTextBox.Text = "-" + calcTextBox.Text;
            }
        }

        #endregion Function Methods

        #region Operation Methods

        internal void OperationPressed(Form form, Button operationButton)
        {
            TextBox calcTextBox = panel.calcTextBox;
            Button plusButton = panel.plusButton;
            Button minusButton = panel.minusButton;
            Button starButton = panel.starButton;
            Button barButton = panel.barButton;

            decimal resultValue;
            decimal decimalValue;
            if (!decimal.TryParse(calcTextBox.Text, NumberStyles.AllowDecimalPoint, culture, out decimalValue))
            {
                ManageError(form, "ErrorParsing");
                return;
            }

            if (alreadyMadeEqual.Equals(AlreadyMadeEqual.No))
            {
                if (previousOperation == plusButton)
                {
                    resultValue = previousValue + decimalValue;
                }
                else if (previousOperation == minusButton)
                {
                    resultValue = previousValue - decimalValue;
                }
                else if (previousOperation == starButton)
                {
                    resultValue = previousValue * decimalValue;
                }
                else if (previousOperation == barButton)
                {
                    resultValue = previousValue / decimalValue;
                }
                else
                {
                    resultValue = decimalValue;
                }

                UpdateCalculationTextBox(ThousandSeparation(decimalValue.ToString(culture)) + " " + operationButton.Text);
            }
            else
            {
                resultValue = decimalValue;

                if (alreadyMadeEqual.Equals(AlreadyMadeEqual.MadeByOperator))
                {
                    UpdateCalculationTextBoxOperator(operationButton.Text);
                }
                else if (alreadyMadeEqual.Equals(AlreadyMadeEqual.MadeByEqual))
                {
                    UpdateCalculationTextBox(ThousandSeparation(decimalValue.ToString(culture)) + " " + operationButton.Text);
                }
            }

            alreadyMadeEqual = AlreadyMadeEqual.MadeByOperator;
            previousValue = resultValue;
            previousButton = operationButton;
            previousOperation = operationButton;

            calcTextBox.Text = resultValue.ToString(culture);
            if (!calcTextBox.Text.Contains(culture.NumberFormat.NumberDecimalSeparator))
            {
                calcTextBox.Text += culture.NumberFormat.NumberDecimalSeparator;
            }
        }

        internal void EqualPressed(Form form)
        {
            TextBox calcTextBox = panel.calcTextBox;
            Button plusButton = panel.plusButton;
            Button minusButton = panel.minusButton;
            Button starButton = panel.starButton;
            Button barButton = panel.barButton;
            Button equalButton = panel.equalButton;

            decimal resultValue;
            decimal decimalValue;
            if (!decimal.TryParse(calcTextBox.Text, NumberStyles.AllowDecimalPoint, culture, out decimalValue))
            {
                ManageError(form, "ErrorParsing");
                return;
            }

            if (previousOperation == plusButton)
            {
                if (previousButton == equalButton)
                {
                    resultValue = decimalValue + previousValue;
                }
                else
                {
                    resultValue = previousValue + decimalValue;
                }
            }
            else if (previousOperation == minusButton)
            {
                if (previousButton == equalButton)
                {
                    resultValue = decimalValue - previousValue;
                }
                else
                {
                    resultValue = previousValue - decimalValue;
                }
            }
            else if (previousOperation == starButton)
            {
                if (previousButton == equalButton)
                {
                    resultValue = decimalValue * previousValue;
                }
                else
                {
                    resultValue = previousValue * decimalValue;
                }
            }
            else if (previousOperation == barButton)
            {
                if (previousButton == equalButton)
                {
                    resultValue = decimalValue / previousValue;
                }
                else
                {
                    resultValue = previousValue / decimalValue;
                }
            }
            else
            {
                //ManageError(form, "ErrorNoOperation");
                return;
            }

            if (previousButton != equalButton)
            {
                UpdateCalculationTextBox(ThousandSeparation(decimalValue.ToString(culture)));
                previousValue = decimalValue;
            }

            UpdateCalculationTextBox("= " + ThousandSeparation(resultValue.ToString(culture)));
            calcTextBox.Text = resultValue.ToString(culture);
            if (!calcTextBox.Text.Contains(culture.NumberFormat.NumberDecimalSeparator))
            {
                calcTextBox.Text += culture.NumberFormat.NumberDecimalSeparator;
            }

            previousButton = equalButton;
            alreadyMadeEqual = AlreadyMadeEqual.MadeByEqual;
        }

        #endregion Operation Methods

        #region Private Methods

        private void ManageError(Form form, String errorDescriptionName)
        {
            String error = LanguageUtil.GetCurrentLanguageString(errorDescriptionName, className);
            ParseException exception = new ParseException(error);
            WindowManager.ShowErrorBox(form, LanguageUtil.GetCurrentLanguageString(errorDescriptionName, className), exception);

            Reset();
        }

        private void UpdateCalculationTextBox(String stringToAppend)
        {
            TextBox calculationTextBox = panel.calculationTextBox;
            
            calculationTextBox.Text += stringToAppend + Environment.NewLine;
            calculationTextBox.Select(calculationTextBox.Text.Length, 0);
            calculationTextBox.ScrollToCaret();
        }

        private void UpdateCalculationTextBoxOperator(String stringToAppend)
        {
            TextBox calculationTextBox = panel.calculationTextBox;

            calculationTextBox.Text = calculationTextBox.Text.Substring(0, calculationTextBox.Text.Length - Environment.NewLine.Length - 1);
            UpdateCalculationTextBox(stringToAppend);
        }

        private String GetDefaultValue()
        {
            return ConstantUtil.defaultCalculatorNumber + culture.NumberFormat.NumberDecimalSeparator;
        }

        private String ThousandSeparation(String decimalString)
        {
            if (!UseThousandsSeparator)
            {
                return decimalString;
            }

            int decimalSeparatorIndex = decimalString.LastIndexOf(culture.NumberFormat.NumberDecimalSeparator);

            if (decimalSeparatorIndex == -1)
            {
                decimalSeparatorIndex = decimalString.Length;
            }

            decimalSeparatorIndex--;
            if (decimalSeparatorIndex < 3)
            {
                return decimalString;
            }

            int i = decimalSeparatorIndex + 1;
            do
            {
                i = i - 3;
                decimalString = decimalString.Insert(i, culture.NumberFormat.NumberGroupSeparator);

            } while (i > 3);

            return decimalString;
        }

        #endregion Private Methods
    }
}
