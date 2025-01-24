using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using AutoMapper;
using EIRL.Application.Services.Common;
using EIRL.Infrastructure.Data;
using EIRL.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIRL.Application.Services
{
    public interface ICarritoService : IGenericService<CarritoDTO>
    {
        Task<Carrito> GetByUserIdAsync(string id);
    }

    public class CarritoService : GenericService<Carrito, CarritoDTO>, ICarritoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Carrito> _repository;
        private readonly AstucContext _context;


        public CarritoService(IGenericRepository<Carrito> repository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            

        }
        public async Task<Carrito> GetByUserIdAsync(string id)
        {

            var carrito = await _context.Carritos.Include(c => c.Insumos).ThenInclude(n => n.Insumo).FirstOrDefaultAsync(i => i.UserId == id);
            //carrito.Insumos = _context.InsumosCarritos.Where(c => c.CarritoId == id).ToList();

            return carrito;
        }


    }
}
