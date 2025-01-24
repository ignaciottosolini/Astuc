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
    public interface IEventoService : IGenericService<EventoDTO>
    {
    }
    
    public class EventoService : GenericService<Evento, EventoDTO>, IEventoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Evento> _repository;
        private readonly AstucContext _context;


        public EventoService(IGenericRepository<Evento> repository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {

        }    


    }
}

