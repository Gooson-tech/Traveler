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
        StartingProgramSettings();
        base.Initialize();
        
        var mapTexture = Content.LoadTexture(FileLocations.Map);
        ScreenSetup(mapTexture);
        SceneSetup(mapTexture);

        //Create Players Party
        var party = new Party(FileLocations.Party, 20);
        party.SetPosition(Vector2.Zero);
        SceneCameraController.CameraFollow(Scene.Camera, party);
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
    private static void SceneSetup(Texture2D mapTexture)
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
        Scene.Camera.MinimumZoom = 1f;
        Scene.Camera.MaximumZoom = 100f;
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
        //***temp***var mode = MyraUI.PaintMode ? UserActions.Mode.Paint : UserActions.Mode.TravelToClicked;
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