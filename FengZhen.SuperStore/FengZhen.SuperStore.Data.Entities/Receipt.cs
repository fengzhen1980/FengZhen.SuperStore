using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.Data.Entities
{
    public class Receipt
    {
        public string ReceiptId { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
        public decimal TotalPrice { get; set; }
        public int TotalItems { get; set; }

    }
}
