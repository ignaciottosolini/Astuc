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
    public interface IMembresiaService : IGenericService<MembresiaDTO>
    {
    }
    
    public class MembresiaService : GenericService<Membresia, MembresiaDTO>, IMembresiaService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Membresia> _repository;
        private readonly AstucContext _context;


        public MembresiaService(IGenericRepository<Membresia> repository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {

        }    


    }
}

