using StudentManager.Interface;
using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StudentManager.ViewModels
{
    public class SaveDepartmentTypeViewModel : ISaveStrategy
    {
        public void Save(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                using var context = new ContextDB();

                if (context.DepartmentTypes.Any(dt => dt.Type == homeViewModel.InputData))
                {
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                    homeViewModel.ErrorMessage = "Такий тип відділу вже існує";

                    return;
                }

                var departmentType = new DepartmentType { Type = homeViewModel.InputData };
                try
                {
                    context.DepartmentTypes.Add(departmentType);
                    var numberOfChanges = context.SaveChanges();

                    if (numberOfChanges > 0)
                    {
                        homeViewModel.ErrorMessage = "Тип відділу успішно доданий";
                        homeViewModel.ErrorMessageColor = Brushes.Green;
                    }
                    else
                    {
                        homeViewModel.ErrorMessage = "Помилка при додаванні типу відділу";
                        homeViewModel.ErrorMessageColor = Brushes.Red;
                    }
                    homeViewModel.IsTextBoxVisible = false;
                }
                catch (Exception e)
                {
                    homeViewModel.ErrorMessage = $"Виникла помилка при додаванні типу відділу: {e.Message}";
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                }

            }
        }
        public bool CanSave(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                var canSave = !string.IsNullOrWhiteSpace(homeViewModel.InputData);
                return canSave;
            }

            return false;
        }
    }
}
