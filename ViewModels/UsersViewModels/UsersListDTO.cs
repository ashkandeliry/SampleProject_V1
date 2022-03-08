using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UsersViewModels
{
    public class UsersListDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
    }
    public class UserTokenCls
    {
        public string Token { get; set; }
    }
    public class UsersLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
