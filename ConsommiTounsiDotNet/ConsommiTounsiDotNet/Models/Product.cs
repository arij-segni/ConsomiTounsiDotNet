using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsiDotNet.Models
{
    public class Product
    {
        public Product(int id, string name, float price ,string image)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.image = image;
        }

        public Product()
        {
        }

        public int id { get; set; }
        public String name { get; set; }
        public float price { get; set; }

        public string image { get; set; }
    }
}