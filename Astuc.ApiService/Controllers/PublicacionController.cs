using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using EIRL.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicacionController : ControllerBase
    {
        private readonly IPublicacionService _publicacionService;


        public PublicacionController(IPublicacionService publicacionService)
        {
            _publicacionService = publicacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publicacion = await _publicacionService.GetAllAsync();
            return Ok(publicacion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publicacion = await _publicacionService.GetByIdAsync(id);
            if (publicacion == null) return NotFound();
            return Ok(publicacion);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PublicacionDTO publicacion)
        {
            await _publicacionService.CreateAsync(publicacion);
            return CreatedAtAction(nameof(GetById), new { id = publicacion.Id }, publicacion);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PublicacionDTO publicacion)
        {
            try
            {
                if (id != publicacion.Id)
                {
                    return BadRequest();
                }
                await _publicacionService.UpdateAsync(publicacion);
                return Ok(publicacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _publicacionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
