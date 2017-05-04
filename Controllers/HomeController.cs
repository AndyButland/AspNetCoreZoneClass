using Microsoft.AspNetCore.Mvc;
using DoctorSearch.Services;
using DoctorSearch.ViewModels;
using System.Threading.Tasks;

namespace DoctorSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;

        public HomeController (ISearchService searchService)
        {
            _searchService = searchService;
        }
        
        public async Task<IActionResult> Index(string postcode)
        {
            var model = new HomeIndexViewModel
            {
                PageTitle = "Somebody get me a doctor!",
            };

            if (!string.IsNullOrEmpty(postcode))
            {
                model.Postcode = postcode;
                model.SearchRequested = true;

                model.Surgeries = await  _searchService.GetSurgeries(postcode);
            }
            
            return View("Index", model);
        }
   }
}
