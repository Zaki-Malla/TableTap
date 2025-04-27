using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTap.Models
{
    public class MenuModel
    {
        [Key]
        public int MenuId { get; set; }
        public string Title { get; set; }      
        public int EstablishmentId { get; set; }
        [ForeignKey("Id")]
        public virtual EstablishmentModel Establishment { get; set; }
        public virtual List<CategoryModel> Categories { get; set; }
    }
}
