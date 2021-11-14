using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSearchApp.DataManager.Concreate;

namespace TheSearchApp.Helper
{
    internal static class DIInitialize
    {
        internal static void ObjectInitialize(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        internal static void IdentityInitialize(IServiceCollection services)
        {
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });
        }
    }
}
