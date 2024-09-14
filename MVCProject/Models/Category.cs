using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; } //as primary key

        
        [Required]
        [StringLength(50, ErrorMessage = "Category name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        

        [Required]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]

        public string Description { get; set; }
        
        public HashSet<Product>? products { get; set; }  //one to many relation
    }
}
