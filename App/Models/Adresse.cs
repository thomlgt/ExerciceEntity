using System;
using System.Collections.Generic;

namespace App.Models
{
    public partial class Adresse
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
