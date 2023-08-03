using StudentManager.Interface;
using StudentManager.Models;
using StudentManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StudentManager.Commands
{
    internal class SaveStudentCommand : ISaveStrategy
    {
        public void Save(object parameter)
        {
            if (parameter is AddStudentViewModel addStudentViewModel)
            {
                using var context = new ContextDB();

                var group = context.Groups.Find(addStudentViewModel.StudentDropdownItem.Id);

                var user = new User
                {
                    FirstName = addStudentViewModel.InputDataName,
                    LastName = addStudentViewModel.InputDataLastName,
                    MiddleName = addStudentViewModel.InputDataSecondName,
                    PhoneNumber = "+38(0" + addStudentViewModel.InputDataPhone,
                    Login = "",
                    Password = "",
                    DateOfBirth = addStudentViewModel.BirthDate,
                    Email = addStudentViewModel.InputDataEmail
                };

                var student = new Student
                {
                    User = user,
                    Group = group
                };

                try
                {
                    context.Students.Add(student);
                    var numberOfChanges = context.SaveChanges();


                    if (numberOfChanges > 0)
                    {
                        addStudentViewModel.AddStudentErrorMessage ="Студента успішно додано";
                        addStudentViewModel.AddStudentErrorMessageColor = Brushes.Green;
                    }
                    else
                    {
                        addStudentViewModel.AddStudentErrorMessage = "Помилка при додаванні студента";
                    }
                }
                catch (Exception e)
                {
                    addStudentViewModel.AddStudentErrorMessage = $"Виникла помилка при додаванні студента: {e.Message}";
                    addStudentViewModel.AddStudentErrorMessageColor = Brushes.Red;
                }
            }
        }


        public bool CanSave(object parameter)
        {
            if (parameter is AddStudentViewModel addStudentViewModel)
            {
                if (!string.IsNullOrWhiteSpace(addStudentViewModel.InputDataName) &&
                    !string.IsNullOrWhiteSpace(addStudentViewModel.InputDataLastName) &&
                    !string.IsNullOrWhiteSpace(addStudentViewModel.InputDataSecondName) &&
                    !string.IsNullOrWhiteSpace(addStudentViewModel.InputDataPhone) &&
                    !string.IsNullOrWhiteSpace(addStudentViewModel.InputDataEmail) &&
                    addStudentViewModel.BirthDate != null &&
                    addStudentViewModel.StudentDropdownItem != null)
                {
                    return true;
                }
            }

            return false;
        }
    }

}
