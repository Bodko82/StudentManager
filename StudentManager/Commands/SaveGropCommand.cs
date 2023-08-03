using StudentManager.Interface;
using StudentManager.Models;
using System;
using System.Linq;
using System.Windows.Media;

namespace StudentManager.ViewModels
{
    public class SaveGropCommand : ISaveStrategy
    {
        public void Save(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                using var context = new ContextDB();

                if (!context.Specialities.Any())
                {
                    homeViewModel.ErrorMessage = "Не знайдено жодної спеціальності. Додайте спочатку хоча б одну.";
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                    return;
                }

                if (context.Groups.Any(d => d.Name == homeViewModel.InputData))
                {
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                    homeViewModel.ErrorMessage = "Така група вже існує";
                    return;
                }

                var specialites = context.Specialities.Find(homeViewModel.SelectedDropdownItem.Id);
                if (specialites == null)
                {
                    homeViewModel.ErrorMessage = "Вибрану спеціальність не знайдено в базі даних";
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                    return;
                }

                var group = new Group { Name = homeViewModel.InputData, Speciality = specialites, Course = homeViewModel.InputDataGroup };

                try
                {
                    context.Groups.Add(group);
                    var numberOfChanges = context.SaveChanges();

                    if (numberOfChanges > 0)
                    {
                        homeViewModel.ErrorMessage = "Групу успішно додано";
                        homeViewModel.ErrorMessageColor = Brushes.Green;
                    }
                    else
                    {
                        homeViewModel.ErrorMessage = "Помилка при додаванні групи";
                        homeViewModel.ErrorMessageColor = Brushes.Red;
                    }
                }
                catch (Exception e)
                {
                    homeViewModel.ErrorMessage = $"Виникла помилка при додаванні групи: {e.Message}";
                    homeViewModel.ErrorMessageColor = Brushes.Red;
                }
            }
        }


        public bool CanSave(object parameter)
        {
            if (parameter is HomeViewModel homeViewModel)
            {
                if (!string.IsNullOrWhiteSpace(homeViewModel.InputData) &&
                    !string.IsNullOrWhiteSpace(homeViewModel.InputDataGroup) &&
                    homeViewModel.SelectedDropdownItem != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
