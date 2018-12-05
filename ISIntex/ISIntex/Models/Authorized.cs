using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISIntex.Models
{
    public static class Authorized
    {
        [Key]
        public static string userAuth = null;
        public static bool loginStatus = false;
    }
}