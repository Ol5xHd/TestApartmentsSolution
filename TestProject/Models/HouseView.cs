using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class HouseView
    {
        [Key]
        public int HouseId { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentsCount { get; set; }
        public double CommonArea { get; set; }
    }
}