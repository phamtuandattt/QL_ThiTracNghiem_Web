using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.IRepository.ISinhVienRepository
{
    public interface ISinhVienRepository
    {
        Task<string> GetMaSV(string heDaoTao, string maKhoa, string namNhapHoc);
    }
}
