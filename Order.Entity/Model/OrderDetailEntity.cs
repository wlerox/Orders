using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Entity.Model
{
    public class OrderDetailEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("OrderEntity")]
        public Guid OrderId { get; set; }
        [ForeignKey("ProductEntity")]
        public Guid ProductId { get; set; }
        public int UnitPrice { get; set; }
        public ProductEntity Product { get; set; }
        public OrderEntity Order { get; set; }
    }
}
