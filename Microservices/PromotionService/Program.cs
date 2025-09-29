using Microsoft.EntityFrameworkCore;
using PromotionService.Data;
using PromotionService.Mapping;
using PromotionService.RepositoryContracts;
using PromotionService.Service;
using PromotionService.ServiceContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(PromotionsMappingProfile).Assembly);

builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<IPromotionService, PromotionsService>();

builder.Services.AddDbContext<PromotionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EshopDb"))
);


var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
