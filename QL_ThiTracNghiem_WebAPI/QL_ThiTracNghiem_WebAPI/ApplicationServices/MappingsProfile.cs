﻿using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.CT_HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.LopHocDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.SinhVienDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.ChucVuRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.CT_HocPhanRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.GiangVienRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.HocPhanRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.KhoaRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.LopHocRequestDto;
using QL_ThiTracNghiem_WebAPI.Models.RequestDto.SinhVienRequestDto;
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
            CreateMap<Lophoc, LopHocAddDto>().ReverseMap();
            CreateMap<LopHocAddDto, LopHocRequestDto>().ReverseMap();

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

            CreateMap<Sinhvien, SinhVienAddDto>().ReverseMap();
            CreateMap<SinhVienRequestDto, SinhVienAddDto>().ReverseMap();
            CreateMap<SinhVienDto, SinhVienRequestDto>().ReverseMap();
            CreateMap<Sinhvien, SinhVienDto>().ReverseMap()
                .ForMember(dest => dest.Masv, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcRemmeber) => srcRemmeber != null));

            CreateMap<Hocphan, HocPhanAddDto>().ReverseMap();
            CreateMap<HocPhanRequestDto, HocPhanAddDto>().ReverseMap();
            CreateMap<HocPhanDto, HocPhanRequestDto>().ReverseMap();
            CreateMap<Hocphan, HocPhanDto>().ReverseMap()
                .ForMember(dest => dest.Mahocphan, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcRemmeber) => srcRemmeber != null));

            CreateMap<CtHocphan, CT_HocPhanAddDto>().ReverseMap();
            CreateMap<CT_HocPhanRequestDto, CT_HocPhanAddDto>().ReverseMap();
            CreateMap<CT_HocPhanDto, CT_HocPhanRequestDto>().ReverseMap();
            CreateMap<CtHocphan, CT_HocPhanDto>().ReverseMap()
                .ForMember(dest => dest.Mahocphan, opt => opt.Ignore())
                .ForMember(dest => dest.Malophocphan, opt => opt.Ignore())
                .ForMember(dest => dest.Masv, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcRemmeber) => srcRemmeber != null));
        }
    }
}
