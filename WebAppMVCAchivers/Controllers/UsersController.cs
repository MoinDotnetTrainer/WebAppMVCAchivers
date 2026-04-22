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
        public IActionResult CreateUser(Users data)
        {
            _userBl.AddUsers(data);
            return View();
        }
    }
}
