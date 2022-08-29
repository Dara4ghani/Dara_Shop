using Dara_Store.Application.Interfaces.Contexts;
using Dara_Store.Common;
using System.Collections.Generic;
using System.Linq;

namespace Dara_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }  
        public ResultGetUserDto Execute(RequsetGetUserDto requset)
        {
            var users = _context.Users.AsQueryable();
            if(!string.IsNullOrWhiteSpace(requset.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(requset.SearchKey) && p.Email.Contains(requset.SearchKey));
            }

            int rowsCount = 0;
            var usersList = users.ToPaged(requset.page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = usersList
            };


        }
    }
}
