namespace Nez.UI
{
    public class BoolFilter : TextField.ITextFieldFilter
    {
        public bool AcceptChar(TextField textField, char c)
        {
            if (c == 't' || c == 'T')
                textField.SetTextForced("true");

            if (c == 'f' || c == 'F')
                textField.SetTextForced("false");

            return false;
        }
    }
}