using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DtPad.Customs
{
   /// <summary>
   /// CustomCheckbox - when focused it supports the + key to check the CheckBox and the - key to uncheck the CheckBox
   /// </summary>
   class CustomCheckBox : CheckBox
   {

      /// <summary>
      /// Supports the + key to check the CheckBox and the - key to uncheck the CheckBox
      /// </summary>
      /// <author>Derek Morin</author>
      protected override void OnKeyDown(KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Oemplus)
         {
            Checked = true;
         }
         else if (e.KeyCode == Keys.OemMinus)
         {
            Checked = false;
         }
         base.OnKeyDown(e);
      }


   }
}
