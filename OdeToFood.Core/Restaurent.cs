using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{
    public class Restaurent
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Location { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
