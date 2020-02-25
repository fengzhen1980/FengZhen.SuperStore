using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.Data.Entities
{
    public class ReceiptItem
    {
        public string ReceiptItemId { get; set; }
        public string ReceiptItemName { get; set; }
        public decimal ReceiptPriceOne { get; set; }
        public decimal ReceiptCount { get; set; }
        public decimal ReceiptItemsPrice { get; set; }
    }
}
