using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Client
    {
        public Client()
        {
            Adresse = new HashSet<Adresse>();
            Fiche = new HashSet<Fiche>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Adresse> Adresse { get; set; }
        public virtual ICollection<Fiche> Fiche { get; set; }
    }
}
