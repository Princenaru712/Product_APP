using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

using Microsoft.EntityFrameworkCore;
namespace CRN_Tech_Task.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _context;

        public ProductService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var products = await _context.Products
                .AsNoTracking()
                .Include(p => p.Items)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products.Select(MapToResponseDto);
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .AsNoTracking()
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);

            return product == null ? null : MapToResponseDto(product);
        }

        public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto, string userId)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                CreatedBy = userId,
                CreatedOn = DateTime.UtcNow,
                Items = dto.Items.Select(i => new Item { Quantity = i.Quantity }).ToList()
            };

            _context.Products.Add(product);
               await _context.SaveChangesAsync();

            return MapToResponseDto(product);
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDto dto, string userId)
        {
            var product = await _context.Products
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return false;

            product.ProductName = dto.ProductName;
            product.ModifiedBy = userId;
            product.ModifiedOn = DateTime.UtcNow;

            // Simple item reconciliation 
            _context.Items.RemoveRange(product.Items);
            product.Items = dto.Items.Select(i => new Item { Quantity = i.Quantity }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        private static ProductResponseDto MapToResponseDto(Product product) =>
            new(
                product.Id,
                product.ProductName,
                product.CreatedBy,
                product.CreatedOn,
                product.ModifiedBy,
                product.ModifiedOn,
                product.Items.Select(i => new ItemResponseDto(i.Id, i.Quantity)).ToList()
            ); 
    }
}
