using System.ComponentModel.DataAnnotations;

namespace Client.Models.Team
{
    public class AddTeamModel
    {
        public string Id => Guid.NewGuid().ToString();  

        [Required]
        [StringLength(20, ErrorMessage = "Length exceeds 20 characters")]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; } = 2023;

    }
}
