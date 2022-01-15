using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
    }
}