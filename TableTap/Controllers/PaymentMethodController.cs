using Microsoft.AspNetCore.Mvc;
using TableTap.Models.HelperModels;
using TableTap.Models;
using TableTap.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TableTap.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }
        public async Task<IActionResult> PaymentMethodsMenu()
        {
            return View(await _paymentMethodRepository.GetAllPaymentMethodsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentMethod(PaymentMethodViewModel model)
        {
            if (!ModelState.IsValid)
                return View("PaymentMethodsMenu", model);

            var paymentMethod = new PaymentMethodModel
            {
                Name = model.MethodName,
                Type = model.Type,
                IsActive = model.IsActive,
                Description = model.Description
            };

            await _paymentMethodRepository.AddPaymentMethodAsync(paymentMethod);

            return RedirectToAction("PaymentMethodsMenu");
        }

        [HttpPost]
        public async Task<IActionResult> EditPaymentMethod(int id, PaymentMethodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["MethodNameError"] = "Invalid name.";
                return View("PaymentMethods", await _paymentMethodRepository.GetAllPaymentMethodsAsync());
            }

            var method = await _paymentMethodRepository.GetPaymentMethodByIdAsync(id);
            if (method == null)
                return NotFound();

            method.Name = model.MethodName;
            method.Type = model.Type;
            method.IsActive = model.IsActive;
            method.Description = model.Description;

            await _paymentMethodRepository.UpdatePaymentMethodAsync(method);

            return RedirectToAction("PaymentMethodsMenu");
        }

        [HttpPost]
        public async Task<IActionResult> TogglePaymentMethodStatus(int id)
        {
            var method = await _paymentMethodRepository.GetPaymentMethodByIdAsync(id);
            if (method == null)
                return NotFound();

            await _paymentMethodRepository.TogglePaymentMethodStatusAsync(id);

            return RedirectToAction("PaymentMethodsMenu");
        }

    }
}
