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
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel currentChildView;
        public ICommand CloseWindowCommand { get; private set; }
        public ICommand MaximizeWindowCommand { get; private set; }
        public ICommand MinimizeWindowCommand { get; private set; }
        public ICommand ShowHomeViewCommand { get; private set; }
        public ICommand ShowStudentViewCommand { get; private set; }

        public MainWindowViewModel()
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);
            MaximizeWindowCommand = new RelayCommand(MaximizeWindow);
            MinimizeWindowCommand = new RelayCommand(MinimizeWindow);
            ShowHomeViewCommand = new RelayCommand(_ => ShowHomeView());
            ShowStudentViewCommand = new RelayCommand(_ => ShowStudentView());
            ShowHomeView();
        }
        public BaseViewModel CurrentChildView
        {
            get { return currentChildView; }
            set
            {
                currentChildView = value;
                OnPropertyChanged();
            }
        }

        private void CloseWindow(object obj)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeWindow(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            }
        }

        private void MinimizeWindow(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }
        private void ShowHomeView()
        {
            CurrentChildView = new HomeViewModel();
        }

        private void ShowStudentView()
        {
            CurrentChildView = new StudentViewModel();
        }
    }
}
