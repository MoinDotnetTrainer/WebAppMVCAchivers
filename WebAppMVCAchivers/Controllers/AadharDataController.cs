using Microsoft.AspNetCore.Mvc;
using MyProjectLibrary.Interfaces;
using System.Threading.Tasks;

namespace WebAppMVCAchivers.Controllers
{
    public class AadharDataController : Controller
    {

        public readonly IAadhar _aadhar;
        public AadharDataController(IAadhar aadhar)
        {
            _aadhar = aadhar;
        }
        public async Task<IActionResult> Index()
        {
          var res=  await _aadhar.GetAadharData();
            return View(res);
        }

        public async Task<IActionResult> GetPan()
        {
            var res = await _aadhar.GetPanData();
            return View(res);
        }
    }
}
