using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEstoque.Models
{
    public class OrderItens
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int Amount { get; set; }
        public decimal PriceUnit { get; set; }
    }
}