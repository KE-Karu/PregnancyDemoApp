using System;

namespace PregnancyDemoApp.Models
{
    public class Pregnancy : UniqueEntityData
    { 
        //1-1 suhe
        public int ChildbirthId { get; set; }
        public Childbirth Childbirth { get; set; }

        //1 ema - mitu rasedust
        public int MotherId { get; set; }
        public Person Person { get; set; }

        //public DateTime DueDate { get; set; }

        //1 arst - mitu sünnitust
        public int ObstetricianId { get; set; }
        public Obstetrician Obstetrician { get; set; }
    }
}
