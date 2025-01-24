using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using Astuc.Domain.Models;
using EIRL.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsumoCarritoController : ControllerBase
    {
        private readonly IInsumoCarritoService _insumoCarritoService;


        public InsumoCarritoController(IInsumoCarritoService insumoCarritoService)
        {
            _insumoCarritoService = insumoCarritoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insumoCarrito = await _insumoCarritoService.GetAllAsync();
            return Ok(insumoCarrito);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insumoCarrito = await _insumoCarritoService.GetByIdAsync(id);
            if (insumoCarrito == null) return NotFound();
            return Ok(insumoCarrito);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCartModel insumoCarrito)
        {
            await _insumoCarritoService.AddAsyncInsumo(insumoCarrito);
            return CreatedAtAction(nameof(GetById), new { id = insumoCarrito.Id }, insumoCarrito);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InsumoCarritoDTO insumoCarrito)
        {
            try
            {
                if (id != insumoCarrito.Id)
                {
                    return BadRequest();
                }
                await _insumoCarritoService.UpdateAsync(insumoCarrito);
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
            await _insumoCarritoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
