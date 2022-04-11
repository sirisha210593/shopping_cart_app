using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPPINGCARTPROJECT.Models
{
    public class SignUp
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string RoleId { get; set; }
        public string Gender { get; set; }  
        public string Password { get; set; }
    }
}