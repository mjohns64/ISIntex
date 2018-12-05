using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    [Table("UserType")]
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeDesc { get; set; }
    }
}