using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
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

        }
    }
}
