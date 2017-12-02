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
        TaxiDriver currentDriver;
        public MainWindow()
        {
            InitializeComponent();
            //AddClientsInfo();
            //AddDriversInfo();
            //AddOrdersInfo();
            //using (DriverContext content = new DriverContext())
            //{
            //    content.Database.Delete();
            //}
        }
        private void AddClientsInfo()
        {
            using (var cont = new DriverContext())
            {
                var modest = new TaxiClient("Модест", "+380964569852");
                var vlad = new TaxiClient("Влад", "+380935263145");
                var yura = new TaxiClient("Юра", "+380965214563");
                var solomiua = new TaxiClient("Соломія", "+380964256312");
                var bohdan = new TaxiClient("Богдан", "+380968145263");

                cont.Clients.Add(modest);
                cont.Clients.Add(vlad);
                cont.Clients.Add(yura);
                cont.Clients.Add(solomiua);
                cont.Clients.Add(bohdan);
                cont.SaveChanges();
            }
        }
        private void AddDriversInfo()
        {
            using (var cont = new DriverContext())
            {
                var roman = new TaxiDriver("Паробій", "Роман", 19, "BC1567AC", 5, 50, 29);
                var colia = new TaxiDriver("Баранов", "Микола", 19, "BC7898BM", 3, 75, 0);
                var modest = new TaxiDriver("Радомський", "Модест", 20, "BC8765", 3, 23, 0);
                var rostik = new TaxiDriver("Радиш", "Ростислав", 19, "BC3456AM1", 3, 23, 50);

                cont.Drivers.Add(roman);
                cont.Drivers.Add(colia);
                cont.Drivers.Add(modest);
                cont.Drivers.Add(rostik);

                cont.SaveChanges();
            }
        }
        private void AddOrdersInfo()
        {
            using (var cont = new DriverContext())
            {
                var vlad = (from elem in cont.Clients where elem.ClientNumber == 1 select elem).First();
                var roman = (from elem in cont.Drivers where elem.DriverNumber == 1 select elem).First();

                var first = new TaxiOrder(vlad, roman, Convert.ToDateTime("2017-10-19 18:00"), "Унівеsка,1", "Гsцька,142", 19, 15, true);
                cont.Orders.Add(first);
                cont.SaveChanges();
            }
        }

        public void updateOrders(TaxiOrder orderToUpdate)
        {
            using (DriverContext content = new DriverContext())
            {
                var clients = (from client in content.Clients
                               select client).ToList();
                var drivers = (from driver in content.Drivers
                               select driver).ToList();

                //UpdateOrderInfoINDB
                var toUpdate = content.Orders.SingleOrDefault(s => s.OrderNumber == orderToUpdate.OrderNumber);
                if(toUpdate!=null)
                {
                    toUpdate.IsDone = true;
                    toUpdate.RoadTime = orderToUpdate.RoadTime;
                    toUpdate.Cost = orderToUpdate.Cost;
                    content.SaveChanges();
                }
                currentDriver.PayCheck += orderToUpdate.Cost;
                driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";

                //ShowOrdersInListView 
                var currentOrders = (from order in content.Orders
                                     where order.DriverId.DriverNumber == currentDriver.DriverNumber
                                     select order).ToList();
                orders.Items.Clear();
                foreach (var order in currentOrders)
                {
                    orders.Items.Add(order);
                }
            }
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                OrderWindow wind = new OrderWindow(item as TaxiOrder);
                wind.Show();
            }
        }

        private void startWork_Click(object sender, RoutedEventArgs e)
        {
            using (DriverContext content = new DriverContext())
            {
                currentDriver = (from driver in content.Drivers
                                where driver.Surname==driverSurName.Text && driver.Name==driverUserName.Text
                                select driver).First();
                driverInfoSurnameNameDetails.Content = currentDriver.Surname + " " + currentDriver.Name;
                driverInfoAgeDetails.Content = currentDriver.Age;
                driverInfoCarDetails.Content = currentDriver.CarNumber;
                driverInfoExpDetails.Content = currentDriver.Experience;
                driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
                driverInfoCostPerMinDetails.Content = currentDriver.CostPerMinute;

                //ShowOrdersInListView
                var clients = (from client in content.Clients
                               select client).ToList();
                var currentOrders = (from order in content.Orders
                                     where order.DriverId.DriverNumber == currentDriver.DriverNumber
                                     select order).ToList();
                orders.Items.Clear();
                foreach (var order in currentOrders)
                {
                    orders.Items.Add(order);
                }
            }
        }

        private void endOfWork_Click(object sender, RoutedEventArgs e)
        {
            //Update driver info in DB
            using (DriverContext content = new DriverContext())
            {
                var toUpdate = content.Drivers.SingleOrDefault(s => s.DriverNumber == currentDriver.DriverNumber);
                if(toUpdate!=null)
                {
                    toUpdate.PayCheck = currentDriver.PayCheck;
                    content.SaveChanges();
                }
            }
            MessageBox.Show(String.Format("Дякуюємо за роботу {0}!", currentDriver.Name), "Допобачення");
            Close();
        }
    }
}
