using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Fiche
    {
        public Fiche()
        {
            MaterielHasFiche = new HashSet<MaterielHasFiche>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<MaterielHasFiche> MaterielHasFiche { get; set; }
    }
}
