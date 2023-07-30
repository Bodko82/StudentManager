using Microsoft.EntityFrameworkCore;
using StudentManager.Commands;
using StudentManager.Interface;
using StudentManager.Models;
using StudentManager.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace StudentManager.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ContextDB contextDB;
        private bool _isTextBoxVisible = false;
        private bool _isCourseVisible = false;
        private ISaveStrategy _currentSaveStrategy;

        public HomeViewModel(ContextDB _contextDB)
        {
            this.contextDB = _contextDB;
            IsTextBoxVisible = false;
            IsDropdownGroupVisible = false;
            IsCourseVisible = false;
            IsDropdownVisible = false;
            ShowAddDepartmentTypeCommand = new RelayCommand(_ =>
            {
                IsTextBoxVisible = true;
                IsCourseVisible = false;
                IsDropdownGroupVisible = false;
                IsDropdownVisible = false;
                ErrorMessage = "Введіть назву типу відділу";
                CurrentSaveStrategy = new SaveDepartmentTypeViewModel();
            });
            ShowAddDepartmentCommand = new RelayCommand(_ =>
            {
                DropdownItems = new BindingList<DepartmentType>(contextDB.DepartmentTypes.ToList());
                IsTextBoxVisible = false;
                IsCourseVisible = false;
                IsDropdownVisible = false;
                IsDropdownGroupVisible = false;
                if (!DropdownItems.Any())
                {
                    ErrorMessage = "Немає жодного типу відділу. Спочатку додайте тип відділу.";
                    return; 
                }
                IsTextBoxVisible = true;
                IsCourseVisible = false;
                IsDropdownGroupVisible = false;
                IsDropdownVisible = true;
                InputLabel = "Тип відділу:";
                ErrorMessage = "Введіть назву відділу та виберіть тип";
                CurrentSaveStrategy = new SaveDepartmentViewModel();
            });
            ShowAddSpecialityCommand = new RelayCommand(_ =>
            {
                IsTextBoxVisible = true;
                IsCourseVisible = false;
                IsDropdownGroupVisible = false;
                IsDropdownVisible = false;
                ErrorMessage = "Введіть назву спеціальності";
                CurrentSaveStrategy = new SaveSpecialityViewModel();
            });
            ShowAddGroupCommand = new RelayCommand(_ =>
            {
                DropdownSpecialities = new BindingList<Speciality>(contextDB.Specialities.ToList());
                IsTextBoxVisible = false;
                IsCourseVisible = false;
                IsDropdownVisible = false;
                IsDropdownGroupVisible = false;
                if (!DropdownSpecialities.Any())
                {
                    ErrorMessage = "Немає жодної спеціальності. Спочатку додайте спеціальність.";
                    return;
                }
                IsTextBoxVisible = true;
                IsCourseVisible = true;
                IsDropdownVisible = false;
                IsDropdownGroupVisible = true;
                InputLabel = "Спеціальність:";
                ErrorMessage = "Введіть групи, курс та виберіть спеціальність";
                CurrentSaveStrategy = new SaveGropViewModel();
            });

            SaveCommand = new RelayCommand(param =>
            {
                CurrentSaveStrategy?.Save(param);
                IsTextBoxVisible = false; IsCourseVisible = false; IsDropdownGroupVisible = false; IsDropdownVisible = false;
                InputData = null; InputDataGroup = null;
            }, param => CurrentSaveStrategy == null || (CurrentSaveStrategy?.CanSave(param) ?? false));
            AddStudentCommand = new RelayCommand(OpenAddStudentView);
            AddEmployeeCommand = new RelayCommand(OpenAddEmployeeView);
        }
        
        public ICommand ShowAddDepartmentCommand { get; private set; }
        public ICommand ShowAddDepartmentTypeCommand { get; private set; }
        public ICommand ShowAddSpecialityCommand { get; private set; }
        public ICommand ShowAddGroupCommand { get; private set; }
        public ICommand AddStudentCommand { get; private set; }
        public ICommand AddEmployeeCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

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
        public bool IsTextBoxVisible
        {
            get { return _isTextBoxVisible; }
            set
            {
                _isTextBoxVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsCourseVisible
        {
            get { return _isCourseVisible; }
            set
            {
                _isCourseVisible = value;
                OnPropertyChanged();
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
        public string InputData
        {
            get { return _inputData; }
            set
            {
                _inputData = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private string _inputData;
        private string _inputDataGroup;
        public string InputDataGroup
        {
            get { return _inputDataGroup; }
            set
            {
                _inputDataGroup = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        

        private Brush errorMessageColor;

        public Brush ErrorMessageColor
        {
            get { return errorMessageColor; }
            set
            {
                errorMessageColor = value;
                OnPropertyChanged();
            }
        }
        private DepartmentType selectedDropdownItem;

        public DepartmentType SelectedDropdownItem
        {
            get { return selectedDropdownItem; }
            set
            {
                selectedDropdownItem = value;
                OnPropertyChanged();
                if (SaveCommand is RelayCommand relayCommand)
                {
                    relayCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool isDropdownVisible;
        public bool IsDropdownVisible
        {
            get { return isDropdownVisible; }
            set
            {
                isDropdownVisible = value;
                OnPropertyChanged();
            }
        }
        private bool isDropdownGroupVisible;
        public bool IsDropdownGroupVisible
        {
            get { return isDropdownGroupVisible; }
            set
            {
                isDropdownGroupVisible = value;
                OnPropertyChanged();
            }
        }

        private string _inputLabel;
        public string InputLabel
        {
            get { return _inputLabel; }
            set
            {
                _inputLabel = value;
                OnPropertyChanged();
            }
        }


        private IEnumerable<DepartmentType> dropdownItems;
        public IEnumerable<DepartmentType> DropdownItems
        {
            get { return dropdownItems; }
            set
            {
                dropdownItems = value;
                OnPropertyChanged();
            }
        }
        private BindingList<Speciality> dropdownSpecialities;
        public BindingList<Speciality> DropdownSpecialities
        {
            get { return dropdownSpecialities; }
            set
            {
                dropdownSpecialities = value;
                OnPropertyChanged();
            }
        }
        private void OpenAddStudentView(object obj)
        {
            AddStudentView addStudentView = new AddStudentView();
            addStudentView.ShowDialog();
        }
        private void OpenAddEmployeeView(object obj)
        {
            AddEmployeeView addEmployeeView = new AddEmployeeView();
            addEmployeeView.ShowDialog();
        }

    }
}
