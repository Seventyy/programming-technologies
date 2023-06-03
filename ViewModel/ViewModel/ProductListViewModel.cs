using Data.abstraction.interfaces;
using PresentationLayer.Model;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
    public class ProductListViewModel : ViewModel
    {
        private int id;
        private string name;
        private double price;
        private double state;

        public int Id { get => id; set { id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }
        public double Price { get => price; set { price = value; OnPropertyChanged(nameof(Price)); } }
        public double State { get => state; set { state = value; OnPropertyChanged(nameof(State)); } }

        IServiceApi serviceApi;
        private List<IProcuctModel> products;
        public List<IProcuctModel> Products
        {
            get => products;
            set { products = value; OnPropertyChanged(nameof(Products)); }
        }

        public ProductListViewModel()
        {
            serviceApi = new DataService();
            products = new List<IProcuctModel>();

            AddCommand = new RelayCommandViewModel(e => { AddProduct(); });
            EditCommand = new RelayCommandViewModel(e => { EditProduct(); });
            DeleteCommand = new RelayCommandViewModel(e => { DeleteProduct(); });

            GetProducts();
        }

        public ProductListViewModel(IServiceApi serviceApi)
        {
            this.serviceApi = serviceApi;
            products = new List<IProcuctModel>();

            AddCommand = new RelayCommandViewModel(e => { AddProduct(); });
            EditCommand = new RelayCommandViewModel(e => { EditProduct(); });
            DeleteCommand = new RelayCommandViewModel(e => { DeleteProduct(); });

            GetProducts();
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        private void AddProduct()
        {
            ProductModel new_product = new ProductModel(serviceApi, id, name, price, state);
            Products.Add(new_product);                  
            OnPropertyChanged(nameof(Products));        
            new_product.Add();
        }
        private void EditProduct()
        {
            ProductModel new_product = new ProductModel(serviceApi, id, name, price, state);
            foreach (var c in Products)
            {
                if (c.ProductId == id)
                {
                    Products.Remove(c);
                    Products.Add(new_product);
                    break;
                }
            };
            OnPropertyChanged(nameof(Products));
            new_product.Edit(name, price, state);
        }
        private void DeleteProduct()
        {
            ProductModel new_product = new ProductModel(serviceApi, id, name, price, state);
            foreach (var c in Products)
            {
                if (c.ProductId == id)
                {
                    Products.Remove(c);
                    break;
                }
            };
            OnPropertyChanged(nameof(Products));
            new_product.Delete();
        }

        void GetProducts()
        {
            List<IProduct> c = serviceApi.getProducts();
            foreach (var item in c)
            {
                products.Add(new ProductModel(serviceApi, item.ProductId, item.Name, item.Price, item.State));
            }
        }

    }
}
