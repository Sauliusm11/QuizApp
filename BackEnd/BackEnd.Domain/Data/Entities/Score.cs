using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.Entities
{
    public class Score
    {
        public required int Id { get; set; }
        public required DateTime DateTime { get; set; }
        public required int Points {get; set; }
        [Required]
        public required string Email { get; set; }

    }
}
