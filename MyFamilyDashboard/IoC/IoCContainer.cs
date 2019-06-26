using Microsoft.Extensions.DependencyInjection;
using MyFamilyDashboard.Data;
using System;

namespace MyFamilyDashboard
{
    public static class IoC
    {
        public static ApplicationDbContext applicationDbContext => IoCContainer.Provider.GetService<ApplicationDbContext>();
    } 
    public static class IoCContainer
    {
        public static ServiceProvider Provider { get; set; }
    }
}
