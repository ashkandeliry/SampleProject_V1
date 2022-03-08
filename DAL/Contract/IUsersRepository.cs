using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contract
{
    public interface IUsersRepository
    {
        Task<TblUser> Login(string Username);
        Task<List<TblUser>> GetUsersListRepo();
    }
}
