using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;


namespace QL_ThiTracNghiem_WebApi.BLL.IServices.IGiangVienServices
{
    public interface IGiangVienServices
    {
        Task<GiangVienDto> GetByIdAsync(string magv);
        Task<List<GiangVienDto>> GetAllAsync();
        Task AddAsync(GiangVienAddDto giangvien);
        Task UpdateAsync(string magv, GiangVienDto giangvien);
        Task DeleteAsync(string magv);
        Task<bool> ItemExists(string magv);
    }
}
