using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ComFram
{
    public class ShellViewModel : Conductor<IModel>.Collection.OneActive, IShell //Caliburn.Micro.PropertyChangedBase, IShell
    {
        // 构造
        public ShellViewModel(IWindowManager windowManager,IEnumerable<IModel> models)
        {
            _WindowManager = windowManager;

            Items.AddRange(models);
            ActivateItem(Items.FirstOrDefault());

            /*
            // 添加子列表
            //ActivateItem(new InfoModelViewModel()); // 当前激活的模块
            EnsureItem(new InfoModelViewModel());
            ActivateItem(new EditModelViewModel());*/
        }

        readonly IWindowManager _WindowManager;

        // 弹出窗体
        public void ClickMeShowWindow()
        {
            _WindowManager.ShowWindow(new Shell2ViewModel());
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            // 加载数据
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            // 激活窗口
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                // 可以释放资源
            }
            base.OnDeactivate(close);
        }

        public void PersonManage()
        {
            _WindowManager.ShowWindow(new PersonViewModel());
        }

        public void UserManage()
        {
            _WindowManager.ShowWindow(new UserAccViewModel());
        }

        public void Login()
        {
            _WindowManager.ShowWindow(new LoginViewModel());
        }

    }

}