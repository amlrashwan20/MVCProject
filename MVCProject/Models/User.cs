using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        //***********************************************************************************************************

        [StringLength(20, MinimumLength = 3, ErrorMessage = "FristName must be between 3 and 10 char")]
        [Required(ErrorMessage = "The  FirstName of User is required.")]
        [DisplayName("User FirstName")]
        public string FirstName { get; set; }

        //***********************************************************************************************************

        [StringLength(20, MinimumLength = 3, ErrorMessage = "LastName must be between 3 and 10 char")]
        [Required(ErrorMessage = "The LastName of User is required.")]
        [DisplayName("User LastName")]

        public string LastName { get; set; }

        //***********************************************************************************************************

        [Required(ErrorMessage = "The User Email is required.")]
        [EmailAddress]
        [DisplayName("User Email")]

        public string Email { get; set; }

        //************************************************************************************************************

        [Required]
        [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)[A-Za-z\d]{6,}$",
       ErrorMessage = "Password must be at least 6 characters long and contain only letters and digits.")]
        public string Password { get; set; }
    }
}
