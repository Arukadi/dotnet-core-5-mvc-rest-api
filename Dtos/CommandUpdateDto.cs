using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }
        
        [Required]
        [MaxLength(55)]
        public string Platform { get; set; }
    }
}