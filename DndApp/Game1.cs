using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Systems;

namespace DndApp;



public class Game1 : Core
{
    private static List<Biome> BiomeList = new List<Biome>();

    private static Entity _eraser;

    // private static void Window_ClientSizeChanged(object sender, System.EventArgs e) => UI.BuildUI();
    private static Vector2 _lstClkLocation = new(0,0);


    public static Myra.Graphics2D.UI.Desktop desktop;

    protected override void Initialize()
    {
        base.Initialize();
        DebugRenderEnabled = true;
        Window.AllowUserResizing = true;
        var mapTexture = Content.LoadTexture(FileLocations.Map);
        SceneSetup(mapTexture);
        UI.BuildUI();
        //UI.BuildUI();
        Screen.SetSize(mapTexture.Width, mapTexture.Height);
        //Window.ClientSizeChanged += Window_ClientSizeChanged;
        Biome Desert = new(name: "Desert", Climate.Desert);
        Biome Tundra= new("Tundra", Climate.Tundra);
        Biome Grassland = new("Grassland", Climate.Grassland);
        BiomeList.Add(Desert);
        BiomeList.Add(Tundra);
        BiomeList.Add(Grassland);
        _eraser = Scene.CreateEntity("Eraser");
        _eraser.AddComponent(new Mouse());

    }

    private static void SceneSetup(Texture2D mapTexture)
    {
        Scene = new Scene();


        var map=Scene.CreateEntity("Map");
        var mapRender=map.AddComponent(new SpriteRenderer(mapTexture));
        mapRender.RenderLayer = 1;

        Scene.SetDesignResolution(mapTexture.Width,
                                  mapTexture.Height,
                                  Scene.SceneResolutionPolicy.NoBorderPixelPerfect);
        SceneCamera.SetUp(Scene.Camera);
        Scene.ClearColor = Color.Black;
        Scene.LetterboxColor = Color.Black;


    }

    protected override void Update(GameTime gametime)
   {
       if (!UI.ONTOP)
       {
           //camera

           SceneCamera.CameraZoom(Input.MouseWheel);


           if (UI.PaintName != null && UI.PaintName != UI.LastUsedPaintName)
           {
               CreateNewBiome(UI.PaintName);
               UI.LastUsedPaintName = UI.PaintName;
           }

           if (UI.PaintMode)
           {
               if (Input.LeftMouseButtonDown) DoPainting();
               else if (Input.RightMouseButtonDown)
               {
                   _eraser.Enabled = true;
                   DoErasing();
               }
               else _eraser.Enabled = false;
           }

       }


       base.Update(gametime);





   }

    public static void DoPainting()
   {
       var clkLocation = Game1.Scene.Camera.MouseToWorldPoint();
       clkLocation.Round();
       if (Paint.AllowedRange(_lstClkLocation, clkLocation)) //optimization
       {
           var splotch = new Paint(UI.PaintName, UI.useColor);
           splotch.SetScale(new Vector2(UI.SplotchSize, UI.SplotchSize));

           _lstClkLocation = clkLocation;
           splotch.SetPosition(Scene.Camera.MouseToWorldPoint());

           Scene.AddEntity(splotch);

       }
   }

    public static void DoErasing()
   {
       var clkLocation = Scene.Camera.MouseToWorldPoint();
       _eraser.SetPosition(clkLocation);
   }

    public static void CreateNewBiome(string PaintName)
   {

       var biome = new Biome(PaintName, Climate.Desert);
       if (BiomeList.AddIfNotPresent(new Biome(UI.PaintName, UI.ClimateType)));
   }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        desktop.Render();
    }
}

