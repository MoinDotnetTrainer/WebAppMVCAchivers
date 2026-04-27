using Microsoft.AspNetCore.Mvc;
using MyProjectLibrary.Interfaces;
using MyProjectLibrary.Models;
using System.Threading.Tasks;

namespace WebAppMVCAchivers.Controllers
{
    public class UsersSpController : Controller
    {
        public readonly IUsersSp _iusersp;
        public UsersSpController(IUsersSp iusersp)
        {
            _iusersp = iusersp;
        }

        public async Task<IActionResult> Index()
        {
            var res =await _iusersp.GetAllUsers();
            return View(res);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Users data)
        {
            await _iusersp.AddUsers(data);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            var res = await _iusersp.GetUserByID(ID);
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Users Data)
        {
            await _iusersp.EditUsers(Data);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {
            var res = await _iusersp.GetUserByID(ID);
            return View(res);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            var res = _iusersp.DeleteUser(ID);
            return RedirectToAction("Index");
        }
    }
}
