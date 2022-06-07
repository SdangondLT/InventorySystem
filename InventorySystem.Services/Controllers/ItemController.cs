using AutoMapper;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.V1;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventorySystem.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemCore _itemCore;

        public ItemController(ILogger<Item> logger, IMapper mapper, IItemRepository context)
        {
            _itemCore = new ItemCore(logger, mapper, context);
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var response = await _itemCore.GetItemsAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET: api/<ItemsController>
        [HttpGet("/Stock")]
        public async Task<ActionResult<IEnumerable<ItemStockBalanceDto>>> GetAllStockBalance()
        {
            var response = await _itemCore.GetItemsStockBalanceAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            var response = await _itemCore.GetItemByIdAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<ItemsController>/5
        [HttpGet("/Stock/{id}")]
        public async Task<ActionResult<ItemStockBalanceDto>> GetStockBalance(int id)
        {
            var response = await _itemCore.GetItemByIdStockBalanceAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<ActionResult<Item>> Post([FromBody] ItemCreateDto item)
        {
            var response = await _itemCore.CreateItemAsync(item);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<ItemsController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] Item item)
        {
            var response = await _itemCore.UpdateItemAsync(item);
            return StatusCode((int)response.StatusHttp, response);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
