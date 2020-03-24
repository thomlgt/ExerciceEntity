using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Materiel = new HashSet<Materiel>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Libellé { get; set; }

        public virtual ICollection<Materiel> Materiel { get; set; }
    }
}
