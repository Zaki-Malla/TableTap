using System.ComponentModel.DataAnnotations;

namespace TableTap.Models.HelperModels
{
    public class PaymentMethodViewModel
    {
        [Required]
        public string MethodName { get; set; }

        [Required]
        public string Type { get; set; }

        public bool IsActive { get; set; } = true;
        
        [Required]
        public string Description { get; set; }
    }

}
