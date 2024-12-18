using Microsoft.AspNetCore.Mvc;

namespace QL_ThiTracNghiem_WebApp.Controllers
{
    public class HocPhanController : Controller
    {
        public IActionResult QuanLyHocPhan()
        {
            return View();
        }
    }
}
