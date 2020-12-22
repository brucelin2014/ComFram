using Caliburn.Micro;
using ComFram.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComFram
{
    public class EditTeacherViewModel : EditChildModel, IEditChildModel
    {
        public EditTeacherViewModel()
        {
            DisplayName = "老师编辑模块";
        }
    }
}
