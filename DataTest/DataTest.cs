namespace DataTest
{
    using Data.abstraction.interfaces;
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestCustomer()
        {   
            DataApi api = new Data.DataCollections();
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
            DataApi api = new Data.DataCollections();
            api.addProduct(12, "Potato", 500, 12.50);
            Assert.AreEqual(api.getProductID(0), 12);
            Assert.AreEqual(api.getProductName(0), "Potato");
            Assert.AreEqual(api.getProductPrice(0), 12.50);
            Assert.AreEqual(api.getProductQuantity(0), 500);
            api.setProductName(0, "Pepper");
            api.setProductPrice(0, 1);
            api.setProductQuantity(0, 0.50);
            Assert.AreEqual(api.getProductName(0), "Pepper");
            Assert.AreEqual(api.getProductPrice(0), 1);
            Assert.AreEqual(api.getProductQuantity(0), 0.50);
        }

        [TestMethod]
        public void TestEvent()
        {
            DataApi api = new Data.DataCollections();
            api.addEvent(0, 231, 321, "b");
            Assert.AreEqual(api.getEventId(0), 0);
            Assert.AreEqual(api.getEventCustomerId(0), 231);
            Assert.AreEqual(api.getEventProductId(0), 321);

        }
    }
}