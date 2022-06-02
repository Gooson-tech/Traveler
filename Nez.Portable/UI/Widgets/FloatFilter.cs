using System;

namespace Nez.UI
{
    public class FloatFilter : TextField.ITextFieldFilter
    {
        public bool AcceptChar(TextField textField, char c)
        {
            // only allow one .
            if (c == '.')
                return !textField.GetText().Contains(".");

            return Char.IsDigit(c) || c == '-';
        }
    }
}