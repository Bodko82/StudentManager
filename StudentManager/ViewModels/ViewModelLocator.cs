using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return _serviceProvider.GetRequiredService<MainWindowViewModel>();
            }
        }
        public HomeViewModel HomeViewModel
        {
            get
            {
                return _serviceProvider.GetRequiredService<HomeViewModel>();
            }
        }
        public StudentViewModel StudentViewModel
        {
            get
            {
                return _serviceProvider.GetRequiredService<StudentViewModel>();
            }
        }
    }

}
