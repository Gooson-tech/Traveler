using System.Threading;
using Qml.Net;
using Qml.Net.Runtimes;

namespace DndApp
{
    [Signal("customSignal", NetVariantType.Bool)] // You can define signals that Qml can listen to.
    public class qqqqqTest
    {
        public static void ActivateCustomSignal(string message)
        {
            StartScreen2.StartThreaded();
        }
    }

    public class StartScreen2
    {
        public static void StartThreaded() => ThreadPool.QueueUserWorkItem(StartSTheScreen);

        private static void StartSTheScreen(object state)
        {
            RuntimeManager.DiscoverOrDownloadSuitableQtRuntime();
            using var app = new QGuiApplication();
            using var engine = new QQmlApplicationEngine();

            Qml.Net.Qml.RegisterType<UIText>("test2", 1, 1);

            var dotQml = FileLocations.QML + "Start.qml";
            engine.Load(dotQml);
            app.Exec();
        }
    }
}
