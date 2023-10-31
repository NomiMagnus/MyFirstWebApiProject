using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [StringLength(20,ErrorMessage = "First name length can't be less than 2 lettersor more than 20.", MinimumLength = 2)]
        public string fName { get; set; }


        [StringLength(20, ErrorMessage = "Last name length can't be less than 2 letters or more than 20.", MinimumLength =2)]
        public string lName { get; set; }


        [EmailAddress]
        [Required]
        public string email { get; set; }


        [StringLength(15, ErrorMessage = "Password length can't be less than 8 chars or more than 15.", MinimumLength = 8)]
        [Required]
        public string password { get; set; }
     
        public int userId { get; set; }

    }
}
