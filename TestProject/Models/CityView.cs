using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class CityView
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StreetsCount { get; set; }
    }
}