using System.Threading;
using Qml.Net;
using Qml.Net.Runtimes;

namespace Traveler;

public class QML
{
    private static bool _open;
    private string QmlToLoad { get; set; } = "";
    public QML(string qml = "", bool modal = true)
    {
        if (_open && !QmlToLoad.Equals(qml))
            return;

        QmlToLoad = qml;
        var t = new Thread(StartInBackground);
        if (modal) 
        {
            t.Start();
            t.Join();
        }
        else
            t.Start();

    }
    private void StartInBackground()
    {
        _open = true;
        RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
        using QGuiApplication app = new QGuiApplication();
        using QQmlApplicationEngine engine = new QQmlApplicationEngine();

        // Register our new type to be used in Qml
        Qml.Net.Qml.RegisterType<StartScreenQml>("test", 1, 1);
        Qml.Net.Qml.RegisterType<UIText>("test", 1, 1);
       
        engine.Load(FileLocations.QML + "Start.qml");

        app.Exec();
        _open = false;
    }

}

public static class QmlEngineControls
{
    public static StartScreenQml Engine = new StartScreenQml(1);
}
public static class UIINTERCHANGE
{
    private static string _weather = "";
    private static string _temperature = "";
    public  static string Events = "";
    public  static string Animals = "";
    public  static string Enemies = "";

    public static Biome CurrentBiome { get; set; }
}

[Signal("weatherSignal", NetVariantType.String)]
[Signal("temperatureSignal", NetVariantType.String)]
[Signal("hideSignal")]
[Signal("showSignal")]
public class StartScreenQml
{
    public StartScreenQml()
    {
        QmlNetConfig.ShouldEnsureUIThread = false;
        QmlEngineControls.Engine = this;
    }
    public StartScreenQml(int i) { }
    public void RaiseSignal(string signal) => this.ActivateSignal(signal);

    public void CreateBiome(string events, string animals, string enemies, string structures, string climates, string name)
        => UIINTERCHANGE.CurrentBiome = new Biome(events, animals, enemies, structures,climates,name);
    
  

}

/*public class TravelMenu
{
    public static void StartThreaded()
    {
        ThreadPool.QueueUserWorkItem(ShowPicture);
        //Thread newThread = new(ShowPicture);
        //newThread.Start();
    }

    private static void ShowPicture(object state)
    {
        RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
        using var app = new QGuiApplication();
        using var engine = new QQmlApplicationEngine();
        // Register our new type to be used in Qml
        Qml.Net.Qml.RegisterType<UIText>("test", 1, 1);
        var DotQml = FileLocations.QML + "main.qml";
        engine.Load(DotQml);
        app.Exec();
    }
}*/