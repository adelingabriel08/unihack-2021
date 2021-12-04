using System.ComponentModel.DataAnnotations;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class Payment : BaseEntity
    {
        public bool IsSuccesful { get; set; }
        [Required] public uint Amount { get; set; }
        [Required] public string Email { get; set; }
    }
}