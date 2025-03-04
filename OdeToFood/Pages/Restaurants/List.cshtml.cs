﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        public string Message { get; set; }
        public IEnumerable<Restaurent> Restaurents { get; set; }
        public IResturantData resturantData { get; }
            
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IResturantData resturantData)
        {
            this.config = config;
            this.resturantData = resturantData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurents = resturantData.GetRestaruentsByName(SearchTerm);
        }

        
    }
}
