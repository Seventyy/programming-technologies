using Task1;

namespace TestTask1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Greeter greeter = new Greeter();
            Assert.AreEqual(greeter.GetGreeting(), "Hello World");
        }
    }
}