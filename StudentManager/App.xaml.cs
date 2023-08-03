using Microsoft.Extensions.DependencyInjection;
using StudentManager.Models;
using StudentManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManager
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ContextDB>();
            services.AddScoped<HomeViewModel>();
            services.AddScoped<StudentViewModel>();
            services.AddScoped<AddStudentViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<MainWindow>();
        }
        public ContextDB GetContextDB()
        {
            return serviceProvider.GetRequiredService<ContextDB>();
        }
    }
}
