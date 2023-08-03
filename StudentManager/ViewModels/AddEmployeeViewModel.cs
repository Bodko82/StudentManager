using StudentManager.Commands;
using StudentManager.Interface;
using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace StudentManager.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; private set; }
        private ISaveStrategy _currentSaveStrategy;
        ContextDB _db;
        public Action<string> EmployeeAddedAction { get; set; }
        public AddEmployeeViewModel(HomeViewModel homeViewModel, ContextDB _contextDB)
        {
            _db = _contextDB;
            CloseWindowCommand = new RelayCommand(CloseWindow);
            ErrorMessage = "Заповніть всі поля";

            EmployeeAddedAction = homeViewModel.HandleStudentAdded;
            var saveStrategy = new SaveEmployeeCommand();
            SaveCommand = new RelayCommand(obj =>
            {
                saveStrategy.Save(this);
                if (obj is Window window)
                {
                    CloseWindowCommand = new RelayCommand(CloseWindow);
                }
            }, obj => saveStrategy.CanSave(this));
            CurrentSaveStrategy = saveStrategy;
        }
        public ICommand SaveStudentCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }


        private void CloseWindow(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.Close();
            }
        }
        public ISaveStrategy CurrentSaveStrategy
        {
            get { return _currentSaveStrategy; }
            set
            {
                _currentSaveStrategy = value;
                OnPropertyChanged("CurrentSaveStrategy");
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private Brush _errorMessageColor;
        public Brush ErrorMessageColor
        {
            get { return _errorMessageColor; }
            set
            {
                _errorMessageColor = value;
                OnPropertyChanged();
            }
        }

        private string _inputDataName;
        public string InputDataName
        {
            get { return _inputDataName; }
            set
            {
                _inputDataName = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _inputDataLastName;
        public string InputDataLastName
        {
            get { return _inputDataLastName; }
            set
            {
                _inputDataLastName = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _inputDataSecondName;
        public string InputDataSecondName
        {
            get { return _inputDataSecondName; }
            set
            {
                _inputDataSecondName = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _inputDataPhone;
        public string InputDataPhone
        {
            get { return _inputDataPhone; }
            set
            {
                _inputDataPhone = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _inputDataEmail;
        public string InputDataEmail
        {
            get { return _inputDataEmail; }
            set
            {
                _inputDataEmail = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private string _inputDataPosition;
        public string InputDataPosition
        {
            get { return _inputDataPosition; }
            set
            {
                _inputDataPosition = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private int _inputDataExperience;
        public int InputDataExperience
        {
            get { return _inputDataExperience; }
            set
            {
                _inputDataExperience = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private decimal _inputDataSalary;
        public decimal InputDataSalary
        {
            get { return _inputDataSalary; }
            set
            {
                _inputDataSalary = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private DateTime _hireDate;
        public DateTime HireDate
        {
            get { return _hireDate; }
            set
            {
                _hireDate = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
    }
}
