using AutoMapper;
using E_Commerce.Infrastructure.Interfaces;
using E_Commerce.Shared.Abstract;

namespace E_Commerce.Business.Services
{
    public class Service<TEntity, TEntityDto> : IService<TEntityDto> where TEntity : BaseEntity where TEntityDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public Service(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TEntityDto> CreateAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            var createdEntity = await _repository.Add(entity);
            return _mapper.Map<TEntityDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByID(id);
            if (entity == null)
            {
                // Handle not found
            }
             await _repository.Remove(entity);
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<TEntityDto>>(entities);
        }

        public async Task<TEntityDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByID(id);
            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task<TEntityDto> GetByIdAsync(int id, params string[] includes)
        {
            var entity = await _repository.GetByID(id, includes);
            return _mapper.Map<TEntityDto>(entity);
        }


        public async Task<TEntityDto> UpdateAsync(int id, TEntityDto entityDto)
        {
            var existingEntity = await _repository.GetByID(id);
            if (existingEntity == null)
            {
                // Handle not found
            }

            _mapper.Map(entityDto, existingEntity);

            await _repository.Update(existingEntity,id);
            return _mapper.Map<TEntityDto>(existingEntity);
        }
    }
}
