using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainSchedule.Models
{
    public class Trains
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вкажіть назву поїзда")]
        [StringLength(50)]
        public required string TrainName { get; set; }

        [Required(ErrorMessage = "Вкажіть номер поїзда")]
        [StringLength(10)]
        public required string TrainNumber { get; set; }

        [Required(ErrorMessage = "Оберіть тип поїзда")]
        public required string TrainType { get; set; }

        [Required(ErrorMessage = "Оберіть платформу")]
        public int PlatformId { get; set; }

        [ForeignKey("PlatformId")]
        public Platform? Platform { get; set; }

    }
}
