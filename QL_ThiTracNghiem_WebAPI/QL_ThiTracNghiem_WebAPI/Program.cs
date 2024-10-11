using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IChucVuServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.ChucVuServices;
using QL_ThiTracNghiem_WebAPI.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QlHethongthitracnghiemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLThiTracNghiemContext"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddControllers();

builder.Services.AddScoped<IChucVuServices, ChucVuServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
