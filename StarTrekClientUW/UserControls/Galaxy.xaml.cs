using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using PointRobertsSoftware.StarTrek.ViewModels;

namespace PointRobertsSoftware.StarTrek.UserControls
{
    /// <summary>
    /// Interaction logic for Galaxy.xaml
    /// </summary>
    public partial class Galaxy : UserControl
    {
        public Galaxy()
        {
            //DataContext = new GalaxyVM();
            InitializeComponent();
        }
    }

    public class Extensions
    {
        // RowLocation
        public static readonly DependencyProperty RowLocation = DependencyProperty.RegisterAttached("RowPosition", typeof(int), typeof(Extensions), new PropertyMetadata(default(int)));
        public static void SetRowLocation(UIElement element, int value)
        {
            element.SetValue(RowLocation, value);
        }
        public static int GetRowLocation(UIElement element)
        {
            return (int)element.GetValue(RowLocation);
        }
    }
}
