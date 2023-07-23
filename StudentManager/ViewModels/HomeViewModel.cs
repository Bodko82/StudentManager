using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private string _welcomeText;

        public HomeViewModel()
        {
            WelcomeText = "Welcome to the Student Management System!";
        }

        public string WelcomeText
        {
            get { return _welcomeText; }
            set
            {
                if (_welcomeText != value)
                {
                    _welcomeText = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
