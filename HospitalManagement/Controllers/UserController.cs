using HospitalManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class UserController : Controller
    {

        UserModel userObj = new UserModel();

        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult register(UserModel user)
        {
            bool res;
            userObj=new UserModel();
            res=userObj.Insert(user);
            if (res)
            {
                TempData["msg"] = "register successfully";
            }
            else
            {
                TempData["msg"] = "not register successfully";
            }
            return View();
        }

        public IActionResult register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult login(UserModel user)
        {
            bool res;
            userObj = new UserModel();
            res = userObj.login(user);
            if (res)
            {
                TempData["msg"] = "login successfully";
                HttpContext.Session.SetString("email", user.email);

            }
            else
            {
                TempData["msg"] = "not login successfully";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       
        public IActionResult dashboard()
        {
            ViewData["email"] = HttpContext.Session.GetString("email");
            if(ViewData["email"] == "") { return RedirectToAction("login", "User"); }
            else
            {
                return View();


            }


        }
       
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email");

            return RedirectToAction("login", "User");
        }












    }
}
