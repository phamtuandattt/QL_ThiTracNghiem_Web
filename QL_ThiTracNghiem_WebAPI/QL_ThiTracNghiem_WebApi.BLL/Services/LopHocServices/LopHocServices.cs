

using Microsoft.EntityFrameworkCore.ChangeTracking;
using QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices;
using QL_ThiTracNghiem_WebAPI.DAL.Models;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.LopHocServices
{
    public class LopHocServices : ILopHocServices
    {
        private readonly QlHethongthitracnghiemContext _context;
        public LopHocServices(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public void Delete(string malh)
        {
            throw new NotImplementedException();
        }

        public Lophoc Get(string malh)
        {
            return _context.Lophocs.Find(malh) ?? new Lophoc();
        }

        public IEnumerable<Lophoc> GetAll()
        {
            return _context.Lophocs.ToList() ?? new List<Lophoc>();
        }

        public void Insert(Lophoc lophoc)
        {
            _context.Lophocs.Add(lophoc);
        }

        public bool ItemExists(string malh)
        {
            return (_context.Lophocs?.Any(e => e.Malop == malh)).GetValueOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Lophoc lophoc)
        {
            _context.Entry(lophoc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
