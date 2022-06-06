using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities.Entities
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public string BarCode { get; set; }
        public int StockBalance { get; set; }//saldo de existencia
        public string Status { get; set; }
    }
}
