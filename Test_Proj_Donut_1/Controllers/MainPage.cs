using Microsoft.AspNetCore.Mvc;

namespace Test_Proj_Donut_1.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index() { return View(); }
    }
}
