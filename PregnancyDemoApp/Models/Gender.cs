using System.ComponentModel.DataAnnotations;

namespace PregnancyDemoApp.Models
{
    public class Gender : Name
    {
        [Required]
        public string Sex { get; set; }
    }
}
