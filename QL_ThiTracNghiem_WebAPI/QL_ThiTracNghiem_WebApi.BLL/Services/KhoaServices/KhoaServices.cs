using AutoMapper;
using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IKhoaRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.KhoaServices
{
    public class KhoaServices : IKhoaServices
    {
        private readonly IKhoaRepository _repository;
        private readonly IMapper _mappers;

        public KhoaServices(IKhoaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mappers = mapper;
        }

        public async Task AddAsync(KhoaDto khoa)
        {
            var item = _mappers.Map<Khoa>(khoa);
            await _repository.AddAsync(item);
        }

        public async Task DeleteAsync(string makhoa)
        {
            await _repository.DeleteAsync(makhoa);
        }

        public async Task<List<KhoaDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mappers.Map<List<KhoaDto>>(items);
        }

        public async Task<KhoaDto> GetByIdAsync(string makhoa)
        {
            var item = await _repository.GetByIdAsync(makhoa);
            if (item == null)
            {
                return null;
            }
            return _mappers.Map<KhoaDto>(item);
        }

        public async Task<bool> ItemExists(string makhoa)
        {
            return await _repository.ExistsAsync(makhoa);
        }

        public async Task UpdateAsync(string makhoa, KhoaDto khoa)
        {
            var existingItem = await _repository.GetByIdAsync(makhoa);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = _mappers.Map(khoa, existingItem);

            await _repository.UpdateAsync(existingItem);
        }
    }
}
