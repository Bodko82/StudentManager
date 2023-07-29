using StudentManager.ViewModels;
using System;
using System.Windows.Input;

namespace StudentManager.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        public bool CanExecute(object parameter)
        {
            var canExecute = _canExecute == null || _canExecute(parameter);
            if (parameter is HomeViewModel homeViewModel)
            {
                System.Diagnostics.Debug.WriteLine(homeViewModel.ErrorMessage);
            }
            return canExecute;
        }

        public void Execute(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                System.Diagnostics.Debug.WriteLine(homeViewModel.ErrorMessage);
            }
            _execute(parameter);
        }

    }
}
