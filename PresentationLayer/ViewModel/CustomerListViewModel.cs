using Data.abstraction.interfaces;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.Model;

namespace PresentationLayer.ViewModel
{
    public class CustomerListViewModel : ViewModel
    {
        private int id;
        private string first_name;
        private string last_name;

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string FirstName
        {
            get => first_name;
            set { first_name = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get => last_name;
            set { last_name = value; OnPropertyChanged(nameof(LastName)); }
        }


        IServiceApi serviceApi;
        private List<ICustomerModel> customers;
        public List<ICustomerModel> Customers
        {
            get => customers;
            set { customers = value; OnPropertyChanged(nameof(Customers)); }
        }

        public CustomerListViewModel()
        {
            serviceApi = new DataService();
            customers = new List<ICustomerModel>();

            AddCommand = new RelayCommandViewModel(e => { AddCustomer(); });
            EditCommand = new RelayCommandViewModel(e => { EditCustomer(); });
            DeleteCommand = new RelayCommandViewModel(e => { DeleteCustomer(); });

            GetCustomers();
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        private void AddCustomer()
        {
            CustomerModel new_customer = new CustomerModel(serviceApi, id, first_name, last_name);
            Customers.Add(new_customer);
            OnPropertyChanged(nameof(Customers));
            new_customer.Add();
        }
        private void EditCustomer()
        {
            CustomerModel new_customer = new CustomerModel(serviceApi, id, first_name, last_name);
            foreach (var c in Customers)
            {
                if (c.CustomerId == id)
                {
                    Customers.Remove(c);
                    Customers.Add(new_customer);
                    break;
                }
            };
            OnPropertyChanged(nameof(Customers));
            new_customer.Edit(id, first_name, last_name);
        }
        private void DeleteCustomer()
        {
            CustomerModel new_customer = new CustomerModel(serviceApi, id, first_name, last_name);
            foreach (var c in Customers)
            {
                if (c.CustomerId == id)
                {
                    Customers.Remove(c);
                    break;
                }
            };
            OnPropertyChanged(nameof(Customers));
            new_customer.Delete();
        }

        void GetCustomers()
        {
            List<ICustomer> c = serviceApi.getCustomers();
            foreach (var item in c)
            {
                customers.Add(new CustomerModel(serviceApi, item.CustomerId, item.First_Name, item.Last_Name));
            }
        }
    }
}
