using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Materiel
    {
        public Materiel()
        {
            MaterielHasFiche = new HashSet<MaterielHasFiche>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public DateTime? DateAchat { get; set; }
        public double? PrixLoc { get; set; }
        public int CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }
        public virtual ICollection<MaterielHasFiche> MaterielHasFiche { get; set; }
    }
}
