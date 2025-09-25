using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Mapping;
using ProductService.Repositories;
using ProductService.RepositoryContracts;
using ProductService.ServiceContracts;
using ProductService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EshopDb")));

builder.Services.AddAutoMapper(typeof(ProductMappingProfile));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<ICategoryVariationRepository, CategoryVariationRepository>();
builder.Services.AddScoped<ICategoryVariationService, CategoryVariationService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();