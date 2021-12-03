using System;
using System.ComponentModel.DataAnnotations;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class VolunteeringEvent : BaseEntity
    {
        [Required] public DateTime StartTime { get; set; }
        [Required] public DateTime EndTime { get; set; }
        [Required] public string Location { get; set; }
        [Required] public string Details { get; set; }
        public string Skills { get; set; }
        [Required] public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}