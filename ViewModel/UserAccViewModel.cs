// 2020-12-27, Bruce

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComFram
{
    public class UserAccViewModel : Conductor<object>
    {
        private BindableCollection<UserAccModel> _userAccs = new BindableCollection<UserAccModel>();
        private UserAccModel _selectedUserAcc = new UserAccModel();
        private string _search_name;

        public BindableCollection<UserAccModel> UserAccs
        {
            get { return _userAccs; }
            set { _userAccs = value; }
        }

        public UserAccModel SelectedUserAcc
        {
            get { return _selectedUserAcc; }
            set
            {
                //_selectedUserAcc = value;
                if (value != null)
                {
                    _selectedUserAcc.CopyFrom(value);
                    NotifyOfPropertyChange(() => SelectedUserAcc);
                }
            }
        }

        public string SearchName
        {
            get { return _search_name; }
            set
            {
                _search_name = value;
                NotifyOfPropertyChange(() => SearchName);
            }
        }


        /// <summary>
        /// 构造
        /// </summary>
        public UserAccViewModel()
        {
            RefreshData();
        }

        public void Save()
        {
            UserAccDao service = new UserAccDao();
            if (SelectedUserAcc.ID > 0)
            {
                if (service.UpdateData(SelectedUserAcc))
                {
                    RefreshData();
                    MessageBox.Show("Update successful.");
                }
            }
            else
            {
                if (service.InsertData(SelectedUserAcc))
                {
                    RefreshData();
                    MessageBox.Show("Insert successful.");
                }
            }
        }

        public void Search()
        {
            UserAccDao service = new UserAccDao();
            UserAccs.Clear();
            UserAccs.AddRange(service.FindListByName(SearchName).ConvertAll(d => d as UserAccModel));
        }

        public void New()
        {
            SelectedUserAcc = new UserAccModel();
        }

        public void Delete()
        {
            if (MessageBox.Show("Are you sure to delete?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                UserAccDao service = new UserAccDao();
                if (service.DeleteData(SelectedUserAcc))
                {
                    RefreshData();
                    New();
                    MessageBox.Show("Delete successful.");
                }
            }
        }

        public void RefreshData()
        {
            UserAccDao service = new UserAccDao();
            UserAccs.Clear();
            UserAccs.AddRange(service.FindListByPage(1, 10).ConvertAll(d => d as UserAccModel));
        }

    }

}
