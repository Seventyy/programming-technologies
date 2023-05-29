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
    public class EventListViewModel : ViewModel
    {
        private int id;
        private int customer_id;
        private int product_id;
        private DateTime event_occurence_time;

        public int EventId { get => id; set { id = value; OnPropertyChanged(nameof(EventId)); } }
        public int CustomerId { get => customer_id; set { customer_id = value; OnPropertyChanged(nameof(CustomerId)); } }
        public int ProductId { get => product_id; set { product_id = value; OnPropertyChanged(nameof(ProductId)); } }
        public DateTime EventOccurenceTime { get => event_occurence_time; set { event_occurence_time = value; OnPropertyChanged(nameof(EventOccurenceTime)); } }

        IServiceApi serviceApi;
        private List<IEventModel> events;
        public List<IEventModel> Events
        {
            get => events;
            set { events = value; OnPropertyChanged(nameof(Events)); }
        }

        public EventListViewModel()
        {
            serviceApi = new DataService();
            events = new List<IEventModel>();

            AddCommand = new RelayCommandViewModel(e => { AddEvent(); });
            DeleteCommand = new RelayCommandViewModel(e => { DeleteEvent(); });
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        private void AddEvent()
        {
            EventModel new_event = new EventModel(serviceApi, id, customer_id, product_id, event_occurence_time);
            Events.Add(new_event);
            OnPropertyChanged(nameof(Events));
            new_event.Add();
        }
        private void DeleteEvent()
        {
            EventModel new_event = new EventModel(serviceApi, id, customer_id, product_id, event_occurence_time);
            foreach (var c in Events)
            {
                if (c.EventId == id)
                {
                    Events.Remove(c);
                    break;
                }
            };
            OnPropertyChanged(nameof(Events));
            new_event.Delete();
        }
    }
}
