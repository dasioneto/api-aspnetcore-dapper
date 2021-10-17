using System;
using System.Collections.Generic;

namespace VannuStore.Domain.StoreContext
{
    public class Order
    {
        public Customer MyProperty { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public IList<OrderItem> Items { get; set; }
        public IList<Delivery> Deliveries { get; set; }

        // To Place an Order -> evento de "fechar pedido" em inglês
        public void Place() { }
    }
}