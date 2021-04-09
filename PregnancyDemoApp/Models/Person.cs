using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PregnancyDemoApp.Models
{
    public class Person : Gender
    {
        [Required]
        public string NatIdNr { get; set; }
        public string Address { get; set; }
        public Obstetrician Obstetrician { get; set; }
        public ICollection<Pregnancy> Pregnancies { get; set; }
    }
}
