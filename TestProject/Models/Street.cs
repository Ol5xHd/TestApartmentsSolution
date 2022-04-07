using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Street
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}