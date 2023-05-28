namespace DataTest
{
    using AutoMapper;
    using Data.abstraction.interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Datatest
    {

        private string connection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jjani\\source\\repos\\Task2\\DataTest\\Database1.mdf;Integrated Security=True";
       
        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Customer, DataTestClasses.Customer>();
            cfg.CreateMap<Product, DataTestClasses.Product>();
            cfg.CreateMap<Event, DataTestClasses.Event>();
        });


        [TestMethod]
        public void TestdGetters()
        {
            IDataApi api = IDataApi.createDataRepository();
            Assert.AreEqual("Jacob", api.getCustomerFirstName(7));
            Assert.AreEqual("James", api.getCustomerLastName(7));
            Assert.AreEqual("Tomato", api.getProductName(7));
            
        }

        [TestMethod]
        public void TestUpdate()
        {
            IDataApi api = IDataApi.createDataRepository();
            Assert.AreEqual(137.2, api.getProductState(7));
            Assert.AreEqual(250, api.getProductPrice(1));
            api.updateProduct(6, "Cucumber", 100, 100);
            Assert.AreEqual("Cucumber", api.getProductName(6));

        }

        [TestMethod]
        public void TestCount()
        {
            var mapper = configuration.CreateMapper();
            IDataApi api = IDataApi.createDataRepository();
            List<Product> lst = new List<Product>();
            using (DataClasses1DataContext db = new DataClasses1DataContext(connection))
            {
                IQueryable<Product> products = from prod in db.Products
                                                         select prod;

                foreach (Product prod in products)
                {
                    lst.Add(prod);
                }
            }
            Assert.AreEqual(48, lst.Count);
        }

        [TestMethod]
        public void TestMethodSyntax()
        {

            using (DataClasses1DataContext db = new DataClasses1DataContext(connection))
            {
                Product product1 = (from prod in db.Products
                                    where prod.Id == 1
                                               select prod).Single();

                Product product2 = db.Products.Where(p => p.Id == 2).Single();

                Assert.AreEqual(product1.Name, "Potato");
                Assert.AreEqual(product2.Name, "Tomato");
            }
        }
    }
}