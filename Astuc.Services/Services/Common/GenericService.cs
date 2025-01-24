using System.Collections.Generic;
using System.Threading.Tasks;
using Astuc.Domain.DTOs;
using AutoMapper;
using EIRL.Application.Services.Common;
using EIRL.Infrastructure.Repositories.Common;

namespace EIRL.Application.Services
{
    public abstract class GenericService<TEntity, TDto> : IGenericService<TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        private IGenericRepository<EventoDTO> repository;
        private IMapper mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected GenericService(IGenericRepository<EventoDTO> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto> GetByIdAsync(object id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.CreateAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(object id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
