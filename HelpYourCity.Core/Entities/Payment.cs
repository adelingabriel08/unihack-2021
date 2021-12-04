using System.ComponentModel.DataAnnotations;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class Payment : BaseEntity
    {
        public string Email { get; set; }
        public string EventId { get; set; }
        public string FullName { get; set; }
        public string RequestId { get; set; }
        
    }
}