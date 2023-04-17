namespace DataTest
{
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]

    internal class DataTestRandom
    {
        [TestMethod]
        public void TestItemRandom()
        {
            Random rng = new Random();

            int item_id = rng.Next();
            int item_quantity = rng.Next();

            Assert.ThrowsException<ArgumentNullException>(() => new Item(-1, "potato", 120));
            Item item = new Item(item_id, "Product", item_quantity);
            Assert.AreEqual(item.GetItemProperties(), (item_id, "Product", item_quantity));
            item.setQuantity(item_quantity);
            item.setQuantity(-1);
            Assert.AreEqual(item.quantity, item_quantity);
        }

        [TestMethod]
        public void TestCatalogRandom()
        {
            Random rng = new Random();

            int item_id_1 = rng.Next();
            int item_id_2 = rng.Next();
            int item_id_3 = rng.Next();
            int item_quantity_1 = rng.Next();
            int item_quantity_2 = rng.Next();
            int item_quantity_3 = rng.Next();

            Catalog catalog = new Catalog();
            Item item = new Item(item_id_1, "Product1", item_quantity_1);
            Item item1 = new Item(item_id_2, "Product2", item_quantity_2);
            Item item2 = new Item(item_id_3, "Product3", item_quantity_3);
            catalog.Add(item);
            catalog.Add(item1);
            catalog.Add(item2);
            Assert.AreEqual(catalog.GetAll().Count, 3);
            catalog.Remove(2);
            Assert.AreEqual(catalog.GetAll().Count, 2);
            Assert.IsNull(catalog.Get(2));
        }

        [TestMethod]
        public void TestCustomerRandom()
        {
            Random rng = new Random();

            int item_id_1 = rng.Next();
            int item_id_2 = rng.Next();
            int item_id_3 = rng.Next();
            int item_quantity_1 = rng.Next();
            int item_quantity_2 = rng.Next();
            int item_quantity_3 = rng.Next();
            int customer_id = rng.Next();

            Catalog catalog = new Catalog();
            Item item = new Item(item_id_1, "Product1", item_quantity_1);
            Item item1 = new Item(item_id_2, "Product2", item_quantity_2);
            Item item2 = new Item(item_id_3, "Product3", item_quantity_3);
            catalog.Add(item);
            catalog.Add(item1);
            catalog.Add(item2);
            Assert.ThrowsException<ArgumentNullException>(() => new Customer(-1));
            Customer customer = new Customer(customer_id);
            customer.AddCartItem(catalog.Get(0));
            customer.AddCartItem(catalog.Get(1));
            Assert.AreEqual(customer.GetCartItem(0), item);
            customer.RemoveCartItem(1);
            Assert.IsNull(customer.GetCartItem(1));

            Assert.AreEqual(customer.GetCustomerProperties().Item1, item_id_1);
        }

        [TestMethod]
        public void TestCustomersRandom()
        {
            Random rng = new Random();

            int customer_id_1 = rng.Next();
            int customer_id_2 = rng.Next();
            int customer_id_3 = rng.Next();

            Customers customers = new Customers();
            Customer customer = new Customer(customer_id_1);
            Customer customer1 = new Customer(customer_id_2);
            Customer customer2 = new Customer(customer_id_3);
            customers.Add(customer);
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Remove(1);
            Assert.AreEqual(customers.Get(1), customer2);
            Assert.AreEqual(customers.GetAll().Count, 2);
        }

        [TestMethod]
        public void TestEventRandom()
        {
            Random rng = new Random();

            int item_id_1 = rng.Next();
            int item_quantity_1 = rng.Next();

            Event event1 = new Event(new Item(item_id_1, "Product1", item_quantity_1), Event.states.passive);
            event1.setState(Event.states.active);
            Assert.AreEqual(event1.state, Event.states.active);
        }

        [TestMethod]
        public void TestEventsRandom()
        {
            Random rng = new Random();

            int item_id = rng.Next();
            int item_quantity = rng.Next();

            Events events = new Events();
            Event event1 = new Event(new Item(item_id, "Product1", item_quantity), Event.states.passive);
            Event event2 = new Event(new Item(item_id, "Product1", item_quantity), Event.states.passive);
            Event event3 = new Event(new Item(item_id, "Product1", item_quantity), Event.states.passive);
            events.Add(event1);
            events.Add(event2);
            events.Add(event3);
            events.Remove(1);
            Assert.AreEqual(events.GetAll().Count, 2);
            Assert.IsNull(events.Get(2));
        }
    }
}
