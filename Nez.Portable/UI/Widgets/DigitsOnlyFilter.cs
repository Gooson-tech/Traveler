using System;

namespace Nez.UI
{
    public class DigitsOnlyFilter : TextField.ITextFieldFilter
    {
        public bool AcceptChar(TextField textField, char c)
        {
            return Char.IsDigit(c) || c == '-';
        }
    }
}