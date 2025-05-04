using Microsoft.AspNetCore.Mvc;
using TableTap.Models.HelperModels;
using TableTap.Models;
using TableTap.Repositories;

namespace TableTap.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IActionResult> CitiesMenu()
        {
            return View(await _cityRepository.GetAllCitysAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityViewModel model)
        {
            if (!ModelState.IsValid)
                return View("CitiesMenu", model);

            var city = new CityModel
            {
                Name = model.Name,
                IsActive = model.IsActive
            };

            await _cityRepository.AddCityAsync(city);

            return RedirectToAction("CitiesMenu");
        }

        [HttpPost]
        public async Task<IActionResult> EditCity(int id, CityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["cityNameError"] = "Invalid name.";
                return View("Citys", await _cityRepository.GetAllCitysAsync());
            }

            var city = await _cityRepository.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            city.Name = model.Name;
            city.IsActive = model.IsActive;

            await _cityRepository.UpdateCityAsync(city);

            return RedirectToAction("CitiesMenu");
        }

        [HttpPost]
        public async Task<IActionResult> ToggleCityStatus(int id)
        {
            var city = await _cityRepository.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            await _cityRepository.ToggleCityStatusAsync(id);

            return RedirectToAction("CitiesMenu");
        }
    }
}
