
using System;
using System.Collections.Generic;
namespace Application.DTOs
{
    public record ProductCreateDto(string ProductName, List<ItemCreateDto> Items);
    public record ProductUpdateDto(string ProductName, List<ItemUpdateDto> Items);

    public record ProductResponseDto(
        int Id,
        string ProductName,
        string CreatedBy,
        DateTime CreatedOn,
        string? ModifiedBy,
        DateTime? ModifiedOn,
        List<ItemResponseDto> Items);

    public record ItemCreateDto(int Quantity);
    public record ItemUpdateDto(int? Id, int Quantity);
    public record ItemResponseDto(int Id, int Quantity);
}
