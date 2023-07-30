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
        private HomeViewModel homeViewModel;
        private StudentViewModel studentViewModel;
        public ICommand CloseWindowCommand { get; private set; }
        public ICommand MaximizeWindowCommand { get; private set; }
        public ICommand MinimizeWindowCommand { get; private set; }
        public ICommand ShowHomeViewCommand { get; private set; }
        public ICommand ShowStudentViewCommand { get; private set; }

        public MainWindowViewModel(HomeViewModel homeViewModel, StudentViewModel studentViewModel)
        {
            this.homeViewModel = homeViewModel;
            this.studentViewModel = studentViewModel;

            CloseWindowCommand = new RelayCommand(CloseWindow);
            MaximizeWindowCommand = new RelayCommand(MaximizeWindow);
            MinimizeWindowCommand = new RelayCommand(MinimizeWindow);
            ShowHomeViewCommand = new RelayCommand(_ => CurrentChildView = homeViewModel);
            ShowStudentViewCommand = new RelayCommand(_ => CurrentChildView = studentViewModel);

            ShowHomeView();
        }
        public BaseViewModel CurrentChildView
        {
            get { return currentChildView; }
            private set
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
            CurrentChildView = homeViewModel;
        }

        private void ShowStudentView()
        {
            CurrentChildView = studentViewModel;
        }
    }
}
