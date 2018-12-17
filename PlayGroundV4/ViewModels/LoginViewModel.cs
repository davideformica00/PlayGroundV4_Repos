using Caliburn.Micro;
using PlayGroundV4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PlayGroundV4.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        #region username
        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }
        #endregion
        #region mypassword
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        #endregion
        #region myid
        private string _id;

        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => ID);
            }
        }

        #endregion 

        public void Save()
        {
            User newUser = new User
            {
                UserName = UserName,
                Password = Password,
                ID = ID
            };

            User.adduser(newUser);
        }

        //function for "login"-button 
        public void CheckLogin()
        {

            foreach (User user in User.UserList)
            {
                if (validateLogin(user))
                {
                    ShellViewModel.ChangeView(new ProfileViewModel(user));
                    break;
                    //Login View
                }
            }
        } 

        private bool validateLogin(User user)
        {
            if (user.UserName == UserName &&
                user.Password == Password &&
                user.ID == ID)
                return true;
            else
                return false;
        }
    }
}