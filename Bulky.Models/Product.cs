using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models
{
    //this class is used to store the product details. the products will be tech gadgets and accessories
    public class Product
    {
        [Key]
        public int Id { get; set; }
        // Name of the category
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        public string SKU { get; set; } //stock keeping unit which is a unique identifier for each product
        [Required]
        public string Brand { get; set; } //this will stzore the brand or manufacturer of the product (e.g. Apple, Samsung, etc)

        [Required]
        [Display(Name = "List Price")]
        [Range(1, 3500)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 3500)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Price for 50-100")]
        [Range(1, 3500)]
        public double Price50 { get; set; }
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 3500)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; } 
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
