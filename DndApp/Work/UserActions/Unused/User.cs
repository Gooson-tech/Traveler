using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
namespace DndApp;

public static class KeyboardAndMouseControls
{


    //controls
    public static VirtualIntegerAxis YAxisInput { get; set; }
    public static VirtualIntegerAxis XAxisInput { get; set; }
    public static VirtualButton Ctrl { get; set; }
    public static VirtualButton ChangeCam { get; set; }
    public static VirtualButton LeftMouseClick { get; set; }
    public static VirtualButton RightMouseClick { get; set; }
    public static VirtualButton MiddleMouseClick { get; set; }
    static KeyboardAndMouseControls()
    {
        ChangeCam = new VirtualButton();
        ChangeCam.Nodes.Add(new VirtualButton.KeyboardKey(Keys.X));
       ChangeCam.Nodes.Add(new VirtualButton.GamePadButton(0, Buttons.B));



       //horizontal input from dpad, left stick or keyboard left/right
       XAxisInput = new VirtualIntegerAxis();
       XAxisInput.Nodes.Add(new VirtualAxis.GamePadDpadLeftRight());
       XAxisInput.Nodes.Add(new VirtualAxis.GamePadLeftStickX());
       XAxisInput.Nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer, Keys.Left,
                                                         Keys.Right));

       //vertical input from dpad, left stick or keyboard up/down
       YAxisInput = new VirtualIntegerAxis();
       YAxisInput.Nodes.Add(new VirtualAxis.GamePadDpadUpDown());
       YAxisInput.Nodes.Add(new VirtualAxis.GamePadLeftStickY());
       YAxisInput.Nodes.Add(new VirtualAxis.KeyboardKeys(VirtualInput.OverlapBehavior.TakeNewer,
                                                         Keys.Up,
                                                         Keys.Down));


       //other Keys (not horizontal or vertical movement)
       Ctrl = new VirtualButton();
       Ctrl.Nodes.Add(new VirtualButton.KeyboardKey(Keys.LeftControl));

       //mouse
       LeftMouseClick = new VirtualButton();
       RightMouseClick = new VirtualButton();
       MiddleMouseClick = new VirtualButton();

       LeftMouseClick.Nodes.Add(new VirtualButton.MouseLeftButton());
       RightMouseClick.Nodes.Add(new VirtualButton.MouseRightButton());
       MiddleMouseClick.Nodes.Add(new VirtualButton.MouseRightButton());
    }



}

