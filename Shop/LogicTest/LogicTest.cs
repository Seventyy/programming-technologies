using Data;
using Data.abstraction.interfaces;
using Logic;

namespace LogicTest
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void TestSimple()
        {
            DataRepository dataRepository = new DataRepository();
            ApplicationLogic applicationLogic = new ApplicationLogic(dataRepository);

            Product product0 = new Product(0, "P1", 1);
            dataRepository.addProduct(0, "P1", 1);
            dataRepository.addState(0, 0, 1);

            Customer customer0 = new Customer(0, "C1", "C1");
            dataRepository.addCustomer(0, "C1", "C1");

            applicationLogic.Buy(product0, customer0);

            Assert.AreEqual(dataRepository.getStateQuantity(0), 0);
            Assert.AreEqual(dataRepository.getEventProductId(0), 0);
        }

        [TestMethod]
        public void TestMultiple()
        {
            DataRepository dataRepository = new DataRepository();
            ApplicationLogic applicationLogic = new ApplicationLogic(dataRepository);

            Product product0 = new Product(0, "P0", 1);
            Product product1 = new Product(1, "P1", 2);
            Product product2 = new Product(2, "P2", 3);
            Product product3 = new Product(3, "P3", 10);

            dataRepository.addProduct(0, "P0", 1);
            dataRepository.addProduct(1, "P1", 2);
            dataRepository.addProduct(2, "P2", 3);
            dataRepository.addProduct(3, "P3", 10);

            dataRepository.addState(0, 0, 10);
            dataRepository.addState(1, 1, 20);
            dataRepository.addState(2, 2, 32);
            dataRepository.addState(3, 3, 450);

            Customer customer0 = new Customer(0, "CF0", "CL0");
            Customer customer1 = new Customer(1, "CF1", "CL1");
            Customer customer2 = new Customer(2, "CF2", "CL2");
            Customer customer3 = new Customer(3, "CF3", "CL3");

            dataRepository.addCustomer(0, "CF0", "CL0");
            dataRepository.addCustomer(1, "CF1", "CL1");
            dataRepository.addCustomer(2, "CF2", "CL2");
            dataRepository.addCustomer(3, "CF3", "CL3");

            applicationLogic.Buy(product0, customer0);
            applicationLogic.Buy(product1, customer1, 14);
            applicationLogic.Buy(product2, customer2, 32);
            applicationLogic.Buy(product3, customer3, 420);

            Assert.AreEqual(dataRepository.getStateQuantity(0), 9);
            Assert.AreEqual(dataRepository.getStateQuantity(1), 6);
            Assert.AreEqual(dataRepository.getStateQuantity(2), 0);
            Assert.AreEqual(dataRepository.getStateQuantity(3), 30);

            Assert.AreEqual(dataRepository.getEventProductId(0), 0);
            Assert.AreEqual(dataRepository.getEventProductId(1), 1);
            Assert.AreEqual(dataRepository.getEventProductId(2), 2);
            Assert.AreEqual(dataRepository.getEventProductId(3), 3);
        }

        private string RandomString()
        {
            Random rand = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        [TestMethod]
        public void TestRandom()
        {
            Random rand = new Random();

            string[] product_names = new string[] { RandomString(), RandomString(), RandomString(), RandomString() };
            string[] customer_names = new string[] { RandomString(), RandomString(), RandomString(), RandomString() };
            string[] customer_lastnames = new string[] { RandomString(), RandomString(), RandomString(), RandomString() };

            double[] product_prices = new double[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble() };
            double[] state_quantities = new double[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble() };
            double[] buy_ammount = new double[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble() };

            DataRepository dataRepository = new DataRepository();
            ApplicationLogic applicationLogic = new ApplicationLogic(dataRepository);

            Product product0 = new Product(0, product_names[0], product_prices[0]);
            Product product1 = new Product(1, product_names[1], product_prices[1]);
            Product product2 = new Product(2, product_names[2], product_prices[2]);
            Product product3 = new Product(3, product_names[3], product_prices[3]);

            dataRepository.addProduct(0, product_names[0], product_prices[0]);
            dataRepository.addProduct(1, product_names[1], product_prices[1]);
            dataRepository.addProduct(2, product_names[2], product_prices[2]);
            dataRepository.addProduct(3, product_names[3], product_prices[3]);

            dataRepository.addState(0, 0, state_quantities[0]);
            dataRepository.addState(1, 1, state_quantities[1]);
            dataRepository.addState(2, 2, state_quantities[2]);
            dataRepository.addState(3, 3, state_quantities[3]);

            Customer customer0 = new Customer(0, customer_names[0], customer_lastnames[0]);
            Customer customer1 = new Customer(1, customer_names[1], customer_lastnames[1]);
            Customer customer2 = new Customer(2, customer_names[2], customer_lastnames[2]);
            Customer customer3 = new Customer(3, customer_names[3], customer_lastnames[3]);

            dataRepository.addCustomer(0, customer_names[0], customer_lastnames[0]);
            dataRepository.addCustomer(1, customer_names[1], customer_lastnames[1]);
            dataRepository.addCustomer(2, customer_names[2], customer_lastnames[2]);
            dataRepository.addCustomer(3, customer_names[3], customer_lastnames[3]);

            applicationLogic.Buy(product0, customer0, buy_ammount[0]);
            applicationLogic.Buy(product1, customer1, buy_ammount[1]);
            applicationLogic.Buy(product2, customer2, buy_ammount[2]);
            applicationLogic.Buy(product3, customer3, buy_ammount[3]);

            Assert.AreEqual(dataRepository.getStateQuantity(0), state_quantities[0] - buy_ammount[0]);
            Assert.AreEqual(dataRepository.getStateQuantity(1), state_quantities[1] - buy_ammount[1]);
            Assert.AreEqual(dataRepository.getStateQuantity(2), state_quantities[2] - buy_ammount[2]);
            Assert.AreEqual(dataRepository.getStateQuantity(3), state_quantities[3] - buy_ammount[3]);

            Assert.AreEqual(dataRepository.getEventProductId(0), 0);
            Assert.AreEqual(dataRepository.getEventProductId(1), 1);
            Assert.AreEqual(dataRepository.getEventProductId(2), 2);
            Assert.AreEqual(dataRepository.getEventProductId(3), 3);
        }
    }
}