using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentieTurism.Models
{
    public class CreateStatiuneViewModel
    {
        [Required]
        public string Nume { get; set; }
        public bool SejurAferent { get; set; }
    }
}
