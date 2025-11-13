using System.ComponentModel.DataAnnotations;

namespace TrainSchedule.Models
{
    public class Platform
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вкажіть номер платформи")]
        [Range(1, 100, ErrorMessage = "Номер платформи має бути від 1 до 100")]
        public int PlatformNumber { get; set; }

        [Required(ErrorMessage = "Вкажіть назву станції")]
        [StringLength(100, ErrorMessage = "Назва станції не може перевищувати 100 символів")]
        public required string StationName { get; set; }

        public ICollection<Trains>? Trains { get; set; }
    }
}
