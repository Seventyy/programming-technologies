using DataLayer;

namespace Data
{
    public class Customer
    {
        DataClasses1DataContext db;

        public Customer() {
            db = new DataClasses1DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jjani\source\repos\Task2\DataLayer\Database1.mdf;Integrated Security=True");
        }
        public void addCustomer()
        { 
            db.Customers.InsertOnSubmit(new DataLayer.Customer { Id = 1, first_name = "Jakub", last_name = "Janicki" });
            db.SubmitChanges();
        }

        public DataLayer.Customer getCustomer(int id) {
            return db.Customers.FirstOrDefault(e => e.Id.Equals(id));
        }

    }
}