using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using Astuc.Domain.Models;
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
    public interface IInsumoCarritoService : IGenericService<InsumoCarritoDTO>
    {
        Task AddAsyncInsumo(AddCartModel addCartModel);
    }

    public class InsumoCarritoService : GenericService<InsumoCarrito, InsumoCarritoDTO>, IInsumoCarritoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<InsumoCarrito> _repository;
        private readonly AstucContext _context;
        private readonly IGenericRepository<Carrito> _carritoRepository;


        public InsumoCarritoService(IGenericRepository<InsumoCarrito> repository, IGenericRepository<Carrito> carritoRepository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _carritoRepository = carritoRepository;

        }
        public async Task AddAsyncInsumo(AddCartModel addCartModel)
        {
            try
            {
                var cartExists = await _context.Carritos.FirstOrDefaultAsync(c => c.UserId == addCartModel.UserId);
                var insumoCarrito = new InsumoCarrito
                {
                    InsumoId = addCartModel.InsumoId,
                    Cantidad = addCartModel.Cantidad,
                };
                if (cartExists == null)
                {
                    var newCart = new Carrito { UserId = addCartModel.UserId };
                    await _carritoRepository.CreateAsync(newCart);

                    insumoCarrito.CarritoId = newCart.Id;
                }
                else
                {
                    insumoCarrito.CarritoId = cartExists.Id;
                }

                var insumoCartExists = await _context.InsumosCarritos.FirstOrDefaultAsync(i => i.InsumoId == insumoCarrito.InsumoId && i.CarritoId == insumoCarrito.CarritoId);
                if (insumoCartExists == null)
                {
                    var newInsumo = _mapper.Map<InsumoCarrito>(insumoCarrito);
                    await _repository.CreateAsync(newInsumo);
                    return;
                }
                await this.addAmountCart(insumoCartExists, insumoCarrito.Cantidad);
                return;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



        }
        public async Task addAmountCart(InsumoCarrito insumoCarrito, int amount)
        {
            try
            {
                if (insumoCarrito == null)
                {
                    throw new Exception("Cart dont exists");

                }
                insumoCarrito.Cantidad += amount;

                await _repository.UpdateAsync(insumoCarrito);
                return;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



        }

    }
}
