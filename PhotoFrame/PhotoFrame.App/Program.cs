using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Qml.Net;
using System.IO;

namespace PhotoFrame.App
{
    public class Program2
    {
        public void Mai2()
        {

            using (var app = new QGuiApplication(null))
            {
                using (var engine = new QQmlApplicationEngine())
                {
                    // Register our new type to be used in Qml
                    Qml.Net.Qml.RegisterType<QmlType>("test", 1, 1);

                    // var assemblyDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
                    //  var mainQmlPath = Path.Combine(assemblyDir, "main.qml");
                    engine.Load("C:\\Users\\graym\\Documents\\GitHub\\Traveler\\PhotoFrame\\PhotoFrame.App\\main.qml");
                    app.Exec();
                    return;
                }
            }


        }
        //old singular app
        internal static class Program { private static int Main(string[] args)
            {

                /*using (var app = new QGuiApplication(args))
                {
                    using (var engine = new QQmlApplicationEngine())
                    {
                        // Register our new type to be used in Qml
                        // Qml.Net.Qml.RegisterType<QmlType>("test", 1, 1)

                        // var assemblyDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
                        //  var mainQmlPath = Path.Combine(assemblyDir, "main.qml");
                        engine.Load(
                            "C:\\Users\\graym\\Downloads\\qmlnet-develop\\qmlnet-develop\\samples\\PhotoFrame\\PhotoFrame.App\\main.qml");
                        return app.Exec();
                    }
                }*/
                return 0;
            } }
    }
}