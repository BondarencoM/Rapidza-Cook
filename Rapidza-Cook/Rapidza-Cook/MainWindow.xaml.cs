using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Rapidza_Cook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<OrderedProduct> orderedProducts;
        private DataReceiver receive = new DataReceiver(8082);


        public MainWindow()
        {
            InitializeComponent();
            receive.messageReceived += Receive_messageReceived;
        }

        public static string GetLocalIP()
        {
            ////look it up how to get the ip adress
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";

        }


        private void Receive_messageReceived(object sender, string e)
        {
            //throw new NotImplementedException();
            Console.WriteLine(e);
            var products = JsonConvert.DeserializeObject<List<OrderedProduct>>(e);
            App.Current.Dispatcher.Invoke(
                () =>
                {
                    foreach (OrderedProduct o in products)
                    {
                        orderedProducts.Add(o);
                    }
                }
                );

        }

    

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            orderedProducts = new ObservableCollection<OrderedProduct>()
            {/*
                new OrderedProduct("Margareta"),
                new OrderedProduct("Rancho"),
                new OrderedProduct("Rancho"),
                new OrderedProduct("Quadra Fromagge"),
                new OrderedProduct("Rancho"),
                new OrderedProduct("Rancho"),
            */
                };
            MessageBox.Show(GetLocalIP());
            lbOrderedProducts.ItemsSource = orderedProducts;
        }

        private void toRemove(object sender, RoutedEventArgs e)
        {
            OrderedProduct item = (sender as Button).DataContext as OrderedProduct;
            orderedProducts.Remove(item);
        }


    }
}
