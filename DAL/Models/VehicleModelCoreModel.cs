using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class VehicleModelCoreModel
    {
        public int? Page { get; set; }

        public  string SearchString { get; set; }

        public  string Filter { get; set; }

        public  string SortValue { get; set; }

        public int Id { get; set; }

        public int? MakeId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Abrv { get; set; }
    }
}
