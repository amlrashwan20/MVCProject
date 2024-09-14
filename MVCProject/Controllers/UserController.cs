using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Context;


namespace MVCProject.Controllers
{           
    public class UserController : Controller
    {   ProjectContext lab = new ProjectContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()       //registration
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = lab.users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ViewBag.SuccessMessage = "Registration successful! You can now log in.";
                    ModelState.AddModelError("Email", "Email is already registered");
                   
                    return View(user);

                }
                else
                {
                    ViewBag.ErrorMessage = "Invaild Registration!";
                }

                // Add the user to the database or perform some other action to complete the registration process
                lab.users.Add(user);
                lab.SaveChanges();
                return RedirectToAction("Login", "User");
            }
           

            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)          //login
        {
            var query= lab.users.SingleOrDefault(m=>m.Email == user.Email && m.Password == user.Password);
            if (query != null)
            {
                ViewBag.SuccessMessage = "Login successful ,welcome in our website";
                Response.Redirect("/Product/Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invaild login!";

            }
            return View();
        }
       

    }
}
