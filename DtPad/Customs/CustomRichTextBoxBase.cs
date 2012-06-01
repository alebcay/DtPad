using System;
using System.Text;
using System.Windows.Forms;
using DtPad.Managers;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom RichTextBox base (to manage words selection).
    /// </summary>
    /// <author>Marco Macciò</author>
    public class CustomRichTextBoxBase : RichTextBox
    {
        private DateTime lastClickDateTime = new DateTime(2000, 1, 1);
        private int clickCount = 1;
        const int WM_LBUTTONDBLCLK = 0x0203;

        #region Protected Methods

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDBLCLK:
                    //if (TextLength > 250000)
                    //{
                    //    base.WndProc(ref m);
                    //    break;
                    //}

                    int posStart = SelectionStart;
                    StringBuilder textBuilder = new StringBuilder(Text, TextLength);

                    if (posStart > textBuilder.Length - 1 || clickCount > 2)
                    {
                        return;
                    }

                    //It is a special character
                    if (Char.IsWhiteSpace(textBuilder[posStart]) || Char.IsPunctuation(textBuilder[posStart]) ||
                        Char.IsSymbol(textBuilder[posStart]) || Char.IsSeparator(textBuilder[posStart]))
                    {
                        char specialChar = textBuilder[posStart];

                        while (true)
                        {
                            if (posStart == 0 || specialChar != textBuilder[posStart - 1])
                            {
                                break;
                            }

                            posStart--;
                        }

                        int lenght = SelectionStart - posStart; //0;
                        while (specialChar == textBuilder[posStart + lenght])
                        {
                            lenght++;

                            if (posStart + lenght >= textBuilder.Length)
                            {
                                break;
                            }
                        }

                        Select(posStart, lenght);
                    }
                    else //It is a normal character
                    {
                        while (true)
                        {
                            if (posStart == 0 ||
                                (Char.IsWhiteSpace(textBuilder[posStart - 1]) || Char.IsSymbol(textBuilder[posStart - 1]) ||
                                Char.IsPunctuation(textBuilder[posStart - 1]) || Char.IsSeparator(textBuilder[posStart - 1])))
                            {
                                break;
                            }

                            posStart--;
                        }

                        int lenght = SelectionStart - posStart; //0;
                        while (!Char.IsWhiteSpace(textBuilder[posStart + lenght]) && !Char.IsSymbol(textBuilder[posStart + lenght]) &&
                            !Char.IsPunctuation(textBuilder[posStart + lenght]) && !Char.IsSeparator(textBuilder[posStart + lenght]))
                        {
                            lenght++;

                            if (posStart + lenght >= textBuilder.Length)
                            {
                                break;
                            }
                        }

                        Select(posStart, lenght);
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (AutoWordSelection)
            {
                return;
            }

            AutoWordSelection = true;
            AutoWordSelection = false;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Form1 form = (Form1)FindForm();
            if (form == null)
            {
                base.OnMouseClick(e);
                return;
            }

            TimeSpan timeSpan = DateTime.Now - lastClickDateTime;
            lastClickDateTime = DateTime.Now;

            if (timeSpan.TotalMilliseconds <= 300)
            {
                clickCount++;
                if (clickCount == 3)
                {
                    TextManager.SelectCurrentLine(form);
                    return;
                }

                base.OnMouseClick(e);
            }
            else
            {
                clickCount = 1;
                base.OnMouseClick(e);
            }
        }

        #endregion Protected Methods
    }
}
