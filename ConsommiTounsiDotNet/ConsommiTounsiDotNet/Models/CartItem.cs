using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsiDotNet.Models
{
    public class CartItem
    {
        public CartItem(int id, int quanity, int stat, float amount, Product product, Users user, Order order)
        {
            this.id = id;
            this.quanity = quanity;
            this.stat = stat;
            this.amount = amount;
            this.product = product;
            this.user = user;
            this.order = order;
        }

        public CartItem()
        {
        }

        public int id { get; set; }
        public int quanity { get; set; }
        public int stat { get; set; }
        public float amount { get; set; }

        public virtual Product product { get; set; }

        public virtual Users user { get; set; }

        public virtual Order order { get; set; }

        

    }
}