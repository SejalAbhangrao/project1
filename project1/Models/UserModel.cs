using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int IsDeleted { get; set; }
        public string Password { get; set; }
       
    }
}