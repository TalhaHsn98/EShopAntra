using Microsoft.EntityFrameworkCore;
using ReviewService.Data;
using ReviewService.Mapping;
using ReviewService.Repositories;
using ReviewService.RepositoryContracts;
using ReviewService.ServiceContracts;
using ReviewService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ReviewDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EshopDb")));

builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();
builder.Services.AddScoped<ICustomerReviewService, CustomerReviewService>();
builder.Services.AddAutoMapper(typeof(ReviewProfile).Assembly);

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
