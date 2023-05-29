using Service;

namespace ServiceTests
{
    [TestClass]
    public class ServiceTest
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
            api.addProduct(1, "Tomato", 123, 250);
            api.addProduct(2, "Potato", 123, 250);
            api.addProduct(3, "Cucumber", 123, 250);
            Assert.AreEqual(api.getProductName(2), "Cucumber"); 
        }

        [TestMethod]
        public void TestMethod3()
        {
            IServiceApi api = new TestDataService();
            api.addEvent(0, 1, 1, "b");
            api.addEvent(2, 2, 2, "r");
            api.addEvent(3, 3, 3, "b");
            Assert.AreEqual(api.getEventProductId(0), 0) ;
        }

    }
}