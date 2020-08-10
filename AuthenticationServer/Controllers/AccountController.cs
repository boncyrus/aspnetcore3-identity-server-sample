using AuthenticationServer.Models;
using AuthenticationServer.Services;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var user = await _userService.Authenticate(vm.Username, vm.Password);

            if (user != null)
            {
                var issuer = new IdentityServerUser(user.Id)
                {
                    DisplayName = user.Username,
                };

                var principal = issuer.CreatePrincipal();

                await HttpContext.SignInAsync(principal);

                return Redirect(vm.ReturnUrl);
            }

            return View();
        }
    }
}