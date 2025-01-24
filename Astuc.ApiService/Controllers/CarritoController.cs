using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using EIRL.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;


        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carrito = await _carritoService.GetAllAsync();
            return Ok(carrito);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var carrito = await _carritoService.GetByIdAsync(id);
            if (carrito == null) return NotFound();
            return Ok(carrito);
        }
        [HttpGet("GetByUserId{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var carrito = await _carritoService.GetByUserIdAsync(id);
            if (carrito == null) return NotFound();
            return Ok(carrito);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarritoDTO carrito)
        {
            await _carritoService.CreateAsync(carrito);
            return CreatedAtAction(nameof(GetById), new { id = carrito.Id }, carrito);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarritoDTO carrito)
        {
            try
            {
                if (id != carrito.Id)
                {
                    return BadRequest();
                }
                await _carritoService.UpdateAsync(carrito);
                return Ok(carrito);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carritoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
