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

namespace PraktikaCourse3.frames.task_three
{
    /// <summary>
    /// Логика взаимодействия для Three.xaml
    /// </summary>
    public partial class Three : Page
    {
        public Three()
        {
            InitializeComponent();
            Loaded += Three_Loaded;            
        }

        private void Three_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ThreeViewModel();
        }
    }
}
