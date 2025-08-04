using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEstoque.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePurchase { get; set; }
        public decimal PriceSale { get; set; }
        public string Description { get; set; }
        public Stock Stock { get; set; }

        public ICollection<OrderItens> OrderItens { get; set; } = new List<OrderItens>();
    }
}