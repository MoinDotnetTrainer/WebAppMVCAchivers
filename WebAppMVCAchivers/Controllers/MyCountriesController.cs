using Microsoft.AspNetCore.Mvc;
using MyProjectLibrary.Interfaces;

namespace WebAppMVCAchivers.Controllers
{
    public class MyCountriesController : Controller
    {
        public readonly ICountry _countryBl;
        public MyCountriesController(ICountry countryBl)
        {
            _countryBl = countryBl;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _countryBl.GetCountriesAsync();
            return View(res);
        }
        public async Task<IActionResult> LazyLoad()
        {
            var res = await _countryBl.GetCountriesAsyncLazy();
            return View(res);
        }
    }
}
