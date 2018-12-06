using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public int Stage { get; set; }
        [ForeignKey("CarRef")]
        public int CarId { get; set; }
        public virtual Car CarRef { get; set; }
    }
}