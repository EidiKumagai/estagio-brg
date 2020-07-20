using System;
using System.Collections.Generic;

namespace brgWebApi.Models
{
    public partial class Habilidades
    {
        public Habilidades()
        {
            Trilha = new HashSet<Trilha>();
        }

        public short IdHabilidades { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Trilha> Trilha { get; set; }
    }
}
