using System;
using System.Globalization;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad.UserControls
{
    /// <summary>
    /// Calculator user control.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class CalculatorPanel : UserControl
    {
        private readonly CalculationManager calculationManager;

        internal CalculatorPanel()
        {
            InitializeComponent();
            calculationManager = new CalculationManager(this, CultureInfo.CurrentCulture);

            calculationTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");
            calcTextBox.Font = ConfigUtil.GetFontParameter("FontInUse");
        }

        #region Window Methods

        private void CalculatorPanel_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void calculationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void calcTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void nineButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void backspaceButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void sevenButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void eightButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void cancelButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void fourButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void fiveButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void sixButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void starButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void barButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void equalButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void oneButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void twoButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void threeButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void minusButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void zeroButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void signButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void commaButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        private void plusButton_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyPressed(e);
        }

        #endregion Window Methods

        #region Button Methods

        private void clearCalculatorToolStripButton_Click(object sender, EventArgs e)
        {
            calculationTextBox.Text = String.Empty;
        }

        private void thousandSepToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            calculationManager.UseThousandsSeparator = thousandSepToolStripButton.Checked;
        }

        //private void numberButton_Click(object sender, EventArgs e)
        //{
        //    calculationManager.NumberPressed((Button)sender);
        //}

        //private void backspaceButton_Click(object sender, EventArgs e)
        //{
        //    calculationManager.BackspacePressed();
        //}

        //private void cancelButton_Click(object sender, EventArgs e)
        //{
        //    calculationManager.Reset();
        //}

        //private void commaButton_Click(object sender, EventArgs e)
        //{
        //    calculationManager.PreviousButton = commaButton;
        //}

        //private void operationButton_Click(object sender, EventArgs e)
        //{
        //    Form1 form = (Form1)ParentForm;

        //    calculationManager.OperationPressed(form, (Button)sender);
        //}

        //private void equalButton_Click(object sender, EventArgs e)
        //{
        //    Form1 form = (Form1)ParentForm;

        //    calculationManager.EqualPressed(form);
        //}

        //private void signButton_Click(object sender, EventArgs e)
        //{
        //    calculationManager.SignPressed();
        //}

        private void numberButton_MouseClick(object sender, MouseEventArgs e)
        {
            calculationManager.NumberPressed((Button)sender);
            calculationTextBox.Focus();
        }

        private void backspaceButton_MouseClick(object sender, MouseEventArgs e)
        {
            calculationManager.BackspacePressed();
            calculationTextBox.Focus();
        }

        private void cancelButton_MouseClick(object sender, MouseEventArgs e)
        {
            calculationManager.Reset();
            calculationTextBox.Focus();
        }

        private void commaButton_MouseClick(object sender, MouseEventArgs e)
        {
            calculationManager.PreviousButton = commaButton;
            calculationTextBox.Focus();
        }

        private void operationButton_MouseClick(object sender, MouseEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            calculationManager.OperationPressed(form, (Button)sender);
            calculationTextBox.Focus();
        }

        private void equalButton_MouseClick(object sender, MouseEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            calculationManager.EqualPressed(form);
            calculationTextBox.Focus();
        }

        private void signButton_MouseClick(object sender, MouseEventArgs e)
        {
            calculationManager.SignPressed();
            calculationTextBox.Focus();
        }

        #endregion Button Methods

        #region Multilanguage Methods

        internal void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, textMenuStrip.Items);
        }

        #endregion Multilanguage Methods

        #region Private Methods

        private void CheckKeyPressed(KeyEventArgs e)
        {
            Form1 form = (Form1)ParentForm;

            if (e.Control || e.Alt)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    calculationManager.NumberPressed(zeroButton);
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    calculationManager.NumberPressed(oneButton);
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    calculationManager.NumberPressed(twoButton);
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    calculationManager.NumberPressed(threeButton);
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    calculationManager.NumberPressed(fourButton);
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    calculationManager.NumberPressed(fiveButton);
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    calculationManager.NumberPressed(sixButton);
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    calculationManager.NumberPressed(sevenButton);
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    calculationManager.NumberPressed(eightButton);
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    calculationManager.NumberPressed(nineButton);
                    break;

                case Keys.Enter:
                    calculationManager.EqualPressed(form);
                    break;

                case Keys.Add:
                    calculationManager.OperationPressed(form, plusButton);
                    break;
                case Keys.Subtract:
                    calculationManager.OperationPressed(form, minusButton);
                    break;
                case Keys.Multiply:
                    calculationManager.OperationPressed(form, starButton);
                    break;
                case Keys.Divide:
                    calculationManager.OperationPressed(form, barButton);
                    break;

                case Keys.Back:
                    calculationManager.BackspacePressed();
                    break;
                case Keys.Delete:
                    calculationManager.Reset();
                    break;

                case Keys.Decimal:
                    calculationManager.PreviousButton = commaButton;
                    break;
            }
        }

        #endregion Private Methods
    }
}
