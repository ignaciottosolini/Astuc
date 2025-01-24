using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using EIRL.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;


        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedido = await _pedidoService.GetAllAsync();
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }
        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var pedido = await _pedidoService.GetByUserId(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PedidoDTO pedido)
        {
            await _pedidoService.CreateAsync(pedido);
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PedidoDTO pedido)
        {
            try
            {
                if (id != pedido.Id)
                {
                    return BadRequest();
                }
                await _pedidoService.UpdateAsync(pedido);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pedidoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
