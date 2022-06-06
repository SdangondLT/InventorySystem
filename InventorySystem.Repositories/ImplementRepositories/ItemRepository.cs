using InventorySystem.Contracts.Repository;
using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Repositories.ImplementRepositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly SqlServerContext _context;
        public ItemRepository()
        {
            _context = new SqlServerContext();
        }
        public async Task<Tuple<Item, bool>> AddAsync(Item entity)
        {
            try
            {
                var result = _context.Item.Add(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Item>> GetAllAsync()
        {
            try
            {
                var result = await _context.Item.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Item.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Item>> GetByFilterAsync(Expression<Func<Item, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.Item.Where<Item>(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Item entity)
        {
            try
            {
                var result = _context.Item.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
