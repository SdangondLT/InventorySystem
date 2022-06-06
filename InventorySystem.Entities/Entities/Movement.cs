using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities.Entities
{
    public class Movement
    {
        public int IdMovement { get; set; }
        public DateTime Date { get; set; }
        public int IdItem { get; set; }
        public int Quantity { get; set; }
        public string Concept { get; set; }
        public string Status { get; set; }
        public int TypeOfMovement { get; set; }
    }
}
