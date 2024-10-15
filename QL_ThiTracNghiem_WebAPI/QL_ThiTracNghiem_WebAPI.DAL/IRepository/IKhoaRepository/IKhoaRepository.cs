using QL_ThiTracNghiem_WebAPI.DAL.Models;


namespace QL_ThiTracNghiem_WebAPI.DAL.IRepository.IKhoaRepository
{
    public interface IKhoaRepository
    {
        Task<Khoa> GetByIdAsync(string makhoa);
        Task<List<Khoa>> GetAllAsync();
        Task AddAsync(Khoa khoa);
        Task UpdateAsync(Khoa khoa);
        Task DeleteAsync(string makhoa);
        Task<bool> ExistsAsync(string makhoa);
    }
}
