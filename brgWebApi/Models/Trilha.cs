using System;
using System.Collections.Generic;

namespace brgWebApi.Models
{
    public partial class Trilha
    {
        public short IdTrilha { get; set; }
        public short IdColaborador { get; set; }
        public short IdHabilidades { get; set; }
        public DateTime? DataTrilha { get; set; }

        public virtual Colaborador IdColaboradorNavigation { get; set; }
        public virtual Habilidades IdHabilidadesNavigation { get; set; }
    }
}
