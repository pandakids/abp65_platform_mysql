using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
