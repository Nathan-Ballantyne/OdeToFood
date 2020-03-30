using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {

        private readonly IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurent Restaurent { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper)
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(int? restaurentId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if(restaurentId.HasValue)
            {
                Restaurent = resturantData.GetById(restaurentId.Value);
            }
            else
            {
                Restaurent = new Restaurent();
            }
            if (Restaurent == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if(Restaurent.Id > 0)
            {
                resturantData.update(Restaurent);
            }
            else
            {
                resturantData.add(Restaurent);
            }
            resturantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { restaurentId = Restaurent.Id });
        }
    }
}