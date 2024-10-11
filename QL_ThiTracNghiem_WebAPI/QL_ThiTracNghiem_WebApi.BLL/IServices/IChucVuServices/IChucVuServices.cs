using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.IChucVuServices
{
    public interface IChucVuServices
    {
        IEnumerable<Chucvu> chucvus();
        Chucvu chucvu(int macv);
        void insert(Chucvu chucvu);
        void delete(int mavc);
        void update(Chucvu chucvu);
        void savechange();
        bool ItemExists(int mavc);
    }
}
