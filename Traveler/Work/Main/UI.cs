using Myra.Graphics2D.UI;

namespace Traveler;

public class UI
{
    //currently only using some Myra 
    public MyraUI MyraUi { get; set; }
    
    public UI(Desktop desktop)
    {
        MyraUi = new MyraUI(desktop);
    }
}