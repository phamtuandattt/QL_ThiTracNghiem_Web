using Microsoft.AspNetCore.Mvc;

namespace QL_ThiTracNghiem_WebApp.Controllers
{
    public class DeThiController : Controller
    {
        public IActionResult QuanLyDeThi()
        { 
            return View();
        }

        public IActionResult TaoDeThi()
        {
            return View();
        }
    }
}
