using DAL.Models;
using DTO.model;
using System;
using System.Collections.Generic;
using System.Text;


namespace DTO
{
    public class AutoMapperC: AutoMapper.Profile
    {
        public AutoMapperC()
        {
            CreateMap<UserDTO, TblUser>();
            CreateMap<TblUser, UserDTO>();

        }
    }
}
