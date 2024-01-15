using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;
        public App()
        {
            // Config for dependencyInjection (DI)
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        // ----- 
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddSingleton<LoginWindow>();
        }

        // -----
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var window = serviceProvider.GetService<LoginWindow>();
            window.Show();
        }
    }
}
