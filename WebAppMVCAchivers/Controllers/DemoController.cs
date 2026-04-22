using Microsoft.AspNetCore.Mvc;
using WebAppMVCAchivers.Models;

namespace WebAppMVCAchivers.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Test()
        {
            //returns a  view
            TempData["res"] = System.DateTime.Now.ToLongTimeString();
            return View();
        }

        // two events 
        //get 
        //post


        [HttpGet]  // onload
        public IActionResult Add()
        {
            TempData["res"] = "No Result On Load:";
            return View();
        }

        [HttpPost]  // on click
        public IActionResult Add(int x, int y)
        {
            int z = x + y;
            TempData["res"] = "On click:" + z;
            return View();
        }



        [HttpGet]
        public IActionResult Sub()
        {
            TempData["res"] = "No Result On Load:";
            return View();
        }


        [HttpPost]
        public IActionResult Sub(MyProp obj)
        {
            // X & Y from UI
            // Myprop is a  model which transafer data  from UI to controller   
            // controller to view
            int z = obj.x - obj.y;
            TempData["res"] = "On click:" + z;
            return View();
        }
    }
}
