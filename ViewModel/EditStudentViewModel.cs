using Caliburn.Micro;
using ComFram.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComFram
{
    public class EditStudentViewModel : EditChildModel, IEditChildModel
    {
        public EditStudentViewModel()
        {
            DisplayName = "学生编辑模块";
        }
    }
}
