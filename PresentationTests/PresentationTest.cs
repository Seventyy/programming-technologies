namespace PresentationTests
{
    [TestClass]
    public class PresentationTest
    {
        [TestMethod]
        public void CustomerTest()
        {
            DataService dataService = new DataService();
            CustomerModel c1 = new CustomerModel(dataService, 0, "a", "A");
            CustomerModel c2 = new CustomerModel(dataService, 1, "b", "B");

            c1.Add();
            c2.Add();

            Assert.AreEqual("a", dataService.getCustomerFirstName(0));
            Assert.AreEqual("b", dataService.getCustomerFirstName(1));

            c2.Delete();

            CustomerModel c3 = new CustomerModel(dataService, 1, "c", "C");
            c3.Add();

            Assert.AreEqual("c", dataService.getCustomerFirstName(1));
            Assert.AreEqual("C", dataService.getCustomerLastName(1));

            c3.Edit(1, "d", "D");

            Assert.AreEqual("d", dataService.getCustomerFirstName(1));
            Assert.AreEqual("D", dataService.getCustomerLastName(1));
        }
        [TestMethod]
        public void ProductTest()
        {
            DataService dataService = new DataService();
            ProductModel p1 = new ProductModel(dataService, 0, "A", 10, 100);
            ProductModel p2 = new ProductModel(dataService, 1, "B", 20, 200);

            p1.Add();
            p2.Add();

            Assert.AreEqual("A", dataService.getProductName(0));
            Assert.AreEqual("B", dataService.getProductName(1));

            p2.Delete();

            ProductModel p3 = new ProductModel(dataService, 1, "C", 30, 300);
            p3.Add();

            Assert.AreEqual("C", dataService.getProductName(1));
            Assert.AreEqual(30, dataService.getProductPrice(1));
            Assert.AreEqual(300, dataService.getProductState(1));

            p3.Edit("D", 40, 400);

            Assert.AreEqual("D", dataService.getProductName(1));
            Assert.AreEqual(40, dataService.getProductPrice(1));
            Assert.AreEqual(400, dataService.getProductState(1));
        }
        [TestMethod]
        public void EventTest()
        {
            DataService dataService = new DataService();
            EventModel c1 = new EventModel(dataService, 0, 10, 100, DateTime.Now);
            EventModel c2 = new EventModel(dataService, 1, 20, 200, DateTime.Now);

            c1.Add();
            c2.Add();

            Assert.AreEqual(10, dataService.getEventCustomerId(0));
            Assert.AreEqual(20, dataService.getEventCustomerId(1));

            c2.Delete();

            EventModel c3 = new EventModel(dataService, 1, 30, 300, DateTime.Now);
            c3.Add();

            Assert.AreEqual(30, dataService.getEventCustomerId(1));
            Assert.AreEqual(300, dataService.getEventProductId(1));
        }

        private string RandomString()
        {
            Random rand = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        [TestMethod]
        public void CustomerTestRandom()
        {
            Random rand = new Random();

            string[] customer_names = new string[] { RandomString(), RandomString(), RandomString(), RandomString() };
            string[] customer_lastnames = new string[] { RandomString(), RandomString(), RandomString(), RandomString() };


            DataService dataService = new DataService();
            CustomerModel c1 = new CustomerModel(dataService, 0, customer_names[0], customer_lastnames[0]);
            CustomerModel c2 = new CustomerModel(dataService, 1, customer_names[1], customer_lastnames[1]);

            c1.Add();
            c2.Add();

            Assert.AreEqual(customer_names[0], dataService.getCustomerFirstName(0));
            Assert.AreEqual(customer_names[1], dataService.getCustomerFirstName(1));

            c2.Delete();

            CustomerModel c3 = new CustomerModel(dataService, 1, customer_names[2], customer_lastnames[2]);
            c3.Add();

            Assert.AreEqual(customer_names[2], dataService.getCustomerFirstName(1));
            Assert.AreEqual(customer_lastnames[2], dataService.getCustomerLastName(1));

            c3.Edit(1, customer_names[3], customer_lastnames[3]);

            Assert.AreEqual(customer_names[3], dataService.getCustomerFirstName(1));
            Assert.AreEqual(customer_lastnames[3], dataService.getCustomerLastName(1));
        }
        [TestMethod]
        public void ProductTestRandom()
        {
            Random rand = new Random();

            string[] product_names = new string[] { RandomString(), RandomString(), RandomString(), RandomString() };
            double[] product_prices = new double[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble() };
            double[] product_quantities = new double[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble() };

            DataService dataService = new DataService();
            ProductModel p1 = new ProductModel(dataService, 0, product_names[0], product_prices[0], product_quantities[0]);
            ProductModel p2 = new ProductModel(dataService, 1, product_names[1], product_prices[1], product_quantities[1]);

            p1.Add();
            p2.Add();

            Assert.AreEqual(product_names[0], dataService.getProductName(0));
            Assert.AreEqual(product_names[1], dataService.getProductName(1));

            p2.Delete();

            ProductModel p3 = new ProductModel(dataService, 1, product_names[2], product_prices[2], product_quantities[2]);
            p3.Add();

            Assert.AreEqual(product_names[2], dataService.getProductName(1));
            Assert.AreEqual(product_prices[2], dataService.getProductPrice(1));
            Assert.AreEqual(product_quantities[2], dataService.getProductState(1));

            p3.Edit(product_names[3], product_prices[3], product_quantities[3]);

            Assert.AreEqual(product_names[3], dataService.getProductName(1));
            Assert.AreEqual(product_prices[3], dataService.getProductPrice(1));
            Assert.AreEqual(product_quantities[3], dataService.getProductState(1));
        }
        [TestMethod]
        public void EventTestRandom()
        {
            Random rand = new Random();

            int[] customer_ids = new int[] { rand.Next(), rand.Next(), rand.Next() };
            int[] product_ids = new int[] { rand.Next(), rand.Next(), rand.Next() };


            DataService dataService = new DataService();
            EventModel c1 = new EventModel(dataService, 0, customer_ids[0], product_ids[0], DateTime.Now);
            EventModel c2 = new EventModel(dataService, 1, customer_ids[1], product_ids[1], DateTime.Now);

            c1.Add();
            c2.Add();

            Assert.AreEqual(customer_ids[0], dataService.getEventCustomerId(0));
            Assert.AreEqual(customer_ids[1], dataService.getEventCustomerId(1));

            c2.Delete();

            EventModel c3 = new EventModel(dataService, 1, customer_ids[2], product_ids[2], DateTime.Now);
            c3.Add();

            Assert.AreEqual(customer_ids[2], dataService.getEventCustomerId(1));
            Assert.AreEqual(product_ids[2], dataService.getEventProductId(1));
        }
    }
}