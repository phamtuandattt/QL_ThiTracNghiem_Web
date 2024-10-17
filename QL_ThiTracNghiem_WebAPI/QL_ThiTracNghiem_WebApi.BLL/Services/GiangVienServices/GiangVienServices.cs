using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IGiangVienServices;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.DAL.Repository;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.GiangVienServices
{
    public class GiangVienServices : IGiangVienServices
    {
        private readonly IRepository<Giangvien> _giangVienRepository;
        private readonly IMapper _mapper;

        public GiangVienServices(IRepository<Giangvien> repository, IMapper mapper)
        {
            _giangVienRepository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(GiangVienAddDto giangvien)
        {
            var item = _mapper.Map<Giangvien>(giangvien);
            await _giangVienRepository.AddAsync(item);
        }

        public async Task DeleteAsync(string magv)
        {
            await _giangVienRepository.DeleteAsync(magv);
        }

        public async Task<List<GiangVienDto>> GetAllAsync()
        {
            var items = await _giangVienRepository.GetAllAsync();
            return _mapper.Map<List<GiangVienDto>>(items);
        }

        public async Task<GiangVienDto> GetByIdAsync(string magv)
        {
            var item = await _giangVienRepository.GetByIdAsync(magv);
            if (item != null)
            {
                return _mapper.Map<GiangVienDto>(item);
            }
            return null;
        }

        public async Task<bool> ItemExists(string magv)
        {
            return await _giangVienRepository.ExistsAsync(magv);
        }

        public async Task UpdateAsync(string magv, GiangVienDto giangvien)
        {
            var existingItem = await _giangVienRepository.GetByIdAsync(magv);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            var a = _mapper.Map(giangvien, existingItem);
            await _giangVienRepository.UpdateAsync(existingItem);
        }

        //private void UploadImage(IFormFile img, string webAlias, ref string fileNameInDb)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(webAlias))
        //        {
        //            var fileName = img.FileName;
        //            fileName = fileName.Trim(Path.GetInvalidFileNameChars());

        //            // Processing upload file to Azure
        //            var azureStore = new AzureStore();
        //            fileNameInDb = fileName;
        //            // .net 6
        //            var thumbnailStream = ImageHelper.GetThumbnailStream(img.OpenReadStream());
        //            thumbnailStream.Position = 0;
        //            azureStore.UploadImage(webAlias, thumbnailStream, ref fileNameInDb);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error("ERROR: Upload file to azure CDN failed: ", ex);
        //    }
        //}
    }
}
