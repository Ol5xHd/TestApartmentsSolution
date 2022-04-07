using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class House
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        public int StreetID { get; set; }

        public virtual Street Street { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}