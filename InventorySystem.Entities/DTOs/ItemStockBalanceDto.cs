using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities.DTOs
{
    public class ItemStockBalanceDto
    {
        public int IdItem { get; set; }
        public string Description { get; set; }
        public int StockBalance { get; set; }
    }
}
