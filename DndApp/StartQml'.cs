using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Qml.Net;
using System.IO;
using Qml.Net.Runtimes;

namespace DndApp;

public class StartQml
{
    public static void Start()
    {
        RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();

        using var app = new QGuiApplication();
        using var engine = new QQmlApplicationEngine();

        // Register our new type to be used in Qml
        Qml.Net.Qml.RegisterType<QmlType>("test", 1, 1);
        // var assemblyDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
        //  var mainQmlPath = Path.Combine(assemblyDir, "main.qml");
        engine.Load("C:\\Users\\graym\\Documents\\GitHub\\Traveler\\DndApp\\main.qml");
        app.Exec();
    }


}