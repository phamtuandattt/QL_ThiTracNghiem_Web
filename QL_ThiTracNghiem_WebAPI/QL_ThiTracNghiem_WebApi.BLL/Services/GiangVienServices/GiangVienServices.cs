using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using QL_ThiTracNghiem_WebApi.BLL.IServices.IGiangVienServices;

namespace QL_ThiTracNghiem_WebApi.BLL.Services.GiangVienServices
{
    public class GiangVienServices : IGiangVienServices
    {
        private readonly QlHethongthitracnghiemContext _context;

        public GiangVienServices(QlHethongthitracnghiemContext _context)
        {
            this._context = _context;
        }

        public void delete(string magv)
        {
            var gv = _context.Giangviens.Find(magv);
            _context.Giangviens.Remove(gv);
        }

        public Giangvien giangvien(string magv)
        {
            return _context.Giangviens.Find(magv) ?? new Giangvien();
        }

        public IEnumerable<Giangvien> giangviens()
        {
            return _context.Giangviens.ToList();
        }

        public void insert(Giangvien giangvien)
        {
            _context.Add(giangvien);
        }

        public void savechange()
        {
            _context.SaveChanges();
        }

        public void update(Giangvien giangvien)
        {
            _context.Entry(giangvien).State = EntityState.Modified;
        }

        //private void UploadImage(IFormFile img, string webAlias, ref string fileNameInDb)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(webAlias))
        //        {
        //            var fileName = img.FileName;
        //            fileName = fileName.Trim(Path.GetInvalidFileNameChars());

        //            // Processing upload file to Azure
        //            var azureStore = new AzureStore();
        //            fileNameInDb = fileName;
        //            // .net 6
        //            var thumbnailStream = ImageHelper.GetThumbnailStream(img.OpenReadStream());
        //            thumbnailStream.Position = 0;
        //            azureStore.UploadImage(webAlias, thumbnailStream, ref fileNameInDb);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error("ERROR: Upload file to azure CDN failed: ", ex);
        //    }
        //}
    }
}
