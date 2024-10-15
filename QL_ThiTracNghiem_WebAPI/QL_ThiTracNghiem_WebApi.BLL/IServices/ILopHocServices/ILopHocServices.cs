

using QL_ThiTracNghiem_WebApi.BLL.Dtos;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices
{
    public   interface ILopHocServices
    {
        Task<LopHocDto> GetByIdAsync(string malop);
        Task<List<LopHocDto>> GetAllAsync();
        Task AddAsync(LopHocDto lophoc);
        Task UpdateAsync(string malop, LopHocDto lophoc);
        Task DeleteAsync(string malop);
        Task<bool> ItemExists(string malh);
    }
}
