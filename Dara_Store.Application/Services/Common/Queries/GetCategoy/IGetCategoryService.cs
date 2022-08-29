using Dara_Store.Application.Interfaces.Contexts;
using Dara_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dara_Store.Application.Services.Common.Queries.GetCategoy
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoryDto>> Execute();
    }

    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _Context;
        public GetCategoryService(IDataBaseContext Context)
        {
            _Context = Context;
        }
        public ResultDto<List<CategoryDto>> Execute()
        {
            var category = _Context.Categories.Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new CategoryDto
                {
                    CatId = p.Id,
                    CategoryName = p.Name
                }).ToList();

            return new ResultDto<List<CategoryDto>>()
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }

    public class CategoryDto
    {
        public long CatId { get; set; }
        public string CategoryName { get; set; }
    }
}
