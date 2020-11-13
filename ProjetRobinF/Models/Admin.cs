using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetRobinF.Models
{
    public class Admin
    {
        [Key]
        public int idAdmin { get; set; }
        [Required]
        public string Pseudo { get; set; }
        [Required]
        public string Password { get; set; }

       
    }
}