﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DataAccess.Model
{
    public class ProductDetail
    {
        public Guid ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }
    }
}
