using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.Data.Entities
{
    public class ShoppingItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemCount { get; set; } = 1;
        public decimal ItemSumPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
