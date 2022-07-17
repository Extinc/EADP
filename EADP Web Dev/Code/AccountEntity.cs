using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Web_Dev.Code
{
    public class AccountEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public string FamilyMobile { get; set; }
        public string Nric { get; set; }
        public int Roleid { get; set; }
        public int Userid { get; set; }
        public byte[] Salt { get; set; }
        public List<string> Interest { get; set; }
        public bool Online { get; set; } 
    } 
}