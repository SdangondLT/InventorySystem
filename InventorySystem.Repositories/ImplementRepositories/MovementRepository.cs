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
    public class MovementRepository : IMovementRepository
    {
        private readonly SqlServerContext _context;
        public MovementRepository()
        {
            _context = new SqlServerContext();
        }
        public async Task<Tuple<Movement, bool>> AddAsync(Movement entity)
        {
            try
            {
                var result = _context.Movement.Add(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Movement>> GetAllAsync()
        {
            try
            {
                var result = await _context.Movement.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Movement> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Movement.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Movement>> GetByFilterAsync(Expression<Func<Movement, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.Movement.Where<Movement>(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Movement entity)
        {
            try
            {
                var result = _context.Movement.Update(entity);
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
