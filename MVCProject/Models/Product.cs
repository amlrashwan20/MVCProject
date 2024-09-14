using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Product
    {
        public int ProductId { get; set; } //as primary key
        
        [Required]
        [StringLength(50, ErrorMessage = "Product name cannot be longer than 50 characters.")]
        public string Title { get; set; }
        
        [Required]
        [Range(0, 3000, ErrorMessage = "Price must be between 0 and 3000.")]
        public decimal Price { get; set; }
        
        [Required]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }
        
        [Required]
     
        [StringLength(20, ErrorMessage = "Product code cannot be longer than 20 characters.")]
        public string Code { get; set; }
        
        [Required]
        [Range(0, 100, ErrorMessage = "Quantity must be between 0 and 100.")]
        public int Quantity { get; set; }
        
        [Required]
        [StringLength(200, ErrorMessage = "Image path cannot be longer than 200 characters.")]
        
        public string PathImage { get; set; }

        [DisplayName ("Category")]
        public int CategoryId { get; set; } //as forign key
        
        public virtual Category? Category { get; set; }   //one to many relation
    }
}


