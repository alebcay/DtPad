using System;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using DtPad.Utils;

namespace DtPad.Customs
{
    /// <summary>
    /// Custom PrintDocument (to maintain printer page format).
    /// </summary>
    /// <author>External source</author>
    public class CustomPrintDocument : PrintDocument
    {
        const Int32 Eos = -1;
        private const Int32 NewLine = -2;
        String _text = String.Empty;
        Font _font;
        Int32 _offset;
        Int32 _pageno;

        #region Public Instance Fields

        public String Text
        {
            //get { return _text; }
            set { _text = value; }
        }

        public Font Font
        {
            //get { return _font; }
            set { _font = value; }
        }

        #endregion Internal Instance Fields

        #region Protected Methods

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            _offset = 0;
            _pageno = 1;

            base.OnBeginPrint(e);
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            Single pagewidth = e.MarginBounds.Width * 3.0f;
            Single pageheight = e.MarginBounds.Height * 3.0f;

            Single textwidth = 0.0f;
            Single textheight = 0.0f;

            Single offsetx = e.MarginBounds.Left * 3.0f;
            Single offsety = e.MarginBounds.Top * 3.0f;

            Single x = offsetx;
            Single y = offsety;

            StringBuilder line = new StringBuilder(256);
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
            sf.SetTabStops(0.0f, new[] { 300.0f });

            RectangleF r;

            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Document;

            SizeF size = g.MeasureString("X", _font, 1, sf);
            Single lineheight = size.Height;

            //Make sure we can print at least 1 line (font too big?)
            if (lineheight + (lineheight * 3) > pageheight)
            {
                //Cannot print at least 1 line and footer
                g.Dispose();
                e.HasMorePages = false;

                return;
            }

            //Don't include footer
            pageheight -= lineheight * 3;

            //Last whitespace in line buffer
            Int32 lastws = -1;

            //Next character
            Int32 c;

            for ( ; ; )
            {
                //Get next character
                c = NextChar();

                //Append c to line if not NewLine or Eos
                if ((c != NewLine) && (c != Eos))
                {
                    Char ch = Convert.ToChar(c);
                    line.Append(ch);

                    //If ch is whitespace, remember pos and continue
                    if (ch == ' ' || ch == '\t')
                    {
                        lastws = line.Length - 1;
                        continue;
                    }
                }

                //Measure string if line is not empty
                if (line.Length > 0)
                {
                    size = g.MeasureString(line.ToString(), _font, Int32.MaxValue, StringFormat.GenericTypographic);
                    textwidth = size.Width;
                }

                //Draw line if line is full, if NewLine or if last line
                if (c == Eos || (textwidth > pagewidth) || (c == NewLine))
                {
                    if (textwidth > pagewidth)
                    {
                        if (lastws != -1)
                        {
                            _offset -= line.Length - lastws - 1;
                            line.Length = lastws + 1;
                        }
                        else
                        {
                            line.Length--;
                            _offset--;
                        }
                    }

                    //There's something to draw
                    if (line.Length > 0)
                    {
                        r = new RectangleF(x, y, pagewidth, lineheight);
                        sf.Alignment = StringAlignment.Near;
                        g.DrawString(line.ToString(), _font, Brushes.Black, r, sf);
                    }

                    //Increase ypos
                    y += lineheight;
                    textheight += lineheight;

                    //Empty line buffer
                    line.Length = 0;
                    textwidth = 0.0f;
                    lastws = -1;
                }

                //If next line doesn't fit on page anymore, exit loop
                if (textheight > (pageheight - lineheight))
                {
                    break;
                }

                if (c == Eos)
                {
                    break;
                }
            }

            //Print footer
            x = offsetx;
            y = offsety + pageheight + (lineheight * 2);
            r = new RectangleF(x, y, pagewidth, lineheight);
            sf.Alignment = StringAlignment.Center;
            g.DrawString(_pageno.ToString(), _font, Brushes.Black, r, sf);

            g.Dispose();

            _pageno++;

            e.HasMorePages = (c != Eos);
        }

        #endregion Protected Methods

        #region Private Methods

        private Boolean NextCharIsNewLine()
        {
            Int32 nl = ConstantUtil.newLine.Length;
            Int32 tl = _text.Length - _offset;

            if (tl < nl)
            {
                return false;
            }

            for (Int32 i = 0; i < nl; i++)
            {
                if (_text[_offset + i] != ConstantUtil.newLine[i])
                    return false;
            }

            return true;
        }

        private Int32 NextChar()
        {
            if (_offset >= _text.Length)
            {
                return -1;
            }

            if (NextCharIsNewLine())
            {
                _offset += ConstantUtil.newLine.Length;
                return -2;
            }

            return _text[_offset++];
        }

        #endregion Private Methods
    }
}
