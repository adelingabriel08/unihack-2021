namespace HelpYourCity.Core.ViewModels
{
    public class ProposalViewModel
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CompanyName { get; set; }

        public GoalViewModel Goal { get; set; }
    }
}