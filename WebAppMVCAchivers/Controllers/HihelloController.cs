using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCAchivers.Controllers
{
    // [Route("[controller]/[action]")]
    // [Route("Client/[action]")]
    [Route("[controller]")]
    public class HihelloController : Controller
    {
        [Route("GetAllData")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Index1")]

        public IActionResult Index1()
        {
            return View();
        }

        [Route("Index2")]

        public IActionResult Index2()
        {
            return View();
        }


        [Route("GetMyProfile/{id?}")]
        public IActionResult GetMyProfile(int? id)
        {
            TempData["res"] = id;
            return View();
        }

    }
}
