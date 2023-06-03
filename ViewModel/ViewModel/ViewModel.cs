using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        static CustomerListViewModel CreateCustomerListViewModel() { return new CustomerListViewModel(); }
        static ProductListViewModel CreateProductListViewModel() { return new ProductListViewModel(); }
        static EventListViewModel CreateEventListViewModel() { return new EventListViewModel(); }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
