using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PregnancyDemoApp.Models
{
    public class Obstetrician : UniqueEntityData
    {
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Pregnancy> Pregnancies { get; set; }
    }
}
