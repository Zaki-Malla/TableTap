using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTap.Models
{
    public class PaymentRequestModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime SubmittedDate { get; set; }

        public string Status { get; set; } 

        public int EstablishmentId { get; set; }
        [ForeignKey("EstablishmentId")]
        public virtual EstablishmentModel Establishment { get; set; }

        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethodModel PaymentMethod { get; set; }
    }

}
