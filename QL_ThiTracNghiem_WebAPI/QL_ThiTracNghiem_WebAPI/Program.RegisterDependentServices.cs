
using AutoMapper;
using QL_ThiTracNghiem_WebApi.ApplicationServices;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.ChucVuServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.KhoaServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.LopHocServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IChucVuRepository;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IKhoaRepository;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.ILopHocRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Repository.ChucVuRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Repository.KhoaRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Repository.LopHocRepository;

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

        builder.Services.AddAutoMapper(typeof(MappingsProfile));

        builder.Services.AddScoped<ILopHocRepository, LopHocRepository>();
        builder.Services.AddScoped<IKhoaRepository, KhoaRepository>();
        builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>();

        builder.Services.AddScoped<IChucVuServices, ChucVuServices>();
        builder.Services.AddScoped<IKhoaServices, KhoaServices>();
        builder.Services.AddScoped<ILopHocServices, LopHocServices>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        return builder;
    }

}

