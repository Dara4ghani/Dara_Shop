﻿using Dara_Store.Application.Interfaces.Contexts;
using Dara_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dara_Store.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }

    public class GetMenuItemsService : IGetMenuItemService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<MenuItemDto>> Execute()
        {
            var category = _context.Categories
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Child = p.SubCategories.ToList().Select(child => new MenuItemDto
                    {
                        CatId = child.Id,
                        Name = child.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<MenuItemDto>>
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }

    public class MenuItemDto
    {
        public long CatId { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Child { get; set; }
    }
}