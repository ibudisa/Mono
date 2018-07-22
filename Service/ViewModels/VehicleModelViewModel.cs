using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service
{
    public class VehicleModelViewModel
    {
        public int Id { get; set; }

        public int? MakeId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Abrv { get; set; }
    }
}