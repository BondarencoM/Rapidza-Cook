using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Rapidza_Cook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<OrderedProduct> orderedProducts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            orderedProducts = new ObservableCollection<OrderedProduct>()
            {
                new OrderedProduct("Margareta"),
                new OrderedProduct("Rancho"),
                new OrderedProduct("Rancho"),
                new OrderedProduct("Quadra Fromagge"),
                new OrderedProduct("Rancho"),
                new OrderedProduct("Rancho"),

            };

            lbOrderedProducts.ItemsSource = orderedProducts;

        }
    }
}
