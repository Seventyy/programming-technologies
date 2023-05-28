using Service;

namespace ServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IServiceApi api = new DataService();
            Assert.AreEqual(api.getCustomers().Count(), 0);
        }

        /*  [TestMethod]
          public void TestMethod2()
          {
              IServiceApi api = new DataService();
              api.addProduct(1, "Potato", 12, 300);
              api.addProduct(2, "Tomato", 12, 32);
              api.addProduct(3, "Cucumber", 12, 3300);
              api.addProduct(4, "Milk", 12, 510);
              Assert.AreEqual(api.getProductPrice(1) + api.getProductPrice(2), 24);

          }

          [TestMethod]
          public void TestMethod3()
          {
              IServiceApi api = new DataService();
              api.addEvent(1, 1, 1, "b");
              api.addEvent(2, 1, 1, "s");
              Assert.AreEqual(api.getEvents().Count(), 1);
          }

      }*/
    }
}