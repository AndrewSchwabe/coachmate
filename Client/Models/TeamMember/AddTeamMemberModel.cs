using System.ComponentModel.DataAnnotations;

namespace Client.Models.TeamMember
{
    public class AddTeamMemberModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Length exceeds 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Length exceeds 20 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

    }
}
