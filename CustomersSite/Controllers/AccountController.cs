using CustomersSite.Services;
using Microsoft.AspNetCore.Mvc;
using Solution.Data.Models.UserModels;

namespace CustomersSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthApiClient _authApiClient;
        private readonly IUserApiClient _userApiClient;
        public AccountController(IAuthApiClient authApiClient, IUserApiClient userApiClient)
        {
            _authApiClient = authApiClient;
            _userApiClient = userApiClient;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            var token = await _authApiClient.GetToken(loginUser);
            if (string.IsNullOrEmpty(token))
            {
                ViewBag.LoginStatus = "Tên tài khoản hoặc mật khẩu không chính xác.";
                return View();
            }
            Response.Cookies.Append("JWTToken", token);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("JWTToken");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RegisterError = "Cannot Register.";
                return View();
            }
            if (registerUser.PhoneNumber == null)
            {
                registerUser.PhoneNumber = "";
            }
            var result = await _userApiClient.Register(registerUser);
            if (result != null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.RegisterError = "Cannot Register.";
            return View();
        
        }
    }
}
