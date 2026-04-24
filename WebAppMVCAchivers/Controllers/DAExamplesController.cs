using Microsoft.AspNetCore.Mvc;
using WebAppMVCAchivers.DTO;

namespace WebAppMVCAchivers.Controllers
{
    public class DAExamplesController : Controller
    {
        [HttpGet]
        public IActionResult Example()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Example(ValidModel data)
        {
            if (ModelState.IsValid)
            {

                TempData["res"] = "All Good";
                return View();
            }
            else
            {
                TempData["res"]= "Validation Failed";   
                return View();
            }
        }
    }
}
