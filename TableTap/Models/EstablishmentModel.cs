using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTap.Models
{
    public class EstablishmentModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual CityModel City { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public virtual List<SubscriptionModel> Subscriptions { get; set; }

    }
}
