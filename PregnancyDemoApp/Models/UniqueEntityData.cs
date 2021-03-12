using System.ComponentModel.DataAnnotations.Schema;

namespace PregnancyDemoApp.Models
{
    public class UniqueEntityData
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
