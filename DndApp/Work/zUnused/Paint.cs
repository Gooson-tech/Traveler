namespace DndApp;

/*
public class Paint : Entity
{
    //private static List<Vector2> PatchLocations=new List<Vector2>();
    private static string LastPaintedID;
    private string ID;
    private static Texture2D texture2d;
    private static Sprite sprite;
    private static bool Initialized;
    private static List<Paint> Splotches;
    private static SpriteRenderer spriteRender;
    private static Color _color;
    private static Color _lastColor;

    public static Color ThisColor
    {
        get { return _color; }
        set
        {
            _lastColor = _color;
            _color = value;
        }
    }


    //Used by game to see if patch at location are not too close to last/previous locations (for optimization)
    public static bool AllowedRange(Vector2 lstClkLocation, Vector2 clkLocation)
    {
        //check new patch click location with last location
        if (Vector2.Distance(clkLocation, lstClkLocation) <= 10f) return false;
        //if new patch is less than specified distance between any other patch return false
        if (Splotches != null) return Splotches.All(variable => !(Vector2.Distance(variable.Position, clkLocation) < 8f));
        return true;
    }

    public override void OnAddedToScene()
    {
        base.OnAddedToScene();
        Splotches = Core.Scene.EntitiesOfType<Paint>();



        spriteRender = new SpriteRenderer(sprite);

       /*  spriteRender.Material = Material.StencilWrite();
         spriteRender.RenderLayer = 0;
        _mat = new Material
       {
           BlendState = new BlendState
           {
               ColorSourceBlend = Blend.SourceColor,
               ColorDestinationBlend = Blend.InverseSourceColor,
               ColorBlendFunction = BlendFunction.Add,
               AlphaSourceBlend = Blend.One,
               AlphaDestinationBlend = Blend.SourceAlpha,
               AlphaBlendFunction = BlendFunction.Min
           },
       };

        spriteRender.Color = new Color(10, 10, 10, 50);
        spriteRender.Material=_mat;
       #1#


        spriteRender.RenderLayer++;

        var collider = new CircleCollider { IsTrigger = true, Enabled = false };
        AddComponent(spriteRender);
        AddComponent(collider);


    }


    public Paint(string biomeName)
    {

        ID = biomeName;
        
        AddComponent(new IDd(biomeName));

        if (Initialized && ID == LastPaintedID)
        {
            LastPaintedID = ID;
           // lastColor = color;
            return;
        }


      //  texture2d = CreateCircleText(32, color);
        sprite = new Sprite(texture2d);



        Initialized = true;
        LastPaintedID = ID;
      //  lastColor = color;
    }

    private static Texture2D CreateCircleText(int radius, Color color)
    {
        var texture = new Texture2D(Core.GraphicsDevice, radius, radius);
        var colorData = new Color[radius * radius];

        var diam = radius / 2f;
        var diamsq = diam * diam;

        for (var x = 0; x < radius; x++)
        {
            for (var y = 0; y < radius; y++)
            {
                var index = x * radius + y;
                var pos = new Vector2(x - diam, y - diam);

                if (pos.LengthSquared() <= diamsq)
                    colorData[index] = color;
                else
                    colorData[index] = Color.Transparent;
            }
        }

        texture.SetData(colorData);
        return texture;
    }
   
}
*/
/*public class IDd : Component
{
    public string ID;
    public IDd(string name) { ID = name; }
}*/