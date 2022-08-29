using Dara_Store.Application.Interfaces.Contexts;
using Dara_Store.Application.Interfaces.FacadPattern;
using Dara_Store.Application.Services.Product.Commands.AddNewCategory;
using Dara_Store.Application.Services.Product.Commands.AddNewProduct;
using Dara_Store.Application.Services.Product.Queries.GetAllCategories;
using Dara_Store.Application.Services.Product.Queries.GetCategories;
using Dara_Store.Application.Services.Product.Queries.GetProductDetailForAdmin;
using Dara_Store.Application.Services.Product.Queries.GetProductDetailForSite;
using Dara_Store.Application.Services.Product.Queries.GetProductForAdmin;
using Dara_Store.Application.Services.Product.Queries.GetProductForSite;
using Microsoft.AspNetCore.Hosting;

namespace Dara_Store.Application.Services.Product.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }


        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }

        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }

        }

        private AddNewProductService _addNewProductService;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_context, _environment);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }
       

        private IGetProdcutForSiteService _getProdcutForSiteService;
        public IGetProdcutForSiteService GetProductForSiteService
        {
            get
            {
                return _getProdcutForSiteService = _getProdcutForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }


        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }      
    }
}
