﻿using Dara_Store.Application.Services.Common.Queries.GetSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.HomePages
{
    public class HomePagesViewModel
    {
        public List<SliderDto> Sliders { get; set; }
    }
}
