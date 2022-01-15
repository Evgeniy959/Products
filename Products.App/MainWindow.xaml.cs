using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Products.Model;

namespace Products.App
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<ProductType> _types;
        private ProductsDB _db;
        
        public MainWindow()
        {
            InitializeComponent();

            _db = new ProductsDB();
            _types = new ObservableCollection<ProductType>(_db.TabTypes);
            
            ProductsList.ItemsSource = _db.TabProducts.ToList();
            ProductType.ItemsSource = _types;
        }

        private void ProductsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (sender as ListBox)?.SelectedItem as Product;

            ProductId.Text = product?.Id.ToString() ?? "null";
            ProductName.Text = product?.Name ?? "null";
            ProductType.SelectedItem = product?.IdTypeNavigation;
        }

        private void Button_Save_OnClick(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(ProductId.Text);
            var product_type = ProductType.SelectedItem as ProductType;
            
            var product = _db.TabProducts.Find(id);
            product.Name = ProductName.Text;
            product.IdTypeNavigation = product_type;
            
            ProductsList.ItemsSource = _db.TabProducts.ToList();
            
            _db.SaveChanges();
        }
    }
}