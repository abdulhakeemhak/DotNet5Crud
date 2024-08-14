using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DotNet5Crud.Models;
using Microsoft.EntityFrameworkCore; 

namespace YourNamespace.Controllers
{
    public class AccountController : Controller
    {
        private readonly CompanyDBContext _context; 

        public AccountController(CompanyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    
                    return RedirectToAction("Index", "Employee");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }
    }
}
