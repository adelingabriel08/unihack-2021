using System.ComponentModel.DataAnnotations;

namespace HelpYourCity.Core.ViewModels
{
    public class PaymentRequestViewModel
    {
        [Required] public string Email { get; set; }
        [Required] public uint Quantity { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        public string Message { get; set; }
        public bool IsAnnonymous { get; set; }

        [Required] public int GoalId { get; set; }
    }
}