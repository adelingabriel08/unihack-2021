using HelpYourCity.Core.Entities;

namespace HelpYourCity.Core.ViewModels
{
    public class GoalViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ImageId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public uint Target { get; set; }
        public uint PricePerUnit { get; set; }
        public string? Slug { get; set; }
        public string GoalItemName { get; set; }
    }
}