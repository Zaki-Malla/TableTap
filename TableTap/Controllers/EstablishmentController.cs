using Microsoft.AspNetCore.Mvc;
using TableTap.Models;
using TableTap.Models.HelperModels;
using TableTap.Repositories;

namespace TableTap.Controllers
{
    public class ManageEstablishmentController : Controller
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly ICityRepository _cityRepository;

        public ManageEstablishmentController(IEstablishmentRepository establishmentRepository, ICityRepository cityRepository)
        {
            _establishmentRepository = establishmentRepository;
            _cityRepository = cityRepository;
        }
        public async Task<IActionResult> ManageEstablishment()
        {
            var model = new ManageEstablishmentViewModel
            {
                Establishments = await _establishmentRepository.GetAllEstablishmentsAsync(),
                Cities = await _cityRepository.GetAllCitysAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddEstablishment(EstablishmentViewModel model)
        {

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            if (model != null)
            {
                if (model.Image != null && model.Image.Length > 0)
                {
                    //var extension = Path.GetExtension(model.Image.FileName).ToLower();
                    //var contentType = model.Image.ContentType.ToLower();

                    //if (extension != ".png" || contentType != "image/png")
                    //{
                    //    ModelState.AddModelError("ImageFile", "Only PNG files are allowed.");
                    //    return RedirectToAction("ManageEstablishment");
                    //}

                    string uniqueFileName = Guid.NewGuid().ToString() + "_TableTap";
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }

                    var establishment = new EstablishmentModel
                    {
                        ImagePath = "/images/" + uniqueFileName,
                        Name = model.Name,
                        Address = model.Address,
                        CityId = model.CityId

                    };

                    await _establishmentRepository.AddEstablishmentAsync(establishment);

                }
                
            }
            return RedirectToAction("ManageEstablishment");

        }

    }
}
