using Data;
using Logic;

namespace LogicTest
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void TestSingleItemBuy()
        {
            Customers customers = new Customers();
            customers.Add(new Customer(0));

            Catalog catalog = new Catalog();
            catalog.Add(new Item(0, "Product 0", 1));

            CatalogManager catalogManager = new CatalogManager(catalog);
            CustomerManager customerManager = new CustomerManager(customers, catalogManager);

            customers.Get(0).AddCartItem(new Item(0, "Product 0", 1));

            customerManager.BuyCart(customers.Get(0));

            Assert.AreEqual(catalog.Get(0).quantity, 0);
        }

        [TestMethod]
        public void TestMultiItemBuy()
        {
            Customers customers = new Customers();
            customers.Add(new Customer(0));
            customers.Add(new Customer(1));
            customers.Add(new Customer(2));

            Catalog catalog = new Catalog();
            catalog.Add(new Item(0, "Product 0", 42));
            catalog.Add(new Item(1, "Product 1", 69));
            catalog.Add(new Item(2, "Product 2", 420));
            catalog.Add(new Item(3, "Product 3", 88));

            CatalogManager catalogManager = new CatalogManager(catalog);
            CustomerManager customerManager = new CustomerManager(customers, catalogManager);

            customers.Get(0).AddCartItem(new Item(0, "Product 0", 20));
            customers.Get(0).AddCartItem(new Item(2, "Product 2", 20));
            customers.Get(0).AddCartItem(new Item(3, "Product 3", 88));
            customers.Get(0).AddCartItem(new Item(1, "Product 1", 96));
            customers.Get(0).AddCartItem(new Item(0, "Product 0", 20));

            customerManager.BuyCart(customers.Get(0));

            Assert.AreEqual(catalog.Get(0).quantity, 2);
            Assert.AreEqual(catalog.Get(1).quantity, 69);
            Assert.AreEqual(catalog.Get(2).quantity, 400);
            Assert.AreEqual(catalog.Get(3).quantity, 0);
        }

        [TestMethod]
        public void TestRandomItemBuy()
        {
            Random rng = new Random();

            int customer_id = rng.Next();
            int item_id = rng.Next();
            int item_catalog_quantity = rng.Next();
            int item_bought_quantity = rng.Next();

            Customers customers = new Customers();
            customers.Add(new Customer(customer_id));

            Catalog catalog = new Catalog();
            catalog.Add(new Item(item_id, "Product 0", item_catalog_quantity));

            CatalogManager catalogManager = new CatalogManager(catalog);
            CustomerManager customerManager = new CustomerManager(customers, catalogManager);

            customers.Get(0).AddCartItem(new Item(item_id, "Product 0", item_bought_quantity));

            customerManager.BuyCart(customers.Get(0));

            if (item_catalog_quantity >= item_bought_quantity)
                Assert.AreEqual(catalog.Get(0).quantity, item_catalog_quantity - item_bought_quantity);
            else
                Assert.AreEqual(catalog.Get(0).quantity, item_catalog_quantity);
        }
    }
}