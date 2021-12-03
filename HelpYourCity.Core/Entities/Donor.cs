using System.ComponentModel.DataAnnotations;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class Donor : BaseEntity
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public uint Quantity { get; set; }

        [Required] public string Message { get; set; }

        public bool IsAnnonymous { get; set; }


        [Required] public int GoalId { get; set; }

        public Goal Goal { get; set; }


        [Required] public int PaymentId { get; set; }

        public Payment Payment { get; set; }
    }
}