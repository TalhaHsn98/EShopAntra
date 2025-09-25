using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public record CategoryCreateRequest
    (
    [Required, MaxLength(200)] string Name,
    int? ParentCategoryId
    );
}
