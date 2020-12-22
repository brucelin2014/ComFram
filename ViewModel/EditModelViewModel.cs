using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComFram
{
    public class EditModelViewModel : Conductor<IEditChildModel>.Collection.OneActive, IModel
    {
        public EditModelViewModel(IEnumerable<IEditChildModel> models)
        {
            //IEnumerable<IEditChildModel> models = IoC.GetAll<IEditChildModel>();

            DisplayName = "数据编辑模块";

            Items.AddRange(models);
            ActivateItem(Items.FirstOrDefault());

            /*
            // 添加子列表
            ActivateItem(new EditTeacherViewModel());
            EnsureItem(new EditStudentViewModel());*/
        }
    }
}
