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
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PointRobertsSoftware.StarTrek.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Composition;
using System.Numerics;
using Windows.UI;

namespace PointRobertsSoftware.StarTrek.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Compositor _compositor;
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageVM();
            //_compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

            //// create a red sprite visual
            //var myVisual = _compositor.CreateSpriteVisual();
            //myVisual.Brush = _compositor.CreateColorBrush(Colors.Red);
            //myVisual.Size = new Vector2(100, 100);

            //// create a blue drop shadow
            //var shadow = _compositor.CreateDropShadow();
            //shadow.Offset = new Vector3(0, 0, 30);
            //shadow.Color = Colors.Blue;
            //myVisual.Shadow = shadow;

            //ElementCompositionPreview.SetElementChildVisual(this, myVisual);

        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage));
        }

        private void VerifyServer_Click(object sender, RoutedEventArgs e)
        {
            _compositor = ElementCompositionPreview.GetElementVisual(this.VerifyServer).Compositor;
            var myVisual = _compositor.CreateSpriteVisual();
            myVisual.Size = new Vector2((float)VerifyServer.ActualWidth, (float)VerifyServer.ActualHeight);

            var dropShadow = _compositor.CreateDropShadow();
            dropShadow.Offset = new Vector3(0, 0, 0);
            dropShadow.Color = Colors.Blue;
            myVisual.Shadow = dropShadow;
            ElementCompositionPreview.SetElementChildVisual(this.VerifyServerShadow, myVisual);

            ((MainPageVM)DataContext).SelectGrid = "VerifyServerGrid";

            ((MainPageVM)DataContext).VerifyText = "Verifing connection with the server...";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://localhost/StartrekServer/Game").Result;
                if (response.IsSuccessStatusCode)
                {
                    ((MainPageVM)DataContext).VerifyTextResult = "Server looks OK.";
                }
                else
                {
                    ((MainPageVM)DataContext).VerifyTextResult = response.StatusCode.ToString();
                }
            }
        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            ((MainPageVM)DataContext).SelectGrid = "LoadGameGrid";

        }
    }
}

