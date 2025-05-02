using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableTap.Models;
using TableTap.Models.HelperModels;
using TableTap.Repositories;
using TableTap.Resources;

namespace TableTap.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public AdminController(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager, IPaymentMethodRepository paymentMethodRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _paymentMethodRepository = paymentMethodRepository;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdminAuth()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminAuth(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("Dashboard", "Admin");
                }
            }

            ModelState.AddModelError(string.Empty, SharedResource.InvalidLoginCredentials);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> PaymentMethods()
        {
            return View(await _paymentMethodRepository.GetAllPaymentMethodsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentMethod(PaymentMethodViewModel model)
        {
            if (!ModelState.IsValid)
                return View("PaymentMethods", model);

            var paymentMethod = new PaymentMethodModel
            {
                Name = model.MethodName,
                Type = model.Type,
                IsActive = model.IsActive,
                Description = model.Description
            };

            await _paymentMethodRepository.AddPaymentMethodAsync(paymentMethod);

            return RedirectToAction("PaymentMethods");
        }


    }
}
