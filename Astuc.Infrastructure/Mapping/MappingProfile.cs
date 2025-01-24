using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using AutoMapper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
       
        CreateMap<EventoDTO, Evento>().ReverseMap();
        CreateMap<InsumoDTO, Insumo>().ReverseMap();
        CreateMap<PublicacionDTO, Publicacion>().ReverseMap();
        CreateMap<MembresiaDTO, Membresia>().ReverseMap();
        CreateMap<UserDTO, ApplicationUser>().ReverseMap();
        CreateMap<PedidoDTO, Pedido>().ReverseMap();
        CreateMap<InsumoCarritoDTO, InsumoCarrito>().ReverseMap();
        CreateMap<CarritoDTO, Carrito>().ReverseMap();
        CreateMap<InsumoPedidoDTO, InsumoPedido>().ReverseMap();




    }
}

