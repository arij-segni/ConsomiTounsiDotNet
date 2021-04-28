using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsiDotNet.Models
{
    public class Stock
    {
        public int idStock { get; set; }
        public String nom_stock { get; set; }
        public int quantite { get; set; }
        [DataType(DataType.Date)]
        public DateTime validite { get; set; }
        public float remise { get; set; }
        public float prixdevente { get; set; }
        public float prixremise { get; set; }
        public List<Produit> produit { get; set; }
        public List<Fournisseur> fournisseurs { get; set; }
    }
}