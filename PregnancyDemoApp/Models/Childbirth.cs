using System;

namespace PregnancyDemoApp.Models
{
    public class Childbirth : UniqueEntityData
    {
        //public int MotherId { get; set; }
        //public Person Person { get; set; }

        //public int ObstetricianId { get; set; }
        //public Obstetrician Obstetrician { get; set; }

        public string Notes { get; set; }
        // 1-1 suhe rasedusega
        public int PregnancyId { get; set; }
        public Pregnancy Pregnancy { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
    }
}
