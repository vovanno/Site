using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Car
    {
        [Key]        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Year { get; set; }
        public string Gabarites { get; set; }
    }
}