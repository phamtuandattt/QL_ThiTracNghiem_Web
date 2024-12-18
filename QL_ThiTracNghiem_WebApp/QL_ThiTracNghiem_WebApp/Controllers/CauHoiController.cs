using Microsoft.AspNetCore.Mvc;

namespace QL_ThiTracNghiem_WebApp.Controllers
{
    public class CauHoiController : Controller
    {
        public IActionResult DanhSachCauHoi()
        {
            return View();
        }

        public IActionResult DuyetNHCauHoi()
        {
            return View();
        }
    }
}
