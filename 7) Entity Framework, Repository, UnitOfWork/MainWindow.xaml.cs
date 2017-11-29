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
using _7__Entity_Framework__Repository__UnitOfWork.DataTypes;

namespace _7__Entity_Framework__Repository__UnitOfWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var cont = new DriverContext())
            {
                //var roman = new TaxiDriver("Паробій", "Роман", 19, "BC1567AC", 5, 50, 29);
                //var colia = new TaxiDriver("Баранов", "Микола", 19, "BC7898BM", 3, 75, 0);
                //var modest = new TaxiDriver("Радомський", "Модест", 20, "BC8765", 3, 23, 0);
                var rostik = new TaxiDriver("Радиш2", "Ростислав2", 19, "BC3456AM1", 3, 23, 50);

                //cont.Drivers.Add(roman);
                //cont.Drivers.Add(colia);
                //cont.Drivers.Add(modest);
                cont.Drivers.Remove(rostik);
                
                cont.SaveChanges();
            }
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void startWork_Click(object sender, RoutedEventArgs e)
        {

        }

        private void endOfWork_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
