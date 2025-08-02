using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Models.Enums;

namespace GestaoEstoque.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime DateOrder { get; set; }
        public decimal ValueTotal { get; set; }
        public OrderStatusEnum Status { get; set; }

        public ICollection<OrderItens> OrderItens { get; set; } = new List<OrderItens>();
    }
}