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
    public interface IInsumoService : IGenericService<InsumoDTO>
    {
    }

    public class InsumoService : GenericService<Insumo, InsumoDTO>, IInsumoService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Insumo> _repository;
        private readonly AstucContext _context;


        public InsumoService(IGenericRepository<Insumo> repository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {

        }


    }
}
