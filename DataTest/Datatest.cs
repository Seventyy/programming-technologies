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
            string _DBPath = Path.Combine(RootPath, RPath);
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True";
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
        }

        [TestMethod]
        public void TestCount()
        {
            IDataApi api = IDataApi.createDataRepository(getCtString());
            Assert.AreEqual(api.getProducts().Count(), 3);
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