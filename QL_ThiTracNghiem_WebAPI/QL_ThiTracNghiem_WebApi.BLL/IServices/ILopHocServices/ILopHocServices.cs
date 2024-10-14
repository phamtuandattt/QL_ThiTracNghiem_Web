

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.ILopHocServices
{
    public   interface ILopHocServices
    {
        Lophoc Get(string malh);
        IEnumerable<Lophoc> GetAll();
        void Insert(Lophoc lophoc);
        void Update(Lophoc lophoc);
        void Delete(string malh);
        void SaveChanges();
        bool ItemExists(string malh);
    }
}
