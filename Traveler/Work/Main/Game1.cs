using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Nez;
using Nez.Sprites;
using Myra;

namespace Traveler;
public sealed class Game1 : Core
{

    private Party _party;
    private UserActions _userActions;
    private Desktop _desktop;
    private UI _ui;

    public Game1() => Content.RootDirectory= string.Format(ProjectSourcePath.Value)+@"\Content\";
    protected override void Initialize()
    {
        base.Initialize();
        StartingProgramSettings();
        MyraEnvironment.Game = Core.Instance;
        Core.DefaultSamplerState= SamplerState.LinearClamp;
        var mapTexture = Content.LoadTexture(FileLocations.Map);
        
        _desktop = new Desktop();
        _ui = new UI(_desktop);

        //ui.QmlUI.Start( "Start.qml");

        // MyraUI.BuildUI();

        int useWidth = 0, useHeight=0;
        if (mapTexture.Width > Screen.MonitorWidth)
            useWidth = Screen.MonitorWidth;
        if (mapTexture.Height > Screen.MonitorHeight)
            useHeight = Screen.MonitorHeight;
        else
        { 
            useWidth = mapTexture.Width;
            useHeight = mapTexture.Height;
        }

        SceneSetup(useWidth, useHeight, mapTexture);
        Screen.SetSize(useWidth, useHeight);
        ScheduledTasks();
        LoadContent();
        var paintActions = new PaintActions(Scene);
        _userActions = new UserActions(Scene, _party, paintActions, _ui.MyraUi);

    }



    private void StartingProgramSettings()
    {
        FileLocations.SetToDefaultFileLocations();
        DebugRenderEnabled = true;
        Window.AllowUserResizing = true;
    }
    private static void SceneSetup(int width, int height, Texture2D mapTexture)
    {
        Scene = new Scene();
        var map = Scene.CreateEntity("Map");
        var mapRender = map.AddComponent(new SpriteRenderer(mapTexture));
        mapRender.RenderLayer = 1;
        Scene.SetDesignResolution(mapTexture.Width, mapTexture.Height,
            Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
        Scene.Camera.SetPosition(Vector2.Zero);
        Scene.ClearColor = Color.Black;
        Scene.LetterboxColor = Color.Black;
    }
    protected override void LoadContent()
    {
        base.LoadContent();
        _party = new Party(FileLocations.Party, 20);
        _party.SetPosition(Vector2.Zero);

        Scene.Camera.MinimumZoom = 1f;
        Scene.Camera.MaximumZoom = 100f;
        SceneCameraController.CameraFollow(Scene.Camera, _party);
        Scene.AddEntity(_party);
    }
    protected override void Update(GameTime gametime)
    {
      
        base.Update(gametime);
        //***temp***
        //var mode = MyraUI.PaintMode ? UserActions.Mode.Paint : UserActions.Mode.TravelToClicked;
        //**temp****
        _userActions.CheckForInput();
    }
 
    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        _desktop.Render();

    }
    private static void ScheduledTasks() { /* Schedule(1, true, date.GetTimeIndex());*/}

}

public static class ProjectSourcePath
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