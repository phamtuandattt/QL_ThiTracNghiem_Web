using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.CT_HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ICT_HocPhanServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
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
        private readonly IMapper _mapper;

        public CT_HocPhanServices(IRepository<CtHocphan> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CT_HocPhanAddDto cthp)
        {
            var item = _mapper.Map<CtHocphan>(cthp);
            await repository.AddAsync(item);
        }

        public async Task DeleteAsync(string malophocphan, string masv, string mahp)
        {
            // not
        }

        public async Task<List<CT_HocPhanDto>> GetAllAsync()
        {
            var items = await repository.GetAllAsync();
            return _mapper.Map<List<CT_HocPhanDto>>(items);
        }

        public async Task<CT_HocPhanDto> GetByIdAsync(string malophocphan, string masv, string mahp)
        {
            // not
            return null;            
        }

        public async Task<bool> ItemExists(string malophocphan, string masv, string mahp)
        {
            // not
            return await repository.ExistsAsync(malophocphan);
        }

        public async Task UpdateAsync(string malophp, CT_HocPhanDto ct_hp)
        {
            // not
            var existingItem = await repository.GetByIdAsync(malophp);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = _mapper.Map(ct_hp, existingItem);
            await repository.UpdateAsync(existingItem);
        }
    }
}
