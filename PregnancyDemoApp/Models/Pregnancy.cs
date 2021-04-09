using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PregnancyDemoApp.Models
{
    public class Pregnancy : UniqueEntityData
    {
        public DateTime DueDate { get; set; }

        //1 arst - mitu sünnitust
        public int ObstetricianId { get; set; }
        public Obstetrician Obstetrician { get; set; }

        //1 ema - mitu rasedust
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public ICollection<Childbirth> Births { get; set; }
    }
}
