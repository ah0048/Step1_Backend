using System.ComponentModel.DataAnnotations.Schema;

namespace Step1_Backend.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public virtual Trainer Trainer { get; set; }
        [ForeignKey(nameof(Trainer))]
        public int TrainerId { get; set; }
    }
}
