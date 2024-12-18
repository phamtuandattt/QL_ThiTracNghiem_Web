using Microsoft.AspNetCore.Mvc;

namespace QL_ThiTracNghiem_WebApp.Controllers
{
    public class LopHocController : Controller
    {
        public IActionResult QuanLyLopHoc()
        {
            return View();
        }
    }
}
