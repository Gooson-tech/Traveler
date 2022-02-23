using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
namespace DndApp;

public class Game1 : Core
{

    // private static void Window_ClientSizeChanged(object sender, System.EventArgs e) => UI.BuildUI();
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

    private bool TimePaused { get; set; } = true;
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
        //fix later
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
        int index = (int)today.TotalHours;
        if (index>=Climate.Dec1Data.Length)
        {
            UI.InformationBox.Text = "NOW: " + "ERROR" + "Weather: " + "ERROR";
            return;
        }
        var todaysResults = Climate.Dec1Data[index];
        UI.InformationBox.Text = "NOW: " + _date + "Weather: " + todaysResults;
        _lastDate=_date;
    }
    
    protected override void Update(GameTime gametime) 
    {
       base.Update(gametime);
       AllUserActions();
    }

    private void AllUserActions()
    {
        if (UI.Ontop) return;

        //camera
        SceneCamera.CameraZoom(Input.MouseWheel);
        //party
        PartyKeyActions();
        PartyUIActions();
        //draw
        DrawActions();
    }

    private void PartyUIActions()
    {
        
    }
    
    private static Entity _eraser;
    private void DrawActions()
    {
        //TODO: Insert UI for draw actions too
        
        //Initiate
        if (UI.PaintName != UI.LastUsedPaintName && UI.PaintName != null)
        {
            Biome.CreateNewBiome(UI.PaintName, UI.ClimateType);
            UI.LastUsedPaintName = UI.PaintName;
        }
        if (!UI.PaintMode) return;
        if (Input.LeftMouseButtonDown) DoPainting();
        //eraser
        else if (Input.RightMouseButtonDown)
        {
            _eraser.Enabled = true;
            DoErasing();
        }
        else _eraser.Enabled = false;
    }

    private void PartyKeyActions()
    {
        if (Input.IsKeyDown(Keys.LeftControl) && Input.LeftMouseButtonPressed)
        {
            TimePaused = true;
            _party.StopReset();
            
            _party.SetPosition(Scene.Camera.MouseToWorldPoint());
            return;
        }
        if (Input.LeftMouseButtonDown) {
            if (_party.move)
            {
                _party.move = false; 
                _party.StopReset();
            } 
            
            TimePaused = true;

            _party.MoveLocations.Enqueue(Scene.Camera.MouseToWorldPoint());
            if (Vector2.Distance(_party.MoveLocations.Last(), _party.LastRecordedMousePos) > 5) 
                _party.MoveLocations.Enqueue(Scene.Camera.MouseToWorldPoint());
        }
        if (Input.LeftMouseButtonReleased)
        {
            TimePaused = false;
            _party.move = true;
        }
        if (Input.IsKeyPressed(Keys.Space))
        {
            TimePaused = true;
            _party.StopReset();
            _party.move = false;

        }    
    }
    private static Vector2 _lstClkLocation = new(0, 0);
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
