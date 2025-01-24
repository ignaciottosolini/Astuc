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
    public interface IPublicacionService : IGenericService<PublicacionDTO>
    {
    }

    public class PublicacionService : GenericService<Publicacion, PublicacionDTO>, IPublicacionService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Publicacion> _repository;
        private readonly AstucContext _context;


        public PublicacionService(IGenericRepository<Publicacion> repository, IMapper mapper, AstucContext context) : base(repository, mapper)
        {

        }


    }
}
