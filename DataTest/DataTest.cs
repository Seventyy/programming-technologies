namespace DataTest
{
    using Data.abstraction.interfaces;
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestCustomer()
        {   
            DataApi api = new Data.DataRepository();
            api.addCustomer(12, "Andrew", "Andrew");
            Assert.AreEqual(api.getCustomerFirstName(0), "Andrew");
            Assert.AreEqual(api.getCustomerLastName(0), "Andrew");
            Assert.AreEqual(api.getCustomerID(0), 12);
            api.setCustomerFirstName(0, "Hammond");
            api.setCustomerLastName(0, "Hammond");
            Assert.AreEqual(api.getCustomerFirstName(0), "Hammond");
            Assert.AreEqual(api.getCustomerLastName(0), "Hammond");
        }

        [TestMethod]
        public void TestProduct()
        {
            DataApi api = new Data.DataRepository();
            api.addProduct(12, "Potato", 12.50);
            Assert.AreEqual(api.getProductID(0), 12);
            Assert.AreEqual(api.getProductName(0), "Potato");
            Assert.AreEqual(api.getProductPrice(0), 12.50);
            api.setProductName(0, "Pepper");
            api.setProductPrice(0, 1);
            Assert.AreEqual(api.getProductName(0), "Pepper");
            Assert.AreEqual(api.getProductPrice(0), 1);
        }

        [TestMethod]
        public void TestEvent()
        {
            DataApi api = new Data.DataRepository();
            api.addEvent(0, 231, 321, "b");
            Assert.AreEqual(api.getEventId(0), 0);
            Assert.AreEqual(api.getEventCustomerId(0), 231);
            Assert.AreEqual(api.getEventProductId(0), 321);
        }

        [TestMethod]
        public void TestState()
        {
            DataApi api = new Data.DataRepository();
            api.addState(0, 0, 5000.50);
            Assert.AreEqual(api.getStateId(0), 0);
            Assert.AreEqual(api.getStateProductId(0), 0);
            Assert.AreEqual(api.getStateQuantity(0), 5000.50);
        }
    }
}