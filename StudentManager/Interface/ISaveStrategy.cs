using StudentManager.Models;
using StudentManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace StudentManager.Interface
{
    public interface ISaveStrategy
    {
        bool CanSave(object parameter);
        void Save(object parameter);
    }
}
