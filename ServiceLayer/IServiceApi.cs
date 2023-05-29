using Data.abstraction.interfaces;

namespace Service
{
    public interface IServiceApi
    {

        public void addCustomer(int customer_id, string first_name, string last_name);
        public void deleteCustomer(int id);
        public void updateCustomer(int id, int customer_id, string first_name, string last_name);
        public String getCustomerFirstName(int id);
        public String getCustomerLastName(int id);


        public void addProduct(int pid, string name, double price, double state);
        public void deleteProduct(int id);
        public void updateProduct(int id, string name, double price, double state);
        public string getProductName(int id);
        public double getProductPrice(int id);
        public double getProductState(int id);

        public void addEvent(int id, int customer_id, int product_id, string mode);
        public void deleteEvent(int id);
        public int getEventCustomerId(int id);
        public int getEventProductId(int id);
        public DateTime getEventDate(int id);

        public List<ICustomer> getCustomers();
        public List<IProduct> getProducts();
        public List<IEvent> getEvents();
    }
}