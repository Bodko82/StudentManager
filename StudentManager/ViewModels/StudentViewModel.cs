using StudentManager.Commands;
using StudentManager.Models;
using StudentManager.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace StudentManager.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        private ContextDB _context = new ContextDB();
        private Student _selectedStudent;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ObservableCollection<Student> _students;

        public StudentViewModel()
        {
            LoadStudents();
        }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(x =>
                {
                    _context.Students.Update(SelectedStudent);
                    _context.SaveChanges();

                    LoadStudents();
                }));
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(x =>
                {
                    _context.Students.Remove(SelectedStudent);
                    _context.SaveChanges();

                    LoadStudents();
                }));
            }
        }

        private void LoadStudents()
        {
            Students = new ObservableCollection<Student>(_context.Students.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

