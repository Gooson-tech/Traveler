using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
namespace DndApp;

public class Game1 : Core
{
    private static Entity _eraser;

    // private static void Window_ClientSizeChanged(object sender, System.EventArgs e) => UI.BuildUI();
    private static Vector2 _lstClkLocation = new(0, 0);
    public static Myra.Graphics2D.UI.Desktop Desktop;

    private Party _party;
    private static DateTime _date = new (2015,1,1);
    protected override void Initialize()
    {
        base.Initialize();
        DebugRenderEnabled = true;
        //Window.AllowUserResizing = true;
        var mapTexture = Content.LoadTexture(FileLocations.Map);
        SceneSetup(mapTexture);
        UI.BuildUI();
        Screen.SetSize(mapTexture.Width, mapTexture.Height);
        Biome desert = new(name: "Desert", Climates.Desert),
              tundra= new("Tundra", Climates.Tundra),
              grassland = new("Grassland", Climates.Grassland);
        Biome.BiomeList.Add(desert);
        Biome.BiomeList.Add(tundra);
        Biome.BiomeList.Add(grassland);
        _eraser = Scene.CreateEntity("Eraser");
        _eraser.AddComponent(new Mouse());
        ScheduledTasks();
        LoadContent();
    }
    private static void SceneSetup(Texture2D mapTexture)
    {
        Scene = new Scene();
        var map=Scene.CreateEntity("Map");
        var mapRender=map.AddComponent(new SpriteRenderer(mapTexture));
        mapRender.RenderLayer = 1;

        Scene.SetDesignResolution(mapTexture.Width, mapTexture.Height,
            Scene.SceneResolutionPolicy.NoBorderPixelPerfect);
        SceneCamera.SetUp(Scene.Camera);
        Scene.ClearColor = Color.Black;
        Scene.LetterboxColor = Color.Black;
    }
    private void ScheduledTasks()
    {
        Schedule(1, true, GetBiomeInfoForTime);
    }
    protected override void LoadContent()
    {
        base.LoadContent();
        _party = new Party(FileLocations.Party,20);
        _party.SetPosition(new Vector2(0,0));
        Scene.AddEntity(_party);
    }
   

    private DateTime _lastDate = _date;
    private static readonly DateTime StartDate = new(2015,1,1);
    private void GetBiomeInfoForTime(ITimer obj)
    {
        if (!UI.TimeSetChanged && !UI.TimeContinue) return;
        if (UI.TimeContinue)
        {
            _date = _lastDate;
            _date = _date.AddHours(1);
            UI.Hour++;
        }
        else
        {
            UI.TimeSetChanged = false;
            _date = new DateTime((int)(UI.Year + 2014), UI.Month, (int)UI.Day);
            _date = _date.AddHours((int)UI.Hour);
        }
        var today = _date-StartDate;
        var index = today.Hours;
        var todaysResults = Climate.Dec1Data[index];
        UI.InformationBox.Text = "NOW: " + _date + "Weather: " + todaysResults;
        _lastDate=_date;
    }
    
    protected override void Update(GameTime gametime) 
    {
       base.Update(gametime);


       if (Input.LeftMouseButtonDown)
       {
           _party.MoveLocations.Add(Input.ScaledMousePosition);
           if (Vector2.Distance(_party.MoveLocations.Last(),_party.LastRecordedMousePos)>5)  {
               _party.MoveLocations.Add(Input.ScaledMousePosition);
           }
       }
       if (Input.LeftMouseButtonReleased) { _party.AllowMovement = true; }
       
       if (UI.Ontop) return;
       //camera
       SceneCamera.CameraZoom(Input.MouseWheel);

       if (UI.PaintName != UI.LastUsedPaintName && UI.PaintName != null)
       {
           Biome.CreateNewBiome(UI.PaintName, UI.ClimateType);
           UI.LastUsedPaintName = UI.PaintName;
       }
           
       if (!UI.PaintMode) return;
       if (Input.LeftMouseButtonDown) DoPainting();
       else if (Input.RightMouseButtonDown)
       {
           _eraser.Enabled = true;
           DoErasing();
       }
       else _eraser.Enabled = false;
   }
    
    private static void DoPainting() 
    {
       var clkLocation = Game1.Scene.Camera.MouseToWorldPoint();
       clkLocation.Round();
       if (!Paint.AllowedRange(_lstClkLocation, clkLocation)) return;
       var splotch = new Paint(UI.PaintName, UI.UseColor);
       splotch.SetScale(new Vector2(UI.SplotchSize, UI.SplotchSize));

       _lstClkLocation = clkLocation;
       splotch.SetPosition(Scene.Camera.MouseToWorldPoint());

       Scene.AddEntity(splotch);
    }
    private static void DoErasing() 
    {
       var clkLocation = Scene.Camera.MouseToWorldPoint();
       _eraser.SetPosition(clkLocation); 
    }
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        Desktop.Render();
    }
}