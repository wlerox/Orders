using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Entity.Model
{
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }    
        public string Description { get; set; }
        public string Category { get; set; }
        public int Unit { get; set; }
        public float UnitPrice { get; set; }
        public int Status { get; set; }  
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
