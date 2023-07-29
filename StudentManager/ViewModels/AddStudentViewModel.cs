using StudentManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace StudentManager.ViewModels
{
    public class AddStudentViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; private set; }

        public AddStudentViewModel()
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
