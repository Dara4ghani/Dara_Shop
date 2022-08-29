using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dara_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequsetGetUserDto requset);
    }
}
