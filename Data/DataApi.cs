using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Data.abstraction.interfaces;

public interface DataApi
{

    static DataApi createDataRepository()
    {
        return new DataRepository();
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

    public void addProduct(int pid, string name, double price);
    public void deleteProduct(int id);
    public int getProductID(int id);
    public void updateProduct(int id, string name, double price);
    public string getProductName(int id);
    public double getProductPrice(int id);
    #endregion


    #region Event

    public void addEvent(int id, int customer_id, int product_id, string mode);
    public void deleteEvent(int id);
    public int getEventCustomerId(int id);
    public int getEventProductId(int id);
    public int getEventId(int id);
    public DateTime getEventDate(int id);
    #endregion

    #region State

    public void addState(int id, int pid, double q);
    public void deleteState(int id);
    public void updateState(int id, double quantity);
    public int getStateId(int id);
    public int getStateProductId(int id);
    public double getStateQuantity(int id);
    #endregion

}
