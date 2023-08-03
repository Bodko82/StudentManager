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
    internal class SaveEmployeeCommand : ISaveStrategy
    {
        public void Save(object parameter)
        {
            if (parameter is AddEmployeeViewModel addEmployeeViewModel)
            {
                using var context = new ContextDB();


                var user = new User
                {
                    FirstName = addEmployeeViewModel.InputDataName,
                    LastName = addEmployeeViewModel.InputDataLastName,
                    MiddleName = addEmployeeViewModel.InputDataSecondName,
                    PhoneNumber = "+38(0" + addEmployeeViewModel.InputDataPhone,
                    Login = "",
                    Password = "",
                    DateOfBirth = addEmployeeViewModel.BirthDate,
                    Email = addEmployeeViewModel.InputDataEmail
                };

                var employee = new Employee
                {
                    User = user,
                    ExperienceYears = addEmployeeViewModel.InputDataExperience,
                    HireDate = addEmployeeViewModel.HireDate,
                    Position = addEmployeeViewModel.InputDataPosition,
                    Salary = addEmployeeViewModel.InputDataSalary,
                };

                try
                {
                    context.Employees.Add(employee);
                    var numberOfChanges = context.SaveChanges();


                    if (numberOfChanges > 0)
                    {
                        addEmployeeViewModel.ErrorMessage = "Працівника додано";
                        addEmployeeViewModel.ErrorMessageColor = Brushes.Green;
                    }
                    else
                    {
                        addEmployeeViewModel.ErrorMessage = "Помилка при додаванні працівника";
                    }
                }
                catch (Exception e)
                {
                    addEmployeeViewModel.ErrorMessage = $"Виникла помилка при додаванні працівника: {e.Message}";
                    addEmployeeViewModel.ErrorMessageColor = Brushes.Red;
                }
            }
        }


        public bool CanSave(object parameter)
        {
            if (parameter is AddEmployeeViewModel addEmployeeViewModel)
            {
                if (!string.IsNullOrWhiteSpace(addEmployeeViewModel.InputDataName) &&
                    !string.IsNullOrWhiteSpace(addEmployeeViewModel.InputDataLastName) &&
                    !string.IsNullOrWhiteSpace(addEmployeeViewModel.InputDataSecondName) &&
                    !string.IsNullOrWhiteSpace(addEmployeeViewModel.InputDataPhone) &&
                    !string.IsNullOrWhiteSpace(addEmployeeViewModel.InputDataEmail) &&
                    !string.IsNullOrWhiteSpace(addEmployeeViewModel.InputDataPosition) &&
                    addEmployeeViewModel.InputDataExperience != 0 &&
                    addEmployeeViewModel.InputDataSalary != 0 &&
                    addEmployeeViewModel.BirthDate != null && addEmployeeViewModel.HireDate != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
