using QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.KhoaServices
{
    public class KhoaServices : IKhoaServices
    {
        private readonly QlHethongthitracnghiemContext _context;

        public KhoaServices(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public void Delete(string makhoa)
        {
            _context.Remove(Get(makhoa));
        }

        public Khoa Get(string makhoa)
        {
            return _context.Khoas.Find(makhoa) ?? new Khoa();
        }

        public IEnumerable<Khoa> GetAll()
        {
            return _context.Khoas.ToList() ?? new List<Khoa>();
        }

        public void Insert(Khoa khoa)
        {
            _context.Khoas.Add(khoa);
        }

        public bool ItemExists(string makhoa)
        {
            return (_context.Khoas?.Any(e => e.Makhoa == makhoa)).GetValueOrDefault();
        }

        public void Savechange()
        {
            _context.SaveChanges();
        }

        public void Update(Khoa khoa)
        {
            _context.Entry(khoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
