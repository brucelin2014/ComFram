using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ComFram
{
    public class ShellViewModel : Conductor<IModel>.Collection.OneActive, IShell //Caliburn.Micro.PropertyChangedBase, IShell
    {
        // ����
        public ShellViewModel(IWindowManager windowManager,IEnumerable<IModel> models)
        {
            _WindowManager = windowManager;

            Items.AddRange(models);
            ActivateItem(Items.FirstOrDefault());

            /*
            // ������б�
            //ActivateItem(new InfoModelViewModel()); // ��ǰ�����ģ��
            EnsureItem(new InfoModelViewModel());
            ActivateItem(new EditModelViewModel());*/
        }

        readonly IWindowManager _WindowManager;

        // ��������
        public void ClickMeShowWindow()
        {
            _WindowManager.ShowWindow(new Shell2ViewModel());
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            // ��������
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            // �����
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                // �����ͷ���Դ
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