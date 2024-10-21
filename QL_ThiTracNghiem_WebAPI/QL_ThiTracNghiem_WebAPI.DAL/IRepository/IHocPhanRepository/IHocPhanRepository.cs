using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.IRepository.IHocPhanRepository
{
    public interface IHocPhanRepository
    {
        Task<string> GetMaHocPhan();
    }
}
