using System.ComponentModel.DataAnnotations;

namespace TrainSchedule.Models.ViewsModels
{
    public class LoginApiDto
    {
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
