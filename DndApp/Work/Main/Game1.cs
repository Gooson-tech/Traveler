using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Nez;
using Nez.Sprites;
using DndApp.Annotations;
using Myra;
namespace DndApp;




public sealed class Game1 : Core
{

    private Party _party;
    private UserActions _userActions;
    Desktop _desktop;

    public Game1() => Content.RootDirectory= string.Format(ProjectSourcePath.Value)+@"\Content\";
    protected override void Initialize()
    {
        base.Initialize();
        StartingProgramSettings();
        MyraEnvironment.Game = Core.Instance;

        var mapTexture = Content.LoadTexture(FileLocations.Map);

        SceneSetup(mapTexture);
        _desktop = new Desktop();
        var ui = new UI(_desktop);

       // UI.BuildUI();
        Screen.SetSize(mapTexture.Width, mapTexture.Height);
        ScheduledTasks();
        LoadContent();
        PaintActions paintActions = new PaintActions(Scene);
        _userActions = new UserActions(Scene, _party, paintActions, ui);
    }
    private void StartingProgramSettings()
    {
        FileLocations.SetToDefaultFileLocations();
        DebugRenderEnabled = true;
        Window.AllowUserResizing = true;
    }
    private static void SceneSetup(Texture2D mapTexture)
    {
        Scene = new Scene();
        var map = Scene.CreateEntity("Map");
        var mapRender = map.AddComponent(new SpriteRenderer(mapTexture));
        mapRender.RenderLayer = 1;
        Scene.SetDesignResolution(mapTexture.Width, mapTexture.Height,
            Scene.SceneResolutionPolicy.NoBorderPixelPerfect);
        SceneCamera.SetUp(Scene.Camera);
        Scene.ClearColor = Color.Black;
        Scene.LetterboxColor = Color.Black;
    }
    protected override void LoadContent()
    {
        base.LoadContent();
        _party = new Party(FileLocations.Party, 20);
        _party.SetPosition(new Vector2(0, 0));
        Scene.AddEntity(_party);
    }
    protected override void Update(GameTime gametime)
    {
        base.Update(gametime);
        //***temp***
        //var mode = UI.PaintMode ? UserActions.Mode.Paint : UserActions.Mode.TravelToClicked;
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
        return pathName.Substring(0, pathName.Length - MyRelativePath.Length + 1);
    }
    private static string @GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) => @callerFilePath ?? @"";
}