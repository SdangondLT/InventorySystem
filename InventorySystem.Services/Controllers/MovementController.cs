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
    public class MovementController : ControllerBase
    {
        private readonly MovementCore _movementCore;

        public MovementController(ILogger<Movement> logger, IMapper mapper, IMovementRepository context)
        {
            _movementCore = new MovementCore(logger, mapper, context);
        }

        // GET: api/<MovementController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movement>>> Get()
        {
            var response = await _movementCore.GetMovementsAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<MovementController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movement>> Get(int id)
        {
            var response = await _movementCore.GetMovementByIdAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<MovementController>
        [HttpPost]
        public async Task<ActionResult<Movement>> Post([FromBody] MovementCreateDto movement)
        {
            var response = await _movementCore.CreateMovementAsync(movement);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<MovementController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] Movement movement)
        {
            var response = await _movementCore.UpdateMovementAsync(movement);
            return StatusCode((int)response.StatusHttp, response);
        }

        // DELETE api/<MovementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
