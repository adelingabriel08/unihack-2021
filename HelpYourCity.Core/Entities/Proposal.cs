using System.ComponentModel.DataAnnotations;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class Proposal : BaseEntity
    {
        [Required] public string Email { get; set; }

        [Required] public string Phone { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        
        public string? CompanyName { get; set; }

        public Goal Goal { get; set; }

        [Required] public int GoalId { get; set; }
    }
}