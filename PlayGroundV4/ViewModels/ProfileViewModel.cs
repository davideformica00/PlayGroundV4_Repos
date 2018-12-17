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
    public class ProfileViewModel : BaseViewModel
    {


        #region listview

        public List<User> ListView
        {
            get { return User.UserList; }
        }

        #endregion

        #region nationality

        private string _nationality;

        public string Nationality
        {
            get { return _nationality; }
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
            get { return _age; }
            set
            {
                _age = value;
                NotifyOfPropertyChange(() => Age);
            }
        }

        #endregion

        private User _user;

        public User ProfileUser
        {
            get { return _user; }
            set
            {
                _user = value;
                NotifyOfPropertyChange(() => ProfileUser);
            }
        }

        public void ProfileNameOutput()
        {
            
        }
        public ProfileViewModel() { }

        public ProfileViewModel(User user)
        {
            this.ProfileUser = user;
        }

        //XElement filedata = XElement.Load("test.xml");

        public void BackBtn()
        {
            ShellViewModel.ChangeView(new LoginViewModel());
        }

        //Saving edited data to file 
        public void saveBtn2()
        {
            ProfileUser.Age = Age;
            ProfileUser.Nationality = Nationality;

            Serializer.serialize(User.UserList);
        }
    }
}