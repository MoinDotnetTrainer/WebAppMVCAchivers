using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCAchivers.Controllers
{
    public class MyData
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class StateManagementController : Controller
    {
        public IActionResult First()
        {
            ViewBag.res = "Some Data from viewbag:" + System.DateTime.Now.ToLongDateString();
            ViewData["res1"] = "SOme data from view data:" + System.DateTime.Now.ToLongDateString();
            TempData["res2"] = "Some data from temp data:" + System.DateTime.Now.ToLongDateString();
            HttpContext.Session.SetString("mydata", "Data from session:" + System.DateTime.Now.ToLongDateString());
            return RedirectToAction("Second");
            //   return View();
        }
        public IActionResult Second()
        {
            TempData.Keep("res2");
            // TempData.Peek("res2");
            TempData["res3"] = TempData["res2"];
       
            return View();
        }
        public IActionResult Third()
        {
            return View();
        }

        public IActionResult Four()
        {
            List<MyData> list = new List<MyData>()
            {
            new MyData{ID=1,Name="John"},
            new MyData{ID=2,Name="Jane"},
            };

            // ViewBag.res = list;  // dyn    
            ViewData["res"] = list;  // type casting needed
            return View();
        }
    }
}
