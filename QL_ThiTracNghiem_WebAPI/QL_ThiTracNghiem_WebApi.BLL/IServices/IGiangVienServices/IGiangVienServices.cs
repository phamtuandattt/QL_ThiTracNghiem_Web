using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.IGiangVienServices
{
    public interface IGiangVienServices
    {
        IEnumerable<Giangvien> giangviens();
        Giangvien giangvien(string magv);
        void insert (Giangvien giangvien);
        void delete (string magv);
        void update(Giangvien giangvien);
        void savechange();
    }
}
