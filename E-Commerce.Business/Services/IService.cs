using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public interface IService<TEntityDto>
    {
        Task<IEnumerable<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(int id);
        Task<TEntityDto> CreateAsync(TEntityDto entityDto);
        Task<TEntityDto> UpdateAsync(int id, TEntityDto entityDto);
        Task DeleteAsync(int id);
    }
}
