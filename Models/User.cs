using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Lost_and_Found.Models
{
    public partial class User
    {
        public User()
        {
            Founditems = new HashSet<Founditem>();
            Lostitems = new HashSet<Lostitem>();
            UserClaims = new HashSet<UserClaim>();
        }


        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^(013|014|015|016|017|018|019)\d{8}$", ErrorMessage = "Enter a valid mobile number with 11 digits.")]
        public string Contact { get; set; }

        public virtual ICollection<Founditem> Founditems { get; set; }
        public virtual ICollection<Lostitem> Lostitems { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}
