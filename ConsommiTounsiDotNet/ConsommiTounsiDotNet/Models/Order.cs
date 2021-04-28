using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsiDotNet.Models
{
    public class Order
    {
        public Order()
        {
        }

        public Order(int id, float amount, float delivFees, LocalDateTime orderDate, OrderStatus orderStatus, PaymentMethod paymentMethod, ICollection<CartItem> cartItems, Users user, Bill bill)
        {
            this.id = id;
            this.amount = amount;
            DelivFees = delivFees;
            this.orderDate = orderDate;
            this.orderStatus = orderStatus;
            this.paymentMethod = paymentMethod;
            this.cartItems = cartItems;
            this.user = user;
            this.bill = bill;
        }

        public int id { get; set; }
        public float amount { get; set; }

        public float DelivFees { get; set; }

        public LocalDateTime orderDate { get; set; }

        public OrderStatus orderStatus { get; set; }

        public PaymentMethod paymentMethod { get; set; }

        public virtual ICollection<CartItem> cartItems { get; set; }

        public virtual Users user { get; set; }

        public virtual Bill bill { get; set; }

    }
}