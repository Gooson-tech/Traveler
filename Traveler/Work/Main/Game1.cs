using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Nez;
using Nez.Sprites;
using Myra;

namespace Traveler;
public sealed class Game1 : Core
{

    private UserActions _userActions;
    private readonly Desktop _desktop = new();
    public Game1() => Content.RootDirectory= string.Format(ProjectSourcePath.Value)+@"\Content\";
    protected override void Initialize()
    {
        //TODO -AlwaysSeed needs to be serialized and loaded on launch. Nez RandomSeed will be set to whatever worldTime is.
        //This is so whatever the date and time is it will always be deterministic, allowing rewinding 
        int WorldDateAndTime = 0; //replace later
        int ALWAYSSEED= (Random.Range(1, 100000));
        //--CurrentSeed = Nez.Random.SetSeed(ALWAYSSEED+WorldDateAndTime);
        /////////

        QML PaintScreen = new QML("Start.qml", false);

        StartingProgramSettings();
        base.Initialize();
        
        var mapTexture = Content.LoadTexture(FileLocations.Map);
        ScreenSetup(mapTexture);
        SceneSetup(mapTexture);

        //Create Players Party
        var party = new Party(FileLocations.Party, 20);
        party.SetPosition(Vector2.Zero);
        Scene.AddEntity(party);
    
        MyraEnvironment.Game = Core.Instance;
        var ui = new UI(_desktop);

        _userActions = new UserActions(Scene, party, new PaintActions(Scene), ui.MyraUi);
        ScheduledTasks();
    }
    private void StartingProgramSettings()
    {
        Core.DefaultSamplerState = SamplerState.LinearClamp;
        DebugRenderEnabled = true;
        Window.AllowUserResizing = true;
        FileLocations.SetToDefaultFileLocations();
    }
    private const float MAXZOOM = 100f;
    private const float MINZOOM = .1f;
    private static void SceneSetup(Texture2D mapTexture)
    {
        Scene = new Scene();
        var map = Scene.CreateEntity("Map");
        var mapRender = map.AddComponent(new SpriteRenderer(mapTexture));
        mapRender.RenderLayer = 1;
        Scene.SetDesignResolution(mapTexture.Width, mapTexture.Height,
            Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
        Scene.ClearColor = Color.Black;
        Scene.LetterboxColor = Color.Black;


        Scene.Camera.SetPosition(Vector2.Zero);
        Scene.Camera.SetMinimumZoom(MINZOOM);
        Scene.Camera.SetMaximumZoom(MAXZOOM);

    }
    private static void ScreenSetup(Texture2D mapTexture)
    {
        int useWidth=0, useHeight=0;
        if (mapTexture.Width > Screen.MonitorWidth)
            useWidth = Screen.MonitorWidth;
        if (mapTexture.Height > Screen.MonitorHeight) 
            useHeight = Screen.MonitorHeight;
        else
        {
            useWidth = mapTexture.Width;
            useHeight = mapTexture.Height;
        }
        Screen.SetSize(useWidth, useHeight);
    }
    protected override void Update(GameTime gametime)
    {
        base.Update(gametime);
        //***temp***var mode = MyraUI.PaintMode ? UserActions.Mode.Edit : UserActions.Mode.Travel;
        _userActions.CheckForInput();
    }
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        _desktop.Render();
    }
    private static void ScheduledTasks() { /* Schedule(1, true, date.GetTimeIndex());*/}
}
internal static class ProjectSourcePath
{
    private const string MyRelativePath = nameof(ProjectSourcePath) + ".cs";
    private static string? _lazyValue;
    public static string @Value => _lazyValue ??= CalculatePath();
    private static string CalculatePath()
    {
        string pathName = GetSourceFilePathName();
        return pathName[..(pathName.Length - MyRelativePath.Length + 1)];
    }
    private static string @GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) => @callerFilePath ?? @"";
}