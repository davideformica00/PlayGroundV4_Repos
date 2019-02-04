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
                String.IsNullOrWhiteSpace(user.Password))
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

        #region nachname

        private string _nachname;

        public string Nachname
        {
            get { return _nachname; }
            set
            {
                _nachname = value;
                NotifyOfPropertyChange(() => Nachname);
            }
        }

        #endregion

        #region email

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        #endregion

        #region telefon

        private string _telefon;

        public string Telefon
        {
            get { return _telefon; }
            set
            {
                _telefon = value;
                NotifyOfPropertyChange(() => Telefon);
            }
        }
        #endregion 
    }
}