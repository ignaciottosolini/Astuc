using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using AutoMapper;
using EIRL.Application.Services.Common;
using EIRL.Infrastructure.Data;
using EIRL.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIRL.Application.Services
{
    public interface IPedidoService : IGenericService<PedidoDTO>
    {
        Task<List<Pedido>> GetByUserId(string userId);
    }

    public class PedidoService : GenericService<Pedido, PedidoDTO>, IPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Pedido> _repository;
        private readonly AstucContext _context;


        public PedidoService(IGenericRepository<Pedido> repository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {
            _context = context;

        }
        public async Task<List<Pedido>> GetByUserId(string userId)
        {
            try
            {
                var pedidos =  _context.Pedidos.Where(p => p.UserId == userId).ToList();
                if (pedidos == null) throw new Exception("Not found");
                return pedidos;
                    
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }



    }
}