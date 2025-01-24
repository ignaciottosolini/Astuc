
using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using EIRL.Application.Services;
using EIRL.Application.Services.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembresiaController : ControllerBase
    {
        private readonly IMembresiaService _membresiaService;


        public MembresiaController(IMembresiaService membresiaService)
        {
            _membresiaService = membresiaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var membresia = await _membresiaService.GetAllAsync();
            return Ok(membresia);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var membresia = await _membresiaService.GetByIdAsync(id);
            if (membresia == null) return NotFound();
            return Ok(membresia);
        }


        [HttpPost]
        public async Task<IActionResult> Create(MembresiaDTO membresia)
        {
            await _membresiaService.CreateAsync(membresia);
            return CreatedAtAction(nameof(GetById), new { id = membresia.Id }, membresia);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MembresiaDTO membresia)
        {
            try
            {
                if (id != membresia.Id)
                {
                    return BadRequest();
                }
                await _membresiaService.UpdateAsync(membresia);
                return Ok(membresia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _membresiaService.DeleteAsync(id);
            return NoContent();
        }
    }
}

