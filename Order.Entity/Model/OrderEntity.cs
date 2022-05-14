using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Entity.Model
{
    public class OrderEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public int TotalAmount { get; set; }
        public ICollection<OrderDetailEntity> OrderDetails { get; set; }    
    }
}
