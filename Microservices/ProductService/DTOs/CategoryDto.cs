using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public record CategoryDto
    (
    int Id,
    string Name,
    int? ParentCategoryId
    );
}
