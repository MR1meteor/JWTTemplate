using JWTTemplate.Models.Dtos;
using JWTTemplate.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTTemplate.Services.Mappers
{
    public static class UserMapper
    {
        public static User MapToDomain(this UserDto user)
        {
            return new User
            {
                Login = user.Login,
                Password = user.Password
            };
        }
    }
}
