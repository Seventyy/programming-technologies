namespace DataTest
{

    using Data;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Customer customer = new Customer();
            Assert.AreEqual(customer.getCustomer(1).last_name, "Janicki");
        }
    }
}