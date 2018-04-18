using System.ComponentModel.DataAnnotations;

namespace CRUD_EASY.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [MaxLength(32)]
        public string Theme { get; set; }
    }
}