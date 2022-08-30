﻿using Dara_Store.Application.Interfaces.Contexts;
using Dara_Store.Common.Dto;
using Dara_Store.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dara_Store.Application.Services.Common.Queries.GetHomePageImages
{
    public interface IGetHomePageImagesService
    {
        ResultDto<List<HomePageImagesDto>> Execute();
    }

    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImagesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImagesDto>> Execute()
        {
            var images = _context.HomePageImages.OrderByDescending(p => p.Id)
                .Select(p => new HomePageImagesDto
                {
                    Id = p.Id,
                    ImageLocation = p.ImageLocation,
                    Link = p.Link,
                    Src = p.Src,
                }).ToList();
            return new ResultDto<List<HomePageImagesDto>>()
            {
                Data = images,
                IsSuccess = true,
            };
        }
    }

    public class HomePageImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
