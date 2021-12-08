using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using VannuStore.Domain.StoreContext.Enums;

namespace VannuStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _orderItems;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _orderItems = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _orderItems.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            // Validações de estoque, preço, etc
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não possui estoque suficiente");

            var item = new OrderItem(product, quantity);
            _orderItems.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            // Validações entrega e destino

            _deliveries.Add(delivery);
        }

        // To Place an Order -> evento de "criar pedido" em inglês
        public void Place()
        {
            // Gera o número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "")[..12].ToUpper();

            if (_orderItems.Count == 0)
                AddNotification("Order", "Pedido não possui itens");
        }

        // Pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        // Enviar um pedido
        public void Send()
        {
            // A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>
            {
                new Delivery(DateTime.Now.AddDays(5))
            };
            var count = 1;

            // Quebra as entregas
            foreach (var item in _orderItems)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;
            }

            // Envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            // Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        // Cancelar pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.CancelShip());
        }
    }
}