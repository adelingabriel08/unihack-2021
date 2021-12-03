using System.ComponentModel.DataAnnotations;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class Volunteer : BaseEntity
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Phone { get; set; }

        [Required] public int EventId { get; set; }

        public VolunteeringEvent Event { get; set; }
        [Required] public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}