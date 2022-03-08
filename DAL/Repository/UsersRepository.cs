using DAL.Contract;
using DAL.Dapper;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDapper _dapper;
        public UsersRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<TblUser>> GetUsersListRepo()
        {
            var result = await Task.FromResult(_dapper.GetAll<TblUser>($"select * from TBL_Users", null, commandType: CommandType.Text));
            return result;
        }

        public async Task<TblUser> Login(string Username)
        {
            var result = await Task.FromResult(_dapper.Get<TblUser>($"Select * from TBL_Users where Username = {Username}", null, commandType: CommandType.Text));
            return result;

        }
    }
}
