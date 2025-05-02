using System.ComponentModel.DataAnnotations;

namespace TableTap.Models
{
    public class PaymentMethodModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        public virtual List<PaymentRequestModel> PaymentRequests { get; set; }
    }

}
