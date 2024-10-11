using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices
{
    public interface IKhoaServices
    {
        IEnumerable<Khoa> GetAll();
        Khoa Get(string makhoa);
        void Insert(Khoa khoa);
        void Delete(string makhoa);
        void Update(Khoa khoa);
        void Savechange();
        bool ItemExists(string makhoa);
    }
}
