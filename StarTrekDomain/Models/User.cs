using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage="First Name is required")]
        [MaxLength(ErrorMessage="First Name cannot be longer than 30 characters")]
        public string FirstName { get; set; }

        [MaxLength(ErrorMessage = "Last Name cannot be longer than 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="User Id is required")]
        [MaxLength(ErrorMessage = "User Id cannot be longer than 20 characters")]
        public string UserId { get; set; }

        [MaxLength(ErrorMessage = "Password cannot be longer than 30 characters")]
        public string Password { get; set; }

        
        public int Error { get; set; }
    }
}
