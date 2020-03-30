using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IResturantData resturantData;

        public DeleteModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }

        public Restaurent Restaurent { get; set; }

        public IActionResult OnGet(int restarantId)
        {
            Restaurent = resturantData.GetById(restarantId);
            if(Restaurent == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restarantId)
        {
            var restaurant = resturantData.Delete(restarantId);
            resturantData.Commit();
            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{ restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}