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

namespace CalorieCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FatCaculator fc = new FatCaculator();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = fc;
        }
        //Reset everthing
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            fc.ResetButton();
        }
    }
}
