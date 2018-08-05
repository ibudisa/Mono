using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vehicle.MVC.ViewModels
{
    public class VehicleMakeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name {0} is required")]
        [StringLength(50, MinimumLength = 3,
         ErrorMessage = "Name Should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Abrv {0} is required")]
        [StringLength(50, MinimumLength = 2,
         ErrorMessage = "Name Should be minimum 2 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string Abrv { get; set; }
    }
}