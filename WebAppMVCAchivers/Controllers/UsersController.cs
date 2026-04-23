using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProjectLibrary.Models;
using MyProjectLibrary.Interfaces;

namespace WebAppMVCAchivers.Controllers
{
    public class UsersController : Controller
    {
        public readonly IUsers _userBl;
        public UsersController(IUsers userbl)
        {
            _userBl = userbl;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]// get the data from ui to model
        public async Task<IActionResult> CreateUser(Users data)
        {
            await _userBl.AddUsers(data);  // service dll file
            return View();
        }
    }
}
