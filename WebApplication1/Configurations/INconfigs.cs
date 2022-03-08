
using BLL.UsersBLL;
using DAL.Contract;
using DAL.Contracts;
using DAL.Dapper;
using DAL.Repositories;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Configurations
{
    public static class INconfigs
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            #region Repository
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IDapper, Dapperr>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region BLL
            services.AddScoped<IUsersService, UsersService>();
            #endregion

            return services;
        }
        public static IServiceCollection AddINConfig(this IServiceCollection services)
        {
            return Configure(services);
        }
    }
}
