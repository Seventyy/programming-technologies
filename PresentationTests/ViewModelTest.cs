using PresentationLayer.ViewModel;

namespace PresentationTests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void CustomerTest()
        {
            DataServiceTest dataService = new DataServiceTest();
            CustomerListViewModel vm = new CustomerListViewModel(dataService);

            vm.Id = 0;
            vm.FirstName = "a";
            vm.LastName = "A";
            vm.AddCommand.Execute(vm);

            vm.Id = 1;
            vm.FirstName = "b";
            vm.LastName = "B";
            vm.AddCommand.Execute(vm);

            Assert.AreEqual("a", dataService.getCustomerFirstName(0));
            Assert.AreEqual("b", dataService.getCustomerFirstName(1));

            vm.DeleteCommand.Execute(vm);

            vm.Id = 1;
            vm.FirstName = "c";
            vm.LastName = "C";
            vm.AddCommand.Execute(vm);

            Assert.AreEqual("c", dataService.getCustomerFirstName(1));
            Assert.AreEqual("C", dataService.getCustomerLastName(1));


            vm.Id = 1;
            vm.FirstName = "d";
            vm.LastName = "D";
            vm.EditCommand.Execute(vm);

            Assert.AreEqual("d", dataService.getCustomerFirstName(1));
            Assert.AreEqual("D", dataService.getCustomerLastName(1));
        }
        [TestMethod]
        public void ProductTest()
        {
            DataServiceTest dataService = new DataServiceTest();
            ProductListViewModel vm = new ProductListViewModel(dataService);

            vm.Id = 0;
            vm.Name = "A";
            vm.Price = 10;
            vm.State = 100;
            vm.AddCommand.Execute(vm);

            vm.Id = 1;
            vm.Name = "B";
            vm.Price = 20;
            vm.State = 200;
            vm.AddCommand.Execute(vm);

            Assert.AreEqual("A", dataService.getProductName(0));
            Assert.AreEqual("B", dataService.getProductName(1));

            vm.DeleteCommand.Execute(vm);

            vm.Id = 1;
            vm.Name = "C";
            vm.Price = 30;
            vm.State = 300;
            vm.AddCommand.Execute(vm);

            Assert.AreEqual("C", dataService.getProductName(1));
            Assert.AreEqual(30, dataService.getProductPrice(1));
            Assert.AreEqual(300, dataService.getProductState(1));

            vm.Name = "D";
            vm.Price = 40;
            vm.State = 400;
            vm.EditCommand.Execute(vm);

            Assert.AreEqual("D", dataService.getProductName(1));
            Assert.AreEqual(40, dataService.getProductPrice(1));
            Assert.AreEqual(400, dataService.getProductState(1));
        }
        [TestMethod]
        public void EventTest()
        {
            DataServiceTest dataService = new DataServiceTest();
            EventListViewModel vm = new EventListViewModel(dataService);

            vm.EventId = 0;
            vm.CustomerId = 10;
            vm.ProductId = 100;
            vm.EventOccurenceTime = DateTime.Now;
            vm.AddCommand.Execute(vm);

            vm.EventId = 1;
            vm.CustomerId = 20;
            vm.ProductId = 200;
            vm.EventOccurenceTime = DateTime.Now;
            vm.AddCommand.Execute(vm);

            Assert.AreEqual(10, dataService.getEventCustomerId(0));
            Assert.AreEqual(20, dataService.getEventCustomerId(1));

            vm.DeleteCommand.Execute(vm);

            vm.EventId = 1;
            vm.CustomerId = 30;
            vm.ProductId = 300;
            vm.EventOccurenceTime = DateTime.Now;
            vm.AddCommand.Execute(vm);

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

            DataServiceTest dataService = new DataServiceTest();
            CustomerListViewModel vm = new CustomerListViewModel(dataService);

            vm.Id = 0;
            vm.FirstName = customer_names[0];
            vm.LastName = customer_lastnames[0];
            vm.AddCommand.Execute(vm);

            vm.Id = 1;
            vm.FirstName = customer_names[1];
            vm.LastName = customer_lastnames[1];
            vm.AddCommand.Execute(vm);

            Assert.AreEqual(customer_names[0], dataService.getCustomerFirstName(0));
            Assert.AreEqual(customer_names[1], dataService.getCustomerFirstName(1));

            vm.DeleteCommand.Execute(vm);

            vm.Id = 1;
            vm.FirstName = customer_names[2];
            vm.LastName = customer_lastnames[2];
            vm.AddCommand.Execute(vm);

            Assert.AreEqual(customer_names[2], dataService.getCustomerFirstName(1));
            Assert.AreEqual(customer_lastnames[2], dataService.getCustomerLastName(1));

            vm.Id = 1;
            vm.FirstName = customer_names[3];
            vm.LastName = customer_lastnames[3];
            vm.EditCommand.Execute(vm);

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

            DataServiceTest dataService = new DataServiceTest();
            ProductListViewModel vm = new ProductListViewModel(dataService);

            vm.Id = 0;
            vm.Name = product_names[0];
            vm.Price = product_prices[0];
            vm.State = product_quantities[0];
            vm.AddCommand.Execute(vm);

            vm.Id = 1;
            vm.Name = product_names[1];
            vm.Price = product_prices[1];
            vm.State = product_quantities[1];
            vm.AddCommand.Execute(vm);

            Assert.AreEqual(product_names[0], dataService.getProductName(0));
            Assert.AreEqual(product_names[1], dataService.getProductName(1));

            vm.DeleteCommand.Execute(vm);

            vm.Id = 1;
            vm.Name = product_names[2];
            vm.Price = product_prices[2];
            vm.State = product_quantities[2];
            vm.AddCommand.Execute(vm);

            Assert.AreEqual(product_names[2], dataService.getProductName(1));
            Assert.AreEqual(product_prices[2], dataService.getProductPrice(1));
            Assert.AreEqual(product_quantities[2], dataService.getProductState(1));

            vm.Name = product_names[3];
            vm.Price = product_prices[3];
            vm.State = product_quantities[3];
            vm.EditCommand.Execute(vm);

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

            DataServiceTest dataService = new DataServiceTest();
            EventListViewModel vm = new EventListViewModel(dataService);

            vm.EventId = 0;
            vm.CustomerId = customer_ids[0];
            vm.ProductId = product_ids[0];
            vm.EventOccurenceTime = DateTime.Now;
            vm.AddCommand.Execute(vm);

            vm.EventId = 1;
            vm.CustomerId = customer_ids[1];
            vm.ProductId = product_ids[1];
            vm.EventOccurenceTime = DateTime.Now;
            vm.AddCommand.Execute(vm);

            Assert.AreEqual(customer_ids[0], dataService.getEventCustomerId(0));
            Assert.AreEqual(customer_ids[1], dataService.getEventCustomerId(1));

            vm.DeleteCommand.Execute(vm);

            vm.EventId = 1;
            vm.CustomerId = customer_ids[2];
            vm.ProductId = product_ids[2];
            vm.EventOccurenceTime = DateTime.Now;
            vm.AddCommand.Execute(vm);

            Assert.AreEqual(customer_ids[2], dataService.getEventCustomerId(1));
            Assert.AreEqual(product_ids[2], dataService.getEventProductId(1));
        }
    }
}
