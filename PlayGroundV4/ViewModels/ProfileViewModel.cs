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

        #region nationality

        private string _nationality;

        public string nationality
        {
            get { return _nationality; }
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
            get { return _age; }
            set
            {
                _age = value;
                NotifyOfPropertyChange(() => age);
            }
        }

        #endregion

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                NotifyOfPropertyChange(() => User);
            }
        }

        public void ProfileNameOutput()
        {
            
        }
        public ProfileViewModel() { }

        public ProfileViewModel(User user)
        {
            this.User = user;
        }

        //XElement filedata = XElement.Load("test.xml");

        public void BackBtn()
        {
            ShellViewModel.ChangeView(new LoginViewModel());
        }

        //Saving edited data to file 
        public void saveBtn2()
        {
            //loading file 
            XDocument doc = XDocument.Load("test.xml");

            User.nationality = _nationality;
            User.age = _age;

            //making new elements "nationality" and "age"
            XElement nationality = new XElement("Nationality", User.nationality);
            XElement age = new XElement("Age", User.age);

            //adding the new elements to xml 
            doc.Root.Element("User").Add(nationality);
            doc.Root.Element("User").Add(age);

            //saving changes
            doc.Save("test.xml");
        }
    }
}