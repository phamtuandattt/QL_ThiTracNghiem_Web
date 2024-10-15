

using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.ILopHocRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.LopHocServices
{
    public class LopHocServices : ILopHocServices
    {
        private readonly ILopHocRepository _repository;
        private readonly IMapper _mappers;
        public LopHocServices(ILopHocRepository lopHocRepository, IMapper mapper)
        {
            _repository = lopHocRepository;
            _mappers = mapper;
        }

        public async Task AddAsync(LopHocDto lophoc)
        {
            var item = _mappers.Map<Lophoc>(lophoc);
            await _repository.AddAsync(item);
        }

        public Task DeleteAsync(string malop)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LopHocDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mappers.Map<List<LopHocDto>>(items);
        }

        public async Task<LopHocDto> GetByIdAsync(string malop)
        {
            var item = await _repository.GetByIdAsync(malop);
            if (item == null)
            {
                return null; 
            }
            //return _mapper.Map<ItemDto>(item);
            return _mappers.Map<LopHocDto>(item);
        }

        public async Task<bool> ItemExists(string malh)
        {
            return await _repository.ExistsAsync(malh);
        }

        public async Task UpdateAsync(string malop, LopHocDto lophoc)
        {
            var existingItem = await _repository.GetByIdAsync(malop);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = _mappers.Map(lophoc, existingItem);
            
            await _repository.UpdateAsync(existingItem);
        }
    }
}
