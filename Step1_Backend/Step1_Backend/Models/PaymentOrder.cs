using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Step1_Backend.Models
{
    public class PaymentOrder
    {
        public int Id { get; set; }
        [Required]
        public string ParentName { get; set; }
        [Required]
        public string ChildName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public PaymentStatus OrderStatus { get; set; }
        [Required]
        [ForeignKey(nameof(Package))]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
    public enum PaymentStatus
    {
        Pending = 0,
        Processing = 1,
        Paid = 2
    }
}
