using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;
using WebAppMVCAchivers.DTO;

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
        public async Task<IActionResult> CreateUser(WebAppMVCAchivers.DTO.Users data)
        {
            if (ModelState.IsValid)// dto prop all data ann
            {
                var res = new MyProjectLibrary.Models.Users
                {
                    Name = data.Name,
                    Email = data.Email,
                    Password = data.Password,
                    Dob = data.Dob
                };

                await _userBl.AddUsers(res);  // service dll file
                return RedirectToAction("UsersData");
            }
            else
            {
                return View(data);
            }
        }

        public async Task<IActionResult> UsersData()
        {
            var login = HttpContext.Session.GetString("Mylogin");

            if (login == null)
            {
                return RedirectToAction("Authenticate");
            }
            var res = await _userBl.GetAllUsers();//users
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int ID)
        {
            var login = HttpContext.Session.GetString("Mylogin");

            if (login == null)
            {
                return RedirectToAction("Authenticate");
            }
            var res = await _userBl.GetUserByID(ID);
            return View(res);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(WebAppMVCAchivers.DTO.Users data)
        {
            var res = new MyProjectLibrary.Models.Users
            {
                ID = data.ID,
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                Dob = data.Dob
            };
            await _userBl.EditUsers(res);
            return RedirectToAction("UsersData");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int ID)
        {
            var login = HttpContext.Session.GetString("Mylogin");

            if (login == null)
            {
                return RedirectToAction("Authenticate");
            }
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
        public async Task<IActionResult> Authenticate(WebAppMVCAchivers.DTO.LoginModel data)
        {
            if (ModelState.IsValid)
            {
                if (data == null)
                {
                    TempData["ErrorMsg"] = "Invalid request.";
                    return View();
                }

                try
                {

                    var result = new MyProjectLibrary.Models.LoginModel
                    {
                        Email = data.Email,
                        Password = data.Password,

                    };
                    var res = await _userBl.UserLogin(result);

                    if (res)
                    {
                        HttpContext.Session.SetString("Mylogin", data.Email);
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
            else
            {
                return View(data);
            }
        }
        public IActionResult HomePage()
        {
            var login = HttpContext.Session.GetString("Mylogin");

            if (login == null)
            {
                return RedirectToAction("Authenticate");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Mylogin");
            return RedirectToAction("Authenticate");
        }
        public IActionResult Validation()
        {
            var login = HttpContext.Session.GetString("Mylogin");

            if (login == null)
            {
                return RedirectToAction("Authenticate");
            }
            return View();
        }
    }
}
