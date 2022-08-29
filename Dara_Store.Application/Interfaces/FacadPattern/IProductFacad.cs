using Dara_Store.Application.Services.Product.Commands.AddNewCategory;
using Dara_Store.Application.Services.Product.Commands.AddNewProduct;
using Dara_Store.Application.Services.Product.Queries.GetAllCategories;
using Dara_Store.Application.Services.Product.Queries.GetCategories;
using Dara_Store.Application.Services.Product.Queries.GetProductDetailForAdmin;
using Dara_Store.Application.Services.Product.Queries.GetProductDetailForSite;
using Dara_Store.Application.Services.Product.Queries.GetProductForAdmin;
using Dara_Store.Application.Services.Product.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dara_Store.Application.Interfaces.FacadPattern
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProdcutForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
