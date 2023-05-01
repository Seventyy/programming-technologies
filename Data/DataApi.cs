using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Data.abstraction.interfaces;

public interface DataApi
{
    public void addCustomer(int cid, string fn, string ln);
    public void deleteCustomer(int id);
    public String getCustomerFirstName(int id);
    public void setCustomerFirstName(int id, string name);
    public String getCustomerLastName(int id);
    public void setCustomerLastName(int id, string name);
    public int getCustomerID(int id);

    public void addProduct(int pid, string n, double q, double p);
    public void deleteProduct(int id);
    public int getProductID(int id);
    public string getProductName(int id);
    public void setProductName(int id, string name);
    public double getProductQuantity(int id);
    public void setProductQuantity(int id, double quantity);
    public double getProductPrice(int id);
    public void setProductPrice(int id, double price);

    public void addEvent(int eid, int cid, int pid, string mode);
    public void deleteEvent(int id);
    public int getEventCustomerId(int id);
    public int getEventProductId(int id);
    public int getEventId(int id);
    public DateTime getEventDate(int id);
    public void setEventCustomerId(int id, int cid);
    public void setEventProductId(int id, int pid);

}
