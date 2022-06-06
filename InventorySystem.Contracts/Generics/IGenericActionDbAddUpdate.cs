using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Contracts.Generics
{
    public interface IGenericActionDbAddUpdate<T> where T : class
    {
        Task<Tuple<T, bool>> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
