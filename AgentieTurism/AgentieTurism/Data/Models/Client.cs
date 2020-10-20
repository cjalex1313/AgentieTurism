using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string NumarCI { get; set; }
        public string SerieCI { get; set; }
        public string Adresa { get; set; }
        public string NrTel { get; set; }
        public DateTime? PerioadaSejurDoritaStart { get; set; }
        public DateTime? PerioadaSejurDoritaSfarsit { get; set; }
        public int? StatiuneDoritaId { get; set; }

        [ForeignKey("StatiuneDoritaId")]
        public virtual Statiune StatiuneDorita { get; set; }
    }
}
