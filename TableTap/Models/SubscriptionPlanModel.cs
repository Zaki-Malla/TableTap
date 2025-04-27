using System.ComponentModel.DataAnnotations;

namespace TableTap.Models
{
    public class SubscriptionPlanModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public int ThemeCount { get; set; }
        public virtual List<SubscriptionModel> Subscriptions { get; set; }
    }
}
