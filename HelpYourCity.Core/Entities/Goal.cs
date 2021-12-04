using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class Goal : BaseEntity
    {
        [Required] public string Title { get; set; }

        public UploadedFile Image { get; set; }

        [Required] public int ImageId { get; set; }
        [Required] public string ShortDescription { get; set; }
        [Required] public string Description { get; set; }
        [Required] public uint Target { get; set; }
        [Required] public uint PricePerUnit { get; set; }
        [Required] public string Slug { get; set; }
        [Required] public string GoalItemName { get; set; }
        public string? StripePriceCorrelationId { get; set; }
        
        [NotMapped]
        public long? NumberOfDonations {get;set;}

        public bool IsPublished { get; set; } = false;

        public Proposal Proposals { get; set; }

        public ICollection<Donor> Donors { get; set; }

        public ICollection<VolunteeringEvent> VolunteeringEvents { get; set; }
    }
}