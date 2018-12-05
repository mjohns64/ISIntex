using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{

    [Table("UserCredentials")]
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserTypeID { get; set; }
    }
}