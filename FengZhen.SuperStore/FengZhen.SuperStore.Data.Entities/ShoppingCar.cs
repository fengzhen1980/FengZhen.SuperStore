using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.SuperStore.Data.Entities
{
    public class ShoppingCar
    {
        public string CarId { get; set; }
        public List<ShoppingItem> ItemListInCar { get; set; } = new List<ShoppingItem>();

    }
}
