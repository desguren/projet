
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ProjetRobinF.Models
{
    public class Ville
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string Nom { get; set; }
        public string Region { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Activite> Activite { get; set; }

     
    }
}