using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace StudentManager.Commands
{
    public class SearchConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CollectionViewSource cvs)
            {
                cvs.Filter += Cvs_Filter;
                return cvs.View;
            }
            return null;
        }

        private void Cvs_Filter(object sender, FilterEventArgs e)
        {
            if (sender is CollectionViewSource cvs && cvs.Source is ObservableCollection<Speciality> data)
            {
                var comboBox = FindParent<ComboBox>(cvs);

                if (comboBox == null || comboBox.Text.Length == 0)
                {
                    e.Accepted = true;
                }
                else
                {
                    var speciality = (Speciality)e.Item;
                    e.Accepted = speciality.Name.Contains(comboBox.Text, StringComparison.OrdinalIgnoreCase);
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
            {
                return null;
            }

            if (parentObject is T parent)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
    }

}
