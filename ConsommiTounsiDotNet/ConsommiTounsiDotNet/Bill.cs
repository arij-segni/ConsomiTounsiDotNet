using ConsommiTounsiDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsiDotNet
{
    public class Bill
    {
        public Bill(int id, float delivFees, Users user, Order order)
        {
            this.id = id;
            this.delivFees = delivFees;
            this.user = user;
            this.order = order;
        }

        public Bill()
        {
        }

        public int id { get; set; }
        public float delivFees { get; set; }
        public virtual Users user { get; set; }
        public virtual Order order { get; set; }

    }
}