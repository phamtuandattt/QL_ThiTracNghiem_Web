using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.ChucVuRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.GiangVienRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.KhoaRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.LopHocRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.ApplicationServices
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap();
        }

        protected MappingsProfile(string profileName) : base(profileName)
        {
        }

        protected MappingsProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
        {
        }

        public override string ProfileName
        {
            get
            {
                return GetType().FullName;
            }
        }

        protected void CreateMap()
        {
            CreateMap<Lophoc, LopHocRequestDto>();
            CreateMap<LopHocRequestDto, Lophoc>();
            CreateMap<Lophoc, LopHocDto>().ReverseMap()
                .ForMember(dest => dest.Malop, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcRemmeber) => srcRemmeber != null));
            CreateMap<LopHocRequestDto, LopHocDto>().ReverseMap();

            CreateMap<Khoa, KhoaRequestDto>().ReverseMap();
            CreateMap<Khoa, KhoaDto>().ReverseMap()
                .ForMember(dest => dest.Makhoa, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcRemmeber) => srcRemmeber != null));
            CreateMap<KhoaRequestDto, KhoaDto>().ReverseMap();


            CreateMap<Chucvu, ChucVuRequestDto>().ReverseMap();
            CreateMap<Chucvu, ChucVuDto>().ReverseMap()
                .ForMember(dest => dest.Machucvu, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcRemmeber) => srcRemmeber != null));
            CreateMap<ChucVuDto, ChucVuRequestDto>().ReverseMap();


            CreateMap<Giangvien, GiangVienRequestDto>().ReverseMap();
            CreateMap<Giangvien, GiangVienDto>().ReverseMap()
                .ForMember(dest => dest.Magv, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcRemmeber) => srcRemmeber != null));
            CreateMap<GiangVienRequestDto, GiangVienAddDto>().ReverseMap();
            CreateMap<GiangVienDto, GiangVienRequestDto>().ReverseMap();
            CreateMap<Giangvien, GiangVienAddDto>().ReverseMap();
        }
    }
}
