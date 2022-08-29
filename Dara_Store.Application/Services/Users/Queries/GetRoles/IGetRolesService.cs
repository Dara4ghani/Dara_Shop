using Dara_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Dara_Store.Application.Services.Users.Queries.NewFolder.GetRolesService;

namespace Dara_Store.Application.Services.Users.Queries.NewFolder
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
