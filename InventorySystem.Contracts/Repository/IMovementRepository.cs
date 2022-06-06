using InventorySystem.Contracts.Generics;
using InventorySystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Contracts.Repository
{
    public interface IMovementRepository : IGenericActionDbAddUpdate<Movement>, IGenericActionDbQuery<Movement>
    {

    }
}
