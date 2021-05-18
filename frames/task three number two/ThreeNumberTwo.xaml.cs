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

namespace PraktikaCourse3.frames.task_three_number_two
{
    /// <summary>
    /// Логика взаимодействия для ThreeNumberTwo.xaml
    /// </summary>
    public partial class ThreeNumberTwo : Page
    {
        public ThreeNumberTwo()
        {
            InitializeComponent();
            Loaded += ThreeNumberTwo_Loaded;
        }

        private void ThreeNumberTwo_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewModelThreeNumberTwo();
        }
    }
}
