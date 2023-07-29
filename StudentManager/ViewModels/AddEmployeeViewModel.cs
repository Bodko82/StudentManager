using StudentManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManager.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; private set; }

        public AddEmployeeViewModel()
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }

        private void CloseWindow(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
