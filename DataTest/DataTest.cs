namespace DataTest
{
    using Data.abstraction.interfaces;
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            DataApi api = DataApi.createDataRepository();
            api.addCustomer(12, "Andrew", "Andrew");
            Assert.AreEqual(api.getCustomerFirstName(12), "Andrew");
            Assert.AreEqual(api.getCustomerLastName(12), "Andrew");
            Assert.AreEqual(api.getCustomerID(0), 12);
            api.updateCustomer(0, 12, "Hammond", "Hammond");
            Assert.AreEqual(api.getCustomerFirstName(12), "Hammond");
            Assert.AreEqual(api.getCustomerLastName(12), "Hammond");
        }

        [TestMethod]
        public void TestProduct()
        {
            DataApi api = new Data.DataRepository();
            api.addProduct(12, "Potato", 12.50);
            Assert.AreEqual(api.getProductID(0), 12);
            Assert.AreEqual(api.getProductName(0), "Potato");
            Assert.AreEqual(api.getProductPrice(0), 12.50);
            api.updateProduct(0,"Pepper", 1);
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
            api.updateState(0, 1000);
            Assert.AreEqual(api.getStateId(0), 0);
            Assert.AreEqual(api.getStateProductId(0), 0);
            Assert.AreEqual(api.getStateQuantity(0), 1000);
        }


        private string RandomString()
        {
            Random rand = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        [TestMethod]
        public void TestCustomerRandom()
        {
            string[] customer_names = new string[] { RandomString(), RandomString() };
            string[] customer_lastnames = new string[] { RandomString(), RandomString() };

            DataApi api = DataApi.createDataRepository();

            api.addCustomer(12, customer_names[0], customer_lastnames[0]);

            Assert.AreEqual(api.getCustomerFirstName(12), customer_names[0]);
            Assert.AreEqual(api.getCustomerLastName(12), customer_lastnames[0]);
            Assert.AreEqual(api.getCustomerID(0), 12);

            api.updateCustomer(0, 12, customer_names[1], customer_lastnames[1]);

            Assert.AreEqual(api.getCustomerFirstName(12), customer_names[1]);
            Assert.AreEqual(api.getCustomerLastName(12), customer_lastnames[1]);
        }

        [TestMethod]
        public void TestProductRandom()
        {
            Random rand = new Random();

            string[] product_names = new string[] { RandomString(), RandomString() };
            double[] product_prices = new double[] { rand.NextDouble(), rand.NextDouble() };
            int[] products_ids = new int[] { rand.Next(), rand.Next() };

            DataApi api = new Data.DataRepository();

            api.addProduct(products_ids[0], product_names[0], product_prices[0]);

            Assert.AreEqual(api.getProductID(0), products_ids[0]);
            Assert.AreEqual(api.getProductName(0), product_names[0]);
            Assert.AreEqual(api.getProductPrice(0), product_prices[0]);

            api.updateProduct(0, product_names[1], product_prices[1]);

            Assert.AreEqual(api.getProductName(0), product_names[1]);
            Assert.AreEqual(api.getProductPrice(0), product_prices[1]);
        }

        [TestMethod]
        public void TestEventRandom()
        {
            Random rand = new Random();

            int customer_id = rand.Next();
            int product_id = rand.Next();

            DataApi api = new Data.DataRepository();
            api.addEvent(0, customer_id, product_id, "b");
            Assert.AreEqual(api.getEventId(0), 0);
            Assert.AreEqual(api.getEventCustomerId(0), customer_id);
            Assert.AreEqual(api.getEventProductId(0), product_id);
        }

        [TestMethod]
        public void TestStateRandom()
        {
            Random rand = new Random();

            double[] state_quantities = new double[] { rand.NextDouble(), rand.NextDouble() };

            DataApi api = new Data.DataRepository();

            api.addState(0, 0, state_quantities[0]);
            api.updateState(0, state_quantities[1]);

            Assert.AreEqual(api.getStateId(0), 0);
            Assert.AreEqual(api.getStateProductId(0), 0);
            Assert.AreEqual(api.getStateQuantity(0), state_quantities[1]);
        }
    }
}