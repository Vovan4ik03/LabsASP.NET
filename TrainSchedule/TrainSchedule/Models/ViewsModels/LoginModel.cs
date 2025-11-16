using System.ComponentModel.DataAnnotations;

namespace TrainSchedule.Models.ViewsModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        public string? ReturnUrl { get; set; }
    }
}
