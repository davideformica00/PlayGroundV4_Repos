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
        private static readonly string _xmlPath = "userlist.xml";
        private static List<User> UserList = Serializer.deserialize(_xmlPath);

        public static User adduser(User user)
        {

        }

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

        public string nationality
        {
            get { return _nationality;  }
            set
            {
                _nationality = value;
                NotifyOfPropertyChange(() => nationality);
            }
        }

        #endregion

        #region age

        private string _age;

        public string age
        {
            get { return _age;  }
            set
            {
                _age = value;
                NotifyOfPropertyChange(() => age);
            }
        }

        #endregion
    }
}

