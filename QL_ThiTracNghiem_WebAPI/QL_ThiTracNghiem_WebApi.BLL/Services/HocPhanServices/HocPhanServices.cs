using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IHocPhanServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.HocPhanServices
{
    public class HocPhanServices : IHocPhanServices
    {
        private readonly IRepository<Hocphan> _repository;
        private readonly IMapper _mapper;
        
        public HocPhanServices(IRepository<Hocphan> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(HocPhanAddDto hocphanDto)
        {
            var item = _mapper.Map<Hocphan>(hocphanDto);
            await _repository.AddAsync(item);
        }

        public async Task DeleteAsync(string mhp)
        {
            await _repository.DeleteAsync(mhp);
        }

        public async Task<List<HocPhanDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<List<HocPhanDto>>(items);
        }

        public async Task<HocPhanDto> GetByIdAsync(string mhp)
        {
            var item = await _repository.GetByIdAsync(mhp);
            if (item != null)
            {
                return _mapper.Map<HocPhanDto>(item);
            }
            return null;
        }

        public async Task<bool> ItemExists(string mhp)
        {
            return await _repository.ExistsAsync(mhp);
        }

        public async Task UpdateAsync(string mhp, HocPhanDto hocphanDto)
        {
            var existingItem = await _repository.GetByIdAsync(mhp);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = _mapper.Map(hocphanDto, existingItem);
            await _repository.UpdateAsync(existingItem);
        }
    }
}
