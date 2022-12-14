using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dara_Store.Persistence.Contexts;
using Dara_Store.Application.Interfaces.Contexts;
using Dara_Store.Application.Services.Users.Queries.GetUsers;
using Dara_Store.Application.Services.Users.Queries.NewFolder;
using Dara_Store.Application.Services.Users.Command.RegisterUser;
using Dara_Store.Application.Services.Users.Command.RemoveUser;
using Dara_Store.Application.Services.Users.Command.EditUser.UserLogin;
using Dara_Store.Application.Interfaces.FacadPattern;
using Dara_Store.Application.Services.Users.Command.EditUser;
using Dara_Store.Application.Services.Users.Command.UserStatusChange;
using Dara_Store.Application.Services.Common.Queries.GetMenuItem;
using Dara_Store.Application.Services.Common.Queries.GetCategoy;
using Dara_Store.Application.Services.HomePages.AddNewSlider;
using Dara_Store.Application.Services.Common.Queries.GetSlider;
using Dara_Store.Application.Services.Product.FacadPattern;
using Dara_Store.Application.Services.HomePages.AddHomePageImages;
using Dara_Store.Application.Services.Common.Queries.GetHomePageImages;

namespace EndPoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
            services.AddScoped<IEditUserService, EditUserService>();

            //FacadInject
            services.AddScoped<IProductFacad, ProductFacad>();


            //---------------
            services.AddScoped<IGetMenuItemService, GetMenuItemsService>();
            services.AddScoped<IGetCategoryService, GetCategoryService>();
            services.AddScoped<IAddNewSliderService, AddNewSliderService>();
            services.AddScoped<IGetSliderService, GetSliderService>();
            services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
            services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();

            string ConnectionString = @"data Source=.\sql2019;  uid=sa;  password=123456;  Initial Catalog=Dara_StoreDb;  Integrated Security=False;  Persist Security Info=True";
            services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(ConnectionString));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                     name: "areas",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                 );
            });
        }
    }
}
