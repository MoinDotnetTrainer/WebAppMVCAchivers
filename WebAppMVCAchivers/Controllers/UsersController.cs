using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProjectLibrary.Models;
using MyProjectLibrary.Interfaces;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

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
            return RedirectToAction("UsersData");
        }

        public async Task<IActionResult> UsersData()
        {
            var res = await _userBl.GetAllUsers();//users
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int ID)
        {
            var res = await _userBl.GetUserByID(ID);
            return View(res);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(Users data)
        {
            await _userBl.EditUsers(data);
            return RedirectToAction("UsersData");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int ID)
        {
            var res = await _userBl.GetUserByID(ID);
            return View(res);
        }


        [HttpPost, ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUserConfirm(int ID)
        {
            await _userBl.DeleteUser(ID);
            return RedirectToAction("UsersData");
        }

        [HttpGet]
        public IActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginModel data)
        {
            if (data == null)
            {
                TempData["ErrorMsg"] = "Invalid request.";
                return View();
            }

            try
            {
                var res = await _userBl.UserLogin(data);

                if (res)
                {
                    return RedirectToAction("HomePage");
                }

                TempData["ErrorMsg"] = "Invalid email or password.";
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View(data);
            }
        }
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Authenticate");
        }
        public IActionResult Validation()
        {
            return View();
        }
    }
}
