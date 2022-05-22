using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Qml.Net;
using Qml.Net.Runtimes;

namespace DndApp;
public class MyQml
{
    private static Window1 _window;
    public MyQml(Window1 windowToReopenOnClose)
    {
        _window = windowToReopenOnClose;
        StartThreaded();
    }

    private static void StartThreaded()
    {
        Thread newThread = new(Start);
        newThread.Start();
    }
    private static void Start()
    {
        RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
        using var app = new QGuiApplication();
        using var engine = new QQmlApplicationEngine();
        // Register our new type to be used in Qml
        Qml.Net.Qml.RegisterType<UIText>("test", 1, 1);
        var assemblyDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
        var mainQmlPath = Path.Combine(assemblyDir, "main.qml");
        engine.Load(@"C:\Users\graym\Documents\GitHub\Traveler\DndApp\Work\Main\main.qml");
        app.Exec();

        _window.Visible = true;
    }


}