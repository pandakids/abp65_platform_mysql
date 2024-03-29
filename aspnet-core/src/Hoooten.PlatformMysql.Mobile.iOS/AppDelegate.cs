﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Hoooten.PlatformMysql.Core;
using Hoooten.PlatformMysql.Core.Exception;
using UIKit;
using Hoooten.PlatformMysql.ApiClient;
using CachedImageRenderer = FFImageLoading.Forms.Platform.CachedImageRenderer;

namespace Hoooten.PlatformMysql
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            ApplicationBootstrapper.InitializeIfNeeds<PlatformMysqlXamarinIosModule>();
 
            global::Xamarin.Forms.Forms.Init();

            ImageCircleRenderer.Init();

            CachedImageRenderer.Init();

            ConfigureFlurlHttp();

            SetExitAction();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
      
        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            ExceptionHandler.LogException(unobservedTaskExceptionEventArgs.Exception);
            unobservedTaskExceptionEventArgs.SetObserved();
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            ExceptionHandler.LogException(unhandledExceptionEventArgs.ExceptionObject as Exception);
        }

        private static void SetExitAction()
        {
            App.ExitApplication = () =>
            {
                Thread.CurrentThread.Abort();
            };
        }

        private static void ConfigureFlurlHttp()
        {
            FlurlHttp.Configure(c =>
            {
                c.HttpClientFactory = new ModernHttpClientFactory();
            });
        }
    }
}
