using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetRobinF.Models
{
    public class Activite
    {
        [Key]
        public int ID_A { get; set; }
        public string Nom { get; set; }
        public string Addresse { get; set; }
        public string Description { get; set; }
        public string VilleID { get; set; }
        public virtual Ville Ville { get; set; }

    }
}