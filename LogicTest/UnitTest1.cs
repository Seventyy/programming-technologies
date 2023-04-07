namespace LogicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Logic.Logic l1 = new Logic.Logic();

            Assert.AreEqual(l1.returnOne(), 1);
        }
    }
}