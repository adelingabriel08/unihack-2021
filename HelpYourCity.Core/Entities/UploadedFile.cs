using System.ComponentModel.DataAnnotations;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Entities
{
    public class UploadedFile : BaseEntity
    {
        [Required] public string Name { get; set; }

        [Required] public string Extension { get; set; }

        [Required] public string OrginalName { get; set; }
    }
}