using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class TblUser
    {
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
