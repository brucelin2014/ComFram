using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComFram
{
    public class LoginViewModel : Screen
    {
        private string _userCode;
        private string _password;

        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public void Login()
        {
            UserAccDao dao = new UserAccDao();
            UserAccModel user = (UserAccModel)dao.FindByCode(UserCode);
            if (user != null && user.Password.Equals(Password))
            {
                MessageBox.Show("Login successful.");
                TryClose();
            }
            else
            {
                MessageBox.Show("Login failure.");
            }
        }

        public void Cancel()
        {
            TryClose();
        }

    }

}
