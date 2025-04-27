using System.ComponentModel.DataAnnotations.Schema;

namespace TableTap.Models
{
    public class SubscriptionModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public EstablishmentModel Establishment { get; set; }
        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public SubscriptionPlanModel Plan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
