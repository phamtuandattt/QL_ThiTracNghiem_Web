using QL_ThiTracNghiem_WebApi.BLL.IServices.IChucVuServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.ChucVuServices
{
    public class ChucVuServices : IChucVuServices
    {
        private readonly QlHethongthitracnghiemContext _context;

        public ChucVuServices(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public Chucvu chucvu(int macv)
        {
            return _context.Chucvus.Find(macv) ?? new Chucvu();    
        }

        public IEnumerable<Chucvu> chucvus()
        {
            return _context.Chucvus.ToList() ?? new List<Chucvu>();
        }

        public void delete(int mavc)
        {
            _context.Chucvus.Remove(chucvu(mavc));
        }

        public void insert(Chucvu chucvu)
        {
            _context.Chucvus.Add(chucvu);
        }

        public void savechange()
        {
            _context.SaveChanges();
        }

        public void update(Chucvu chucvu)
        {
            _context.Entry(chucvu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
