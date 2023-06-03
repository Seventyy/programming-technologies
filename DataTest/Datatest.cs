namespace DataTest
{
    using AutoMapper;
    using Data.abstraction.interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Datatest
    {


        public static String getCtString()
        {
            string RPath = @"Database1.mdf";
            string RootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string DatabasePath = Path.Combine(RootPath, RPath);
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DatabasePath};Integrated Security = True;";
        }


        [TestMethod]
        public void TestdGetters()
        {
            IDataApi api = IDataApi.createDataRepository(getCtString());
            Assert.AreEqual("John", api.getCustomerFirstName(1));
            Assert.AreEqual(api.getCustomers().Count(), 3);

        }

        [TestMethod]
        public void TestUpdate()
        {
            IDataApi api = IDataApi.createDataRepository(getCtString());
            Assert.AreEqual(api.getProductPrice(2), 100);
            api.updateProduct(5, "Milk", 5, 5000);
            Assert.AreEqual(api.getProductPrice(5), 5);
        }

        [TestMethod]
        public void TestCount()
        {
            IDataApi api = IDataApi.createDataRepository(getCtString());
            Assert.AreEqual(api.getProducts().Count(), 7);
            Assert.AreEqual(api.getEvents().Count(), 1);
        }

        [TestMethod]
        public void TestMethodSyntax()
        {
            IDataApi api = IDataApi.createDataRepository(getCtString());
            Assert.AreEqual(api.getProductPriceMethod(2), 100);
            Assert.AreEqual(api.getCustomerFirstNameMethod(2), "John");

        }
    }
}