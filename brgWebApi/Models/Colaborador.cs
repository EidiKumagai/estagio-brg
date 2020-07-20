using System;
using System.Collections.Generic;

namespace brgWebApi.Models
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            Trilha = new HashSet<Trilha>();
        }

        public short IdColaborador { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }

        public virtual ICollection<Trilha> Trilha { get; set; }
    }
}
