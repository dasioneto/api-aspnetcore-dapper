using Microsoft.VisualStudio.TestTools.UnitTesting;
using VannuStore.Domain.StoreContext.Entities;
using VannuStore.Domain.StoreContext.ValueObjects;

namespace VannuStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Dasio", "Neto");
            var document = new Document("12345678911");
            var email = new Email("dasio.neto@dasio.neto");

            var customer = new Customer(name, document, email, "19123456789");

            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado sem fio", "image.png", 100, 10);
            var impressora = new Product("Impressora", "Impressora HP", "image.png", 60.90M, 5);
            var cadeira = new Product("Cadeira", "Cadeira Gamer", "image.png", 980.0M, 5);

            var order = new Order(customer);
            
            order.AddItem(mouse, 3);
            order.AddItem(teclado, 5);
            order.AddItem(impressora, 2);
            order.AddItem(cadeira, 1);

            // Realizar o pedido
            order.Place();

            // Verificar se o pedido é válido

            // Simular pagamento
            order.Pay();

            // Simular envio
            order.Send();

            // Simular cancelamento
            order.Cancel();
        }
    }
}
