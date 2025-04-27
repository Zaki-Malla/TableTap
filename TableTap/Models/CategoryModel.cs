using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTap.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }          
        public int MenuId { get; set; }
        [ForeignKey("MenuItemId")]
        public MenuModel Menu { get; set; }
        public virtual List<MenuItemModel> MenuItems { get; set; }
    }
}
