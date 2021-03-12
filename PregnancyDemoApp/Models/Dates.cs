using System;

namespace PregnancyDemoApp.Models
{
    public class Dates : UniqueEntityData
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
