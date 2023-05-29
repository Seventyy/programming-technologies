using Service;

namespace ServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IServiceApi api = new TestDataService();
            api.addCustomer(1, "John", "Smiths");
            api.addCustomer(2, "John", "Decker");
            api.addCustomer(3, "John", "Stones");
            Assert.AreEqual(api.getCustomerFirstName(1),  "John");;
        }

        [TestMethod]
        public void TestMethod2()
        {
            IServiceApi api = new TestDataService();
            api.addCustomer(1, "John", "Smiths");
            api.addCustomer(2, "Jase", "Decker");
            api.addCustomer(3, "John", "Stones");
            Assert.AreEqual(api.getCustomerFirstName(1), "Jase"); ;
        }

        [TestMethod]
        public void TestMethod3()
        {
            IServiceApi api = new TestDataService();
            api.addCustomer(1, "John", "Smiths");
            api.addCustomer(2, "John", "Decker");
            api.addCustomer(3, "John", "Stones");
            Assert.AreEqual(api.getCustomerFirstName(1), "John"); ;
        }

    }
}