﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DTO
{
    public class CartItemDTO
    {
        public int? CartId { get; set; }
        public int? CustomerId { get; set; }

        public int? FoodItemId { get; set; }

        public decimal? Price { get; set; }

        public int? Qty { get; set; }

        public decimal? Amount { get; set; }
    }
}
