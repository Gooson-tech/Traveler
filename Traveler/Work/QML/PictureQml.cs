using System.Threading;
using Qml.Net;
using Qml.Net.Runtimes;

namespace Traveler;
public class PictureQml
{
    private static Window1 _window;
    public PictureQml(Window1 windowToReopenOnClose)
    {
        _window = windowToReopenOnClose;
        StartThreaded();
    }
    private static void StartThreaded()
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
       var DotQml =FileLocations.QML + "main.qml";
       engine.Load(DotQml);
       app.Exec();
       _window.Visible = true;
    }

}