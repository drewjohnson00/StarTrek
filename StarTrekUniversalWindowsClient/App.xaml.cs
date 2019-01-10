using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PointRobertsSoftware.StarTrek.Logging;
using PointRobertsSoftware.StarTrek.Views;
using System.Globalization;

namespace PointRobertsSoftware.StarTrek
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        private IEventLogger _traceLogger;
        public App()
        {
            _traceLogger = new TraceLogger();
            //this.Suspending += OnSuspending;
        }

        public UnityContainer Container { get; private set; }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Container = new UnityContainer();
            App.RegisterTypes(Container);

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), args.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }

    //protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
    //{
    //    NavigationService.Navigate("Main", null);
    //    Window.Current.Activate();
    //    return Task.FromResult<object>(null);
    //}

    //protected override Task OnInitializeAsync(IActivatedEventArgs args)
    //{
    //    //Container.RegisterType<IEventLogger, TraceLogger>(new ContainerControlledLifetimeManager());
    //    //RegisterTypes();

    //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
    //    {
    //        var viewModelTypeName = string.Format(CultureInfo.InvariantCulture,
    //            "StarTrek.ViewModels.{0}VM, Startrek2", viewType.Name);
    //        var viewModelType = Type.GetType(viewModelTypeName);

    //        if (viewModelType == null)
    //        {
    //            viewModelTypeName = string.Format(CultureInfo.InvariantCulture,
    //                "StarTrek.UserControls.{0}VM, Startrek2", viewType.Name);
    //            viewModelType = Type.GetType(viewModelTypeName);
    //        }
    //        return viewModelType;
    //    });

    //    return base.OnInitializeAsync(args);
    //}

    //private void RegisterTypes()
    //{


    //    RegisterTypeIfMissing(typeof(IEventLogger), typeof(TraceLogger), true); // true -- singleton
    //}

    //private void OnSuspending(object sender, SuspendingEventArgs e)
    //{
    //    var deferral = e.SuspendingOperation.GetDeferral();

    //    deferral.Complete();    // TODO -- Save application state and stop any background activity
    //}

    //protected override void ConfigureContainer()
    //{
    //    base.ConfigureContainer();

    //    RegisterTypeIfMissing(typeof(IEventLogger), typeof(TraceLogger), true); // true -- singleton
    //}


}
