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
    public interface IInsumoPedidoService : IGenericService<InsumoPedidoDTO>
    {
        Task AddAsyncInsumo(AddPedidoModel addPedidoModel);
        Task<List<InsumoPedido>> GetByPedidoId (int id);
    }

    public class InsumoPedidoService : GenericService<InsumoPedido, InsumoPedidoDTO>, IInsumoPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<InsumoPedido> _repository;
        private readonly AstucContext _context;
        private readonly IGenericRepository<Pedido> _pedidoRepository;


        public InsumoPedidoService(IGenericRepository<InsumoPedido> repository, IGenericRepository<Pedido> pedidoRepository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _pedidoRepository = pedidoRepository;

        }
        public async Task AddAsyncInsumo(AddPedidoModel addPedidoModel)
        {
            try
            {
                var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.Id == addPedidoModel.CarritoId);
                
                var pedido = new Pedido
                {
                    Cliente = addPedidoModel.Email,
                    FechaPedido = DateTime.Now,
                    Estado = addPedidoModel.Estado,
                    UserId = carrito.UserId,
                    Direccion = addPedidoModel.Direccion,
                    Celular = addPedidoModel.Celular,
                    Ciudad = addPedidoModel.Ciudad,
                    CodigoPostal = addPedidoModel.CodigoPostal,
                    Total = addPedidoModel.Total


                    
                };
               await _pedidoRepository.CreateAsync(pedido);

                
                

               var insumosCartExists =  _context.InsumosCarritos.Include(c => c.Insumo).Where(c => c.CarritoId == addPedidoModel.CarritoId).ToList();
                List<InsumoPedido> listInsumos = new List<InsumoPedido>(); 
                foreach (var item in insumosCartExists)
                {
                    var insumoPedido = new InsumoPedido
                    {
                        InsumoId = item.InsumoId,
                        Cantidad = item.Cantidad,
                        PrecioUnidad = item.Insumo.PrecioVenta,
                        PedidoId = pedido.Id


                    };
                    listInsumos.Add(insumoPedido);


                    
                }
                _context.InsumosPedidos.AddRange(listInsumos);

                _context.Carritos.Remove(carrito);
                _context.SaveChanges();
                return;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public async Task<List<InsumoPedido>> GetByPedidoId(int id)
        {
            try
            {
                var details = _context.InsumosPedidos.Include(d => d.Insumo).Where(c => c.PedidoId == id).ToList();
                if (details == null)
                {
                    throw new Exception("Not Found");
                }
                return details;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


    }
}
