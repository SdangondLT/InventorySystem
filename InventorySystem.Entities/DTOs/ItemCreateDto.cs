using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities.DTOs
{
    public class ItemCreateDto
    {
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public string BarCode { get; set; }
        public int StockBalance { get; set; }
        public string Status { get; set; }
    }
}
