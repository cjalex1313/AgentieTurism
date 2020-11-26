using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Data.Models
{
    public class Statiune
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public ICollection<Sejur> Sejururi { get; set; }
        public ICollection<Client> Clienti { get; set; }
    }
}
