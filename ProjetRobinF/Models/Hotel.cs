﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetRobinF.Models
{
    public class Hotel
    {
        [Key]
        public int ID_H { get; set; }
        public string Nom { get; set; }
        public int Etoile { get; set; }
        public int Prix { get; set; }
        public string VilleID { get; set; }
        public virtual Ville Ville { get; set; }

    }
}