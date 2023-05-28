namespace DataTest
{
    using AutoMapper;
    using Data.abstraction.interfaces;

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
            IDataApi api = IDataApi.createDataRepository();
            /*api.addProduct(2, "Tomato", 12.50, 137.2);*/
            Assert.AreEqual("Jacob", api.getCustomerFirstName(7));
            Assert.AreEqual("James", api.getCustomerLastName(7));
        }

        [TestMethod]
        public void TestdbProduct()
        {
            var mapper = configuration.CreateMapper();

            using (DataClasses1DataContext db = new DataClasses1DataContext(connection))
            {
                IQueryable<Product> product = from prod in db.Products
                               where prod.Name == "Potato"
                              select prod;
                foreach (Product p in product)
                {
                    Assert.AreEqual(p.Name, "Potato");
                }
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