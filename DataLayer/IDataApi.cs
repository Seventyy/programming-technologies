using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.abstraction.interfaces;

public interface IDataApi
{

    static IDataApi createDataRepository()
    {
        return new Data.DataRepository();
    }


    #region Customer

    public void addCustomer(int customer_id, string first_name, string last_name);
    public void deleteCustomer(int id);
    public void updateCustomer(int id, int customer_id, string first_name, string last_name);
    public String getCustomerFirstName(int id);
    public String getCustomerLastName(int id);
    public int getCustomerID(int id);
    #endregion


    #region Product

    public void addProduct(int pid, string name, double price, double state);
    public void deleteProduct(int id);
    public int getProductID(int id);
    public void updateProduct(int id, string name, double price, double state);
    public string getProductName(int id);
    public double getProductPrice(int id);
    public double getProductState(int id);
    #endregion


    #region Event

    public void addEvent(int id, int customer_id, int product_id, string mode);
    public void deleteEvent(int id);
    public int getEventCustomerId(int id);
    public int getEventProductId(int id);
    public int getEventId(int id);
    public DateTime getEventDate(int id);
    #endregion


}
