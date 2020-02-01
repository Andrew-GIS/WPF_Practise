using SportShop.Model;
using SportShop.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportShop.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products { get; set; }

        public ICommand RemoveCommand { get; set; }

        public ICommand DefaultCommand { get; set; }

        private Product selectedProduct;

        public Product SelectedProduct
        {

            get { return selectedProduct; }
            set
            {
                this.selectedProduct = value;
                this.OnPropertyChanged("SelectedProduct");
            }
        }

        public ProductViewModel()
        {
            this.GenerateListOfProducts();
            this.RemoveCommand = new RelayCommand(this.RemoveCommand_Execute);
            this.DefaultCommand = new RelayCommand(this.DefaultCommand_Executer);
        }

        public ObservableCollection<Product> GenerateListOfProducts()
        {
            Products = new ObservableCollection<Product>
            {
                new Product {ProductName = "Footboll Ball", ProductModel = "4RTY-12", CountryDistributor = "USA", Price = 25, SportCategory = "Football", Image = $"{Directory.GetCurrentDirectory()}/ball.png"},
                new Product {ProductName = "Swimming Glass", ProductModel = "Spedoo-80x", CountryDistributor = "Germany", Price = 60, SportCategory = "Swimming", Image = $"{Directory.GetCurrentDirectory()}/SwimmingGlass.png"},
                new Product {ProductName = "Tenis Racket", ProductModel = "UnD-13", CountryDistributor = "Ukraine", Price = 100, SportCategory = "Tenis", Image = $"{Directory.GetCurrentDirectory()}/tenisRocket.png"},
                new Product {ProductName = "Swimming Flippers", ProductModel = "Arena 2020", CountryDistributor = "USA", Price = 90, SportCategory = "Swimming", Image = $"{Directory.GetCurrentDirectory()}/flippers.png"}
            };
            return Products;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void RemoveCommand_Execute(object obj)
        {
            this.Products.Remove(this.SelectedProduct);
        }

        public void DefaultCommand_Executer(object obj)
        {
            this.SelectedProduct.ProductName = "default";
            this.SelectedProduct.ProductModel = "default";
            this.SelectedProduct.Price = 0;
            this.SelectedProduct.SportCategory = "default";
            this.SelectedProduct.CountryDistributor = "default";
        }
    }
}