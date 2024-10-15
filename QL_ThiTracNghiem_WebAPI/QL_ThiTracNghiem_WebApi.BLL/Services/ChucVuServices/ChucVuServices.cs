using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IChucVuServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IChucVuRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.ChucVuServices
{
    public class ChucVuServices : IChucVuServices
    {
        private readonly IChucVuRepository _repository;
        private readonly IMapper _mappers;

        public ChucVuServices(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _repository = chucVuRepository;
            _mappers = mapper;
        }

        public async Task AddAsync(ChucVuDto chucVu)
        {
            var item = _mappers.Map<Chucvu>(chucVu);
            await _repository.AddAsync(item);
        }

        public async Task DeleteAsync(int macv)
        {
            await _repository.DeleteAsync(macv);
        }

        public async Task<List<ChucVuDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mappers.Map<List<ChucVuDto>>(items);
        }

        public async Task<ChucVuDto> GetByIdAsync(int macv)
        {
            var item = await _repository.GetByIdAsync(macv);
            if (item == null)
            {
                return null;
            }
            return _mappers.Map<ChucVuDto>(item);
        }

        public async Task<bool> ItemExists(int macv)
        {
            return await _repository.ExistsAsync(macv);
        }

        public async Task UpdateAsync(int macv, ChucVuDto chucVu)
        {
            var existingItem = await _repository.GetByIdAsync(macv);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = _mappers.Map(chucVu, existingItem);

            await _repository.UpdateAsync(existingItem);
        }
    }
}
