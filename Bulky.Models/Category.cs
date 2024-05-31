using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Bulky.Models
{
    public class Category
    {
        // Primary Key of the table
        [Key]
        public int Id { get; set; }
        // Name of the category
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100!")]
        public int DisplayOrder { get; set; }


    }
}
