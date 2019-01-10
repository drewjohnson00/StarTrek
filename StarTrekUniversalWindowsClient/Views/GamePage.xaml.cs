using PointRobertsSoftware.StarTrek.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PointRobertsSoftware.StarTrek.Views
{
    /// <summary>
    /// The game view.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
            DataContext = new GamePageVM();
        }
    }
}
