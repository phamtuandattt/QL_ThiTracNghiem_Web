﻿
using QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.ChucVuServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.KhoaServices;

public static class RegisterDependentServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<QlHethongthitracnghiemContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("QLThiTracNghiemContext"));
            options.EnableSensitiveDataLogging();
        });

        builder.Services.AddControllers();

        builder.Services.AddScoped<IChucVuServices, ChucVuServices>();
        builder.Services.AddScoped<IKhoaServices, KhoaServices>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        return builder;
    }

}

