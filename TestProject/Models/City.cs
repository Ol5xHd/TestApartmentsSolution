using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
    }
}