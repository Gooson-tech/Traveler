﻿#region Using Statements

using System;
using System.Threading;
using Qml.Net.Runtimes;

#if MONOMAC
using MonoMac.AppKit;
using MonoMac.Foundation;
#elif __IOS__ || __TVOS__
using Foundation;
using UIKit;
#endif

#endregion


namespace DndApp
{
#if __IOS__ || __TVOS__
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
#else
    internal static class Program
#endif
    {
        private static void RunGame()
        {
            //StartScreen.StartSTheScreen();

            var game = new Game1();
            game.Run();
#if !__IOS__ && !__TVOS__
            game.Dispose();
#endif
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
#if !MONOMAC && !__IOS__ && !__TVOS__
        [STAThread]
#endif
        static void Main(string[] args)
        {
#if MONOMAC
            NSApplication.Init ();

            using (var p = new NSAutoreleasePool ()) {
                NSApplication.SharedApplication.Delegate = new AppDelegate();
                NSApplication.Main(args);
            }
#elif __IOS__ || __TVOS__
            UIApplication.Main(args, null, "AppDelegate");
#else

            RunGame();

#endif
        }

#if __IOS__ || __TVOS__
        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
#endif
    }

#if MONOMAC
    class AppDelegate : NSApplicationDelegate
    {
        public override void FinishedLaunching (MonoMac.Foundation.NSObject notification)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (object sender, ResolveEventArgs a) =>  {
                if (a.Name.StartsWith("MonoMac")) {
                    return typeof(MonoMac.AppKit.AppKitFramework).Assembly;
                }
                return null;
            };
            Program.RunGame();
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender)
        {
            return true;
        }
    }
#endif
}