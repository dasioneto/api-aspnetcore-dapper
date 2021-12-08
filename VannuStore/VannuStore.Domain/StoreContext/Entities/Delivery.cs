using FluentValidator;
using System;
using VannuStore.Domain.StoreContext.Enums;

namespace VannuStore.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }

        public void CancelShip()
        {
            if (Status != EDeliveryStatus.Delivered)
                Status = EDeliveryStatus.Canceled;
        }
    }
}