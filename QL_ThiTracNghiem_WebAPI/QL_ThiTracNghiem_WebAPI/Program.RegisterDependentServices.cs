
using AutoMapper;
using log4net.Config;
using log4net;
using QL_ThiTracNghiem_WebApi.ApplicationServices;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IGiangVienServices;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.ChucVuServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.GiangVienServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.KhoaServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.LopHocServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IChucVuRepository;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IKhoaRepository;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.ILopHocRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Repository;
using QL_ThiTracNghiem_WebAPI.DAL.Repository.ChucVuRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Repository.KhoaRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Repository.LopHocRepository;
using System.Reflection;
using System.Configuration;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ISinhVienServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.SinhVienServices;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IHocPhanServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.HocPhanServices;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ICT_HocPhanServices;
using QL_ThiTracNghiem_WebApi.BLL.Services.CT_HocPhanServices;

public static class RegisterDependentServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {

        var configLog4netPath = builder.Configuration["log4net"] ?? "";
        // Configure log4net
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo(configLog4netPath));

        builder.Services.AddDbContext<QlHethongthitracnghiemContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("QLThiTracNghiemContext"));
            options.EnableSensitiveDataLogging();
        });

        builder.Services.AddControllers();

        builder.Services.AddAutoMapper(typeof(MappingsProfile));

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<ILopHocRepository, LopHocRepository>();
        builder.Services.AddScoped<IKhoaRepository, KhoaRepository>();
        builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>();

        builder.Services.AddScoped<IChucVuServices, ChucVuServices>();
        builder.Services.AddScoped<IKhoaServices, KhoaServices>();
        builder.Services.AddScoped<ILopHocServices, LopHocServices>();
        builder.Services.AddScoped<IGiangVienServices, GiangVienServices>();
        builder.Services.AddScoped<ISinhVienServices, SinhVienServices>();
        builder.Services.AddScoped<IHocPhanServices, HocPhanServices>();
        builder.Services.AddScoped<ICT_HocPhanServices, CT_HocPhanServices>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        return builder;
    }

}

