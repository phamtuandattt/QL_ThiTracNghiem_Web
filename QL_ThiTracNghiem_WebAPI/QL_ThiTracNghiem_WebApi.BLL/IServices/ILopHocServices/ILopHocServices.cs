using QL_ThiTracNghiem_WebApi.BLL.Dtos.LopHocDto;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices
{
    public   interface ILopHocServices
    {
        Task<LopHocDto> GetByIdAsync(string malop);
        Task<List<LopHocDto>> GetAllAsync();
        Task AddAsync(LopHocAddDto lophoc);
        Task UpdateAsync(string malop, LopHocDto lophoc);
        Task DeleteAsync(string malop);
        Task<bool> ItemExists(string malh);
    }
}
