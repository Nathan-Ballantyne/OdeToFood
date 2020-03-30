using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurent Restaurent { get; set; }
        public IResturantData ResturantData { get; }
        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int restaurentId)
        {
            Restaurent = ResturantData.GetById(restaurentId);
            if(Restaurent == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public DetailModel(IResturantData resturantData)
        {
            ResturantData = resturantData;
        }
    }
}