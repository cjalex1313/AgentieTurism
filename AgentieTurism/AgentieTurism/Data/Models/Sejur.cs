using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Data.Models
{
    public class Sejur
    {
        public int Id { get; set; }
        [Display(Name = "Data inceput")]
        [DataType(DataType.Date)]
        public DateTime DataStart { get; set; }
        [Display(Name = "Data sfarsit")]
        [DataType(DataType.Date)]
        public DateTime DataSfarsit { get; set; }
        [Display(Name = "Statiune")]
        public int StatiuneId { get; set; }

        [Display(Name = "Statiune")]
        [ForeignKey("StatiuneId")]
        public virtual Statiune Statiune { get; set; }
    }
}
