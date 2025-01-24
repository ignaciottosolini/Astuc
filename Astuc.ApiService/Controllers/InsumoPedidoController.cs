using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using Astuc.Domain.Models;
using EIRL.Application.Services;
using EIRL.Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsumoPedidoController : ControllerBase
    {
        private readonly IInsumoPedidoService _insumoPedidoService;


        public InsumoPedidoController(IInsumoPedidoService insumoPedidoService)
        {
            _insumoPedidoService = insumoPedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insumoCarrito = await _insumoPedidoService.GetAllAsync();
            return Ok(insumoCarrito);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insumoCarrito = await _insumoPedidoService.GetByIdAsync(id);
            if (insumoCarrito == null) return NotFound();
            return Ok(insumoCarrito);
        }
        [HttpGet("GetByPedidoId/{id}")]
        public async Task<IActionResult> GetByPedidoId(int id)
        {
            var insumos = await _insumoPedidoService.GetByPedidoId(id);
            if (insumos == null) return NotFound();
            return Ok(insumos);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(AddPedidoModel insumoPedido)
        {
            await _insumoPedidoService.AddAsyncInsumo(insumoPedido);
            return CreatedAtAction(nameof(GetById), new { id = insumoPedido.Id }, insumoPedido);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InsumoPedidoDTO insumoCarrito)
        {
            try
            {
                if (id != insumoCarrito.Id)
                {
                    return BadRequest();
                }
                await _insumoPedidoService.UpdateAsync(insumoCarrito);
                return Ok(insumoCarrito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _insumoPedidoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
