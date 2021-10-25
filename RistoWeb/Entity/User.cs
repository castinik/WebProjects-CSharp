using System;

namespace RistoWeb.Entity
{
    public class User
    {
        //[Key]
        public Guid UserID { get; set; }
        public bool UserIn { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RistoPoints { get; set; }
    }
}
