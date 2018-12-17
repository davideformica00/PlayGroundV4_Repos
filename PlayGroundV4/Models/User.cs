using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGroundV4.Models
{
    public class User : PropertyChangedBase
    {
        public static List<User> UserList;
        public static void Init()
        {
            UserList = Serializer.deserialize();
        }
        public static bool adduser(User user)
        {
            if (String.IsNullOrWhiteSpace(user.UserName) ||
                String.IsNullOrWhiteSpace(user.Password) ||
                String.IsNullOrWhiteSpace(user.ID))
                return false;
            else
            {
                UserList.Add(user);
                Serializer.serialize(UserList);
                return true;
            }                
        }
        
        public User() { }

        #region      
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

        #region nationality

        private string _nationality;

        public string Nationality
        {
            get { return _nationality;  }
            set
            {
                _nationality = value;
                NotifyOfPropertyChange(() => Nationality);
            }
        }

        #endregion

        #region age

        private string _age;

        public string Age
        {
            get { return _age;  }
            set
            {
                _age = value;
                NotifyOfPropertyChange(() => Age);
            }
        }

        #endregion
    }
}