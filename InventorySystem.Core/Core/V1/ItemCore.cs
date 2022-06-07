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
    public class ItemCore
    {
        private readonly IItemRepository _context;
        private readonly ILogger<Item> _logger;
        private readonly ErrorHandler<Item> _errorHandler;
        private readonly IMapper _mapper;

        public ItemCore(ILogger<Item> logger, IMapper mapper, IItemRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Item>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Item>>> GetItemsAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                return new ResponseService<List<Item>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetItemsAsync", new List<Item>());
            }
        }

        public async Task<ResponseService<List<ItemStockBalanceDto>>> GetItemsStockBalanceAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                List<ItemStockBalanceDto> newItem = new();
                newItem = _mapper.Map<List<ItemStockBalanceDto>>(response);
                return new ResponseService<List<ItemStockBalanceDto>>(false, newItem.Count == 0 ? "No records found" : $"{newItem.Count} records found", HttpStatusCode.OK, newItem);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetItemsStockBalanceAsync", new List<ItemStockBalanceDto>());
            }
        }

        public async Task<ResponseService<Item>> GetItemByIdAsync(int id)
        {
            try
            {
                var response = await _context.GetByIdAsync(id);
                return new ResponseService<Item>(false, response == null ? "No records found" : "Record found:", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetItemByIdAsync", new Item());
            }
        }

        public async Task<ResponseService<ItemStockBalanceDto>> GetItemByIdStockBalanceAsync(int id)
        {
            try
            {
                var response = await _context.GetByIdAsync(id);
                ItemStockBalanceDto newItem = new();
                newItem = _mapper.Map<ItemStockBalanceDto>(response);
                return new ResponseService<ItemStockBalanceDto>(false, newItem == null ? "No records found" : "Record found:", HttpStatusCode.OK, newItem);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetItemByIdStockBalanceAsync", new ItemStockBalanceDto());
            }
        }


        public async Task<ResponseService<Item>> CreateItemAsync(ItemCreateDto entity)
        {
            Item newItem = new();
            newItem = _mapper.Map<Item>(entity);

            try
            {
                var response = await _context.AddAsync(newItem);
                return new ResponseService<Item>(false, "Succefully created Item", HttpStatusCode.Created, response.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "CreateItemAsync", new Item());
            }
        }

        public async Task<ResponseService<bool>> UpdateItemAsync(Item itemToUpdate)
        {
            try
            {
                var response = await _context.UpdateAsync(itemToUpdate);
                return new ResponseService<bool>(false, response == true ? "Record updated !!" : "Record not updated:", HttpStatusCode.Created, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateItemAsync", false);
            }
        }
    }
}
