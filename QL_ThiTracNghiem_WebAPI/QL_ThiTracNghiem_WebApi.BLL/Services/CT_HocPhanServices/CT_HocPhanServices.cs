using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.CT_HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ICT_HocPhanServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IHocPhanRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.DAL.Repository;
using QL_ThiTracNghiem_WebAPI.DAL.ResponseDtos.CT_HocPhanResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.CT_HocPhanServices
{
    public class CT_HocPhanServices : ICT_HocPhanServices
    {
        private readonly IRepository<CtHocphan> repository;
        private readonly ICT_HocPhanRepository _CT_HocPhanRepository;
        private readonly IMapper _mapper;

        public CT_HocPhanServices(IRepository<CtHocphan> repository, ICT_HocPhanRepository cT_HocPhanRepository, IMapper mapper)
        {
            this.repository = repository;
            this._CT_HocPhanRepository = cT_HocPhanRepository;
            _mapper = mapper;
        }

        public async Task AddRangeAsync(string mahocphan, List<CT_HocPhanAddDto> cthps)
        {
            var malophocphan = await _CT_HocPhanRepository.GetMaLopHocPhan(mahocphan);
            foreach (var entity in cthps)
            {
                entity.Malophocphan = malophocphan;
            }
            var items = _mapper.Map<List<CtHocphan>>(cthps);
            await _CT_HocPhanRepository.AddRangeAsync(items);
        }

        public async Task DeleteAsync(string malophocphan)
        {
            await _CT_HocPhanRepository.DeleteAsync(malophocphan);
        }

        public async Task<List<CT_HocPhanResponseDto>> GetAllAsync(string MaLopHocPhan)
        {
            var items = await _CT_HocPhanRepository.GetCT_LopHocPhan(MaLopHocPhan);
            return items;
        }

        public async Task<List<DS_SVHocPhanResponseDto>> GetDS_SVHocPhanAsync(string MaLopHocPhan)
        {
            var items = await _CT_HocPhanRepository.GetDS_SVHocPhanAsync(MaLopHocPhan);
            return items;
        }

        public async Task<bool> ItemExists(string malophocphan, string masv, string mahp)
        {
            return await _CT_HocPhanRepository.ExistsAsync(malophocphan, masv, mahp);
        }

        public async Task UpdateAsync(string malophp, CT_HocPhanDto ct_hp)
        {
            var existingItem = await _CT_HocPhanRepository.GetLopHocPhan(malophp);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = _mapper.Map(ct_hp, existingItem);
            await _CT_HocPhanRepository.UpdateRangeAsync(existingItem);
        }
    }
}
