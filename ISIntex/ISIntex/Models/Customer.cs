using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("Customer")]
    public class Customer
    {
        
        [Required(ErrorMessage = "This is Required")]
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [DisplayName("Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "This is not a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "This is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "This is Required")]
        public string State { get; set; }

        [Required(ErrorMessage = "This is Required")]
        public string Zip { get; set; }

        public int? SalesRepID { get; set; }
        public string PaymentInfo { get; set; }
    }
}