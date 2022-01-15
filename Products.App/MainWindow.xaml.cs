using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Products.Model;

namespace Products.App
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> _products;
        private ObservableCollection<ProductType> _types;
        private ProductsDB _db;
        
        public MainWindow()
        {
            InitializeComponent();

            _db = new ProductsDB();
            _products = new ObservableCollection<Product>(_db.TabProducts);
            _types = new ObservableCollection<ProductType>(_db.TabTypes);

            ProductsList.ItemsSource = _products;
            ProductType.ItemsSource = _types;
        }

        private void ProductsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (sender as ListBox)?.SelectedItem as Product;

            ProductId.Text = product?.Id.ToString() ?? "null";
            ProductName.Text = product?.Name ?? "null";
            ProductType.SelectedItem = product?.IdTypeNavigation;
        }
    }
}