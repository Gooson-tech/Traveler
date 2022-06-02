using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Nez.AI.BehaviorTrees;
using Nez.Sprites;
using Qml.Net;
using Qml.Net.Runtimes;

namespace Traveler;

public static class QmlLauncher
{

    /*public static void StartThreaded<T>(string qmlFile, string uri = "test", int versionMaj = 1, int versionMin = 1)
    { 
        //ThreadPool.QueueUserWorkItem(Start);
        //Thread newThread = new(ShowPicture);
        //newThread.Start();
        Thread myNewThread = new Thread(() => Start<T>(qmlFile, uri, versionMaj, versionMin));
        myNewThread.Start();
    }



    private static void Start<T>(object qmlFile, string uri = "test", int versionMaj = 1, int versionMin = 1)
    {
        RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
        using var app = new QGuiApplication();
        using var engine = new QQmlApplicationEngine();
        // Register our new type to be used in Qml
        Qml.Net.Qml.RegisterType<T>(uri, 1, 1);

        var DotQml = FileLocations.QML + qmlFile.ToString();
        engine.Load(DotQml);
        app.Exec();
    }*/
    private static bool _open; 
    public static void StartScreenThreaded()
    {
        if (!_open)
        {
            ThreadPool.QueueUserWorkItem(StartScreen);
        }
        //Thread newThread = new(ShowPicture);
        //newThread.Start();
    }
    private static void StartScreen(object state)
    {
        _open = true;

        RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
        using var app = new QGuiApplication();
        using var engine = new QQmlApplicationEngine();
        // Register our new type to be used in Qml
        Qml.Net.Qml.RegisterType<StartScreenQml>("test", 1, 1);
        Qml.Net.Qml.RegisterType<UIText>("test", 1, 1);
        var DotQml = FileLocations.QML + "Start.qml";

        engine.Load(DotQml);
        app.Exec();

        _open = false; 
    }
   
 
}
[Signal("customSignal", NetVariantType.Bool)] // You can define signals that Qml can listen to.
public class StartScreenQml
{
    public StartScreenQml() { }

    public void ActivateCustomSignal()
    {
        //TravelMenu.StartThreaded();
        
    }
}

public class TravelMenu
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
}