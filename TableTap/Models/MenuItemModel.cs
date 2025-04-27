using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTap.Models
{
    public class MenuItemModel
    {
        [Key]
        public int MenuItemId { get; set; }
        public string Name { get; set; }          
        public string Description { get; set; }   
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryModel Category { get; set; }
    }
}
