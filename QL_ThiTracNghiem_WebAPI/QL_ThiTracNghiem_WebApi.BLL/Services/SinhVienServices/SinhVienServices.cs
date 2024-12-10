using AutoMapper;
using log4net.Util;
using Microsoft.EntityFrameworkCore.Storage;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.SinhVienDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ISinhVienServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.ISinhVienRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.SinhVienServices
{
    public class SinhVienServices : ISinhVienServices
    {
        private readonly IRepository<Sinhvien> _sinhVienRepository;
        private readonly ISinhVienRepository _repo;
        private readonly IMapper mapper;

        public SinhVienServices(IRepository<Sinhvien> sinhVienRepository, ISinhVienRepository repo, IMapper mapper)
        {
            _sinhVienRepository = sinhVienRepository;
            _repo = repo;
            this.mapper = mapper;
        }

        public async Task AddAsync(SinhVienAddDto addDto)
        {
            var msv = await _repo.GetMaSV(addDto.NganhDaoTao, addDto.MaKhoa, addDto.NamNhapHoc);
            addDto.Masv = msv;
            var item = mapper.Map<Sinhvien>(addDto);
            await _sinhVienRepository.AddAsync(item);
        }

        public async Task AddRangeAsync(List<SinhVienAddDto> addDtos)
        {
            foreach (var dto in addDtos)
            {
                var msv = await _repo.GetMaSV("20", dto.MaKhoa, dto.NamNhapHoc);
                dto.Masv = msv;
            }
            var items = mapper.Map<List<Sinhvien>>(addDtos);
            await _sinhVienRepository.AddRangeAsync(items);
        }

        public async Task DeleteAsync(string masv)
        {
            await _sinhVienRepository.DeleteAsync(masv);
        }

        public async Task<List<SinhVienDto>> GetAllAsync()
        {
            var items = await _sinhVienRepository.GetAllAsync();
            return mapper.Map<List<SinhVienDto>>(items);
        }

        public async Task<SinhVienDto> GetByIdAsync(string masv)
        {
            var item = await _sinhVienRepository.GetByIdAsync(masv);
            if (item != null)
            {
                return mapper.Map<SinhVienDto>(item);
            }
            return null;
        }

        public async Task<bool> ItemExists(string masv)
        {
            return await _sinhVienRepository.ExistsAsync(masv);
        }

        public async Task UpdateAsync(string masv, SinhVienDto svDto)
        {
            var existingItem = await _sinhVienRepository.GetByIdAsync(masv);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = mapper.Map(svDto, existingItem);
            await _sinhVienRepository.UpdateAsync(existingItem);
        }
    }
}
