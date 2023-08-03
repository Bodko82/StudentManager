using Microsoft.EntityFrameworkCore;
using StudentManager.Interface;
using StudentManager.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;

namespace StudentManager.ViewModels
{
    public class SaveDepartmentCommand : ISaveStrategy
    {
        public void Save(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                using var context = new ContextDB();

                if (context.Departments.Any(d => d.Name == homeViewModel.InputData))
                {
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                    homeViewModel.ErrorMessage = "Такий відділ вже існує";
                    return;
                }

                var departmentType = context.DepartmentTypes.Find(homeViewModel.SelectedDropdownItem.Id);
                if (departmentType == null)
                {
                    homeViewModel.ErrorMessage = "Вибраний тип відділу не знайдено в базі даних";
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                    return;
                }

                var department = new Department { Name = homeViewModel.InputData, Type = departmentType };

                try
                {
                    context.Departments.Add(department);
                    var numberOfChanges = context.SaveChanges();

                    if (numberOfChanges > 0)
                    {
                        homeViewModel.ErrorMessage = "Відділ успішно доданий";
                        homeViewModel.ErrorMessageColor = Brushes.Green;
                    }
                    else
                    {
                        homeViewModel.ErrorMessage = "Помилка при додаванні відділу";
                        homeViewModel.ErrorMessageColor = Brushes.Red;
                    }
                    homeViewModel.IsTextBoxVisible = false;
                    homeViewModel.IsDropdownVisible = false;
                }
                catch (Exception e)
                {
                    homeViewModel.ErrorMessage = $"Виникла помилка при додаванні відділу: {e.Message}";
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                }
            }
        }


        public bool CanSave(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                var canSave = !string.IsNullOrWhiteSpace(homeViewModel.InputData);
                canSave &= homeViewModel.SelectedDropdownItem != null;
                return canSave;
            }

            return false;
        }
    }
}
