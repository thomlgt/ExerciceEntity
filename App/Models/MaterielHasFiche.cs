using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class MaterielHasFiche
    {
        public int Id { get; set; }
        public int MaterielId { get; set; }
        public int FicheId { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public virtual Fiche Fiche { get; set; }
        public virtual Materiel Materiel { get; set; }
    }
}
