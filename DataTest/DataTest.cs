namespace DataTest
{
    using Data.abstraction.interfaces;
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestItem()
        {   
            DataApi api = new Data.DataCollections();
            api.addCustomer(12, "Andrew", "Andrew");
            Assert.AreEqual(api.getCustomerFirstName(0), "Andrew");
            Assert.AreEqual(api.getCustomerLastName(0), "Andrew");
            Assert.AreEqual(api.getCustomerID(0), 12);
        }
    }
}