using StudentManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using StudentManager.Models;
using StudentManager.Interface;
using System.Windows.Media;
using System.Diagnostics;
using System.ComponentModel;
using StudentManager.ValidationRules;

namespace StudentManager.ViewModels
{
    public class AddStudentViewModel : BaseViewModel
    {
        private ISaveStrategy _currentSaveStrategy;
        ContextDB _db;
        public Action<string> StudentAddedAction { get; set; }
        public AddStudentViewModel(HomeViewModel homeViewModel, ContextDB _contextDB)
        {
            _db = _contextDB;
            CloseWindowCommand = new RelayCommand(CloseWindow);
            AddStudentErrorMessage = "Заповніть всі поля";
            DropdownGroups = new BindingList<Group>(_contextDB.Groups.ToList());

            StudentAddedAction = homeViewModel.HandleStudentAdded;
            var saveStrategy = new SaveStudentCommand();
            SaveCommand = new RelayCommand(obj =>
            {
                saveStrategy.Save(this);
                if (obj is Window window)
                {
                    CloseWindowCommand = new RelayCommand(CloseWindow);
                }
            }, obj => saveStrategy.CanSave(this));
            CurrentSaveStrategy = saveStrategy;        }


        public ICommand CloseWindowCommand { get; private set; }
        public ICommand SaveStudentCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        private void CloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
            else
            {
                Debug.WriteLine("Parameter is not a window: " + parameter);
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

        private string _addStudentErrorMessage;
        public string AddStudentErrorMessage
        {
            get { return _addStudentErrorMessage; }
            set
            {
                _addStudentErrorMessage = value;
                OnPropertyChanged();
            }
        }

        private Brush _addStudentErrorMessageColor;
        public Brush AddStudentErrorMessageColor
        {
            get { return _addStudentErrorMessageColor; }
            set
            {
                _addStudentErrorMessageColor = value;
                OnPropertyChanged();
            }
        }

        private BindingList<Group> _dropdownGroups;
        public BindingList<Group> DropdownGroups
        {
            get { return _dropdownGroups; }
            set
            {
                _dropdownGroups = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
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
        private Group _studentDropdownItem;
        public Group StudentDropdownItem
        {
            get { return _studentDropdownItem; }
            set
            {
                _studentDropdownItem = value;
                OnPropertyChanged();
            }
        }
    }
}
