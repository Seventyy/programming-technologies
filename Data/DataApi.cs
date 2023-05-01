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
    public String getCustomerLastName(int id);
    public int getCustomerID(int id);
  
}
