using AutoMapper;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.UsersViewModels;

namespace BLL.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            AllowNullDestinationValues = true;
            CreateMap<TblUser, UsersListDTO>();
        }
    }
}
