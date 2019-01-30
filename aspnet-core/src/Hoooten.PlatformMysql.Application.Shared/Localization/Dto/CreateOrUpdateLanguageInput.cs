using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}