using StudentManager.Interface;
using StudentManager.Models;
using System;
using System.Linq;
using System.Windows.Media;

namespace StudentManager.ViewModels
{
    internal class SaveSpecialityViewModel : ISaveStrategy
    {
        public void Save(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                using var context = new ContextDB();

                if (context.Specialities.Any(dt => dt.Name == homeViewModel.InputData))
                {
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                    homeViewModel.ErrorMessage = "Така спеціальність вже існує";

                    return;
                }

                var speciality = new Speciality { Name = homeViewModel.InputData };
                try
                {
                    context.Specialities.Add(speciality);
                    var numberOfChanges = context.SaveChanges();

                    if (numberOfChanges > 0)
                    {
                        homeViewModel.ErrorMessage = "Спеціальність успішно додана";
                        homeViewModel.ErrorMessageColor = Brushes.Green;
                    }
                    else
                    {
                        homeViewModel.ErrorMessage = "Помилка при додаванні спеціальності";
                        homeViewModel.ErrorMessageColor = Brushes.Red;
                    }
                    homeViewModel.IsTextBoxVisible = false;
                }
                catch (Exception e)
                {
                    homeViewModel.ErrorMessage = $"Виникла помилка при додаванні спеціальності {e.Message}";
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
