using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.UsersViewModels;

namespace BLL.UsersBLL
{
    public interface IUsersService
    {
        Task<string> Login(string Username, string Password, CancellationToken cancellationToken);
        Task<List<UsersListDTO>> GetUsersList();
    }
}
