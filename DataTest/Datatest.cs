namespace DataTest
{
    using AutoMapper;

    [TestClass]
    public class Datatest
    {

        private string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jjani\\source\\repos\\Task2\\DataTest\\Database1.mdf;Integrated Security=True";
       
        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DataTestClasses.Customer, Customer>();
            cfg.CreateMap<DataTestClasses.Product, Product>();
            cfg.CreateMap<DataTestClasses.Event, Event>();
        });


        [TestMethod]
        public void TestdbCustomer()
        {
            var mapper = configuration.CreateMapper();

            using (DataClasses1DataContext db = new DataClasses1DataContext(connection))
            {
                DataTestClasses.Customer c = new DataTestClasses.Customer(2, "Jacob", "James");
                Customer customer = mapper.Map<Customer>(c);
               /* db.Customers.InsertOnSubmit(customer);*/
                db.SubmitChanges();
            }
        }

        [TestMethod]
        public void TestdbProduct()
        {
            var mapper = configuration.CreateMapper();

            using (DataClasses1DataContext db = new DataClasses1DataContext(connection))
            {
                Product product = (from prod in db.Products
                               where prod.Name == "Potato"
                              select prod).Single();

                Assert.AreEqual(product.Name, "Potato");
            }
        }

        [TestMethod]
        public void TestdbEvent()
        {
            var mapper = configuration.CreateMapper();

            using (DataClasses1DataContext db = new DataClasses1DataContext(connection))
            {
                Event e = (from eve in db.Events
                                   where eve.ProductId == 1
                                   select eve).Single();

                Assert.AreEqual(e.CustomerId, 1 );

            }
        }
    }
}