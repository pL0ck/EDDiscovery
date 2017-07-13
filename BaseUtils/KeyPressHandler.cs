﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseUtils
{
    static public class KeyPressHandler
    {
        public static void TextBox_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char vbBack = '\u0008';

            System.Globalization.NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (sender is TextBoxBase)
            {
                TextBoxBase tempBox = (TextBox)sender;
                if (Char.IsDigit(e.KeyChar))
                {
                    if (tempBox.Text.Length != 0)
                    {
                        if (tempBox.SelectionStart == 0 && (tempBox.Text[0].ToString()) == negativeSign && tempBox.SelectionLength == 0)
                            e.Handled = true;
                    }


                }
                else if (keyInput.Equals(negativeSign))
                {

                    if (tempBox.SelectionStart != 0 || (tempBox.Text.Contains(negativeSign) && !tempBox.SelectedText.Contains(negativeSign)))
                        e.Handled = true;
                }
                else if (keyInput.Equals(decimalSeparator))
                {

                    if (tempBox.Text.Length != 0)
                    {
                        if (tempBox.SelectionStart == 0 && (tempBox.Text[0].ToString()) == negativeSign && !tempBox.SelectedText.Contains(negativeSign) || tempBox.Text.Contains(decimalSeparator) && !tempBox.SelectedText.Contains(decimalSeparator))
                            e.Handled = true;

                    }
                    // Decimal separator is OK
                }
                else if (e.KeyChar == vbBack)
                {

                    // Backspace key is OK
                }
                else
                {

                    // Consume this invalid key and beep.
                    e.Handled = true;
                }
            }
        }


        public static void TextBox_Int_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            const char vbBack = '\u0008';

            System.Globalization.NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();
            if (sender is TextBoxBase)
            {
                TextBoxBase tempBox = (TextBox)sender;
                if (Char.IsDigit(e.KeyChar))
                {
                    if (tempBox.Text.Length != 0)
                    {
                        if (tempBox.SelectionStart == 0 && (tempBox.Text[0].ToString()) == negativeSign && tempBox.SelectionLength == 0)
                            e.Handled = true;
                    }
                }
                else if (keyInput.Equals(negativeSign))
                {
                    // Decimal separator is OK
                    if (tempBox.SelectionStart != 0 || (tempBox.Text.Contains(negativeSign) && !tempBox.SelectedText.Contains(negativeSign)))
                        e.Handled = true;
                }
                else if (e.KeyChar == vbBack)
                {
                    // Backspace key is OK
                }
                else
                {
                    // Consume this invalid key and beep.
                    e.Handled = true;
                }
            }
        }

    }
}
