using Microsoft.VisualStudio.TestTools.UnitTesting;
using VannuStore.Domain.StoreContext.Entities;

namespace VannuStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Dasio", "Neto", "12345678901", "dasio.teste@neto.com", "12123456789", "Rua Xpto, 666");
        }
    }
}
