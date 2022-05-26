using System.Threading;
using Qml.Net;
using Qml.Net.Runtimes;

namespace DndApp
{
    public static class StartScreen
    {
        public static void StartSTheScreen()
        {
            RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
            using var app = new QGuiApplication();
            using var engine = new QQmlApplicationEngine();
            
            Qml.Net.Qml.RegisterType<qqqqqTest>("test2", 1, 1);

            var dotQml = FileLocations.QML + "Start.qml";
            engine.Load(dotQml);
            app.Exec();
        }

    }
}
