
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllAsync(int pageNumber, int pageSize);
        Task<ProductResponseDto?> GetByIdAsync(int id);
        Task<ProductResponseDto> CreateAsync(ProductCreateDto dto, string userId);
        Task<bool> UpdateAsync(int id, ProductUpdateDto dto, string userId);
        Task<bool> DeleteAsync(int id);
    }
}
