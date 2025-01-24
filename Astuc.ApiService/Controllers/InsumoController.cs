
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
    public class InsumoController : ControllerBase
    {
        private readonly IInsumoService _insumoService;


        public InsumoController(IInsumoService insumoService)
        {
            _insumoService = insumoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insumo = await _insumoService.GetAllAsync();
            return Ok(insumo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insumo = await _insumoService.GetByIdAsync(id);
            if (insumo == null) return NotFound();
            return Ok(insumo);
        }


        [HttpPost]
        public async Task<IActionResult> Create(InsumoDTO insumo)
        {
            await _insumoService.CreateAsync(insumo);
            return CreatedAtAction(nameof(GetById), new { id = insumo.Id }, insumo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InsumoDTO insumo)
        {
            try
            {
                if (id != insumo.Id)
                {
                    return BadRequest();
                }
                await _insumoService.UpdateAsync(insumo);
                return Ok(insumo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _insumoService.DeleteAsync(id);
            return NoContent();
        }
    }
}

