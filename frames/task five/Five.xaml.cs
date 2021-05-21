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

namespace PraktikaCourse3.frames.task_five
{
    /// <summary>
    /// Логика взаимодействия для Five.xaml
    /// </summary>
    public partial class Five : Page
    {
        public Five()
        {
            InitializeComponent();
            Loaded += Five_Loaded;
        }

        private void Five_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new FiveViewModel();
        }
    }
}
