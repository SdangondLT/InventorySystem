using AutoMapper;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.Handlers;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;
using InventorySystem.Entities.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Core.V1
{
    public class MovementCore
    {
        private readonly IMovementRepository _context;
        private readonly ILogger<Movement> _logger;
        private readonly ErrorHandler<Movement> _errorHandler;
        private readonly IMapper _mapper;

        public MovementCore(ILogger<Movement> logger, IMapper mapper, IMovementRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Movement>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Movement>>> GetMovementsAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                return new ResponseService<List<Movement>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetMovementsAsync", new List<Movement>());
            }
        }

        public async Task<ResponseService<Movement>> GetMovementByIdAsync(int id)
        {
            try
            {
                var result = await _context.GetByIdAsync(id);
                return new ResponseService<Movement>(false, result == null ? "No records found" : "Record found:", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetMovementByIdAsync", new Movement());
            }
        }

        public async Task<ResponseService<Movement>> CreateMovementAsync(MovementCreateDto entity)
        {
            Movement newMovement = new();
            newMovement = _mapper.Map<Movement>(entity);

            try
            {
                var result = await _context.AddAsync(newMovement);
                return new ResponseService<Movement>(false, "Succefully created Movement", HttpStatusCode.Created, result.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "CreateMovementAsync", new Movement());
            }
        }

        public async Task<ResponseService<bool>> UpdateMovementAsync(Movement movementToUpdate)
        {
            try
            {
                var result = await _context.UpdateAsync(movementToUpdate);
                return new ResponseService<bool>(false, result == true ? "Record updated !!" : "Record not updated:", HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateMovementAsync", false);
            }
        }
    }
}
