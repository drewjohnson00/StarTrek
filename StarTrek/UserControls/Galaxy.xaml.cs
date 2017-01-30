using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StarTrek.ViewModels;

namespace StarTrek.UserControls
{
    /// <summary>
    /// Interaction logic for Galaxy.xaml
    /// </summary>
    public partial class Galaxy : UserControl
    {
        public Galaxy()
        {
            DataContext = new GalaxyVM();
            InitializeComponent();
        }
    }
}
