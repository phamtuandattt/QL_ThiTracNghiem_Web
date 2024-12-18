using Microsoft.AspNetCore.Mvc;

namespace QL_ThiTracNghiem_WebApp.Controllers
{
    public class CaThiController : Controller
    {
        public IActionResult TaoCaThi()
        {
            return View();
        }

        public IActionResult QuanLyCaThi()
        {
            return View();
        }
    }
}
