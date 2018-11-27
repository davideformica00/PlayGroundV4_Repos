using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using PlayGroundV4.Models;
using System.Xml.Linq;

namespace PlayGroundV4.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private readonly string _filename = "test.xml";
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
            //Converting the object into the right form, so information can be written into the file
            XDocument doc = File.Exists(_filename) ? XDocument.Load(_filename) : new XDocument();

            User user = new User();
            user.UserName = UserName;
            user.Password = Password;
            user.ID = ID;

            //using XmlWriter for writing into the file
            using (XmlWriter xWriter = XmlWriter.Create(_filename, new XmlWriterSettings()
            {
                Indent = true,
                NewLineOnAttributes = true 
            }))
            {   //Writing to the file
                xWriter.WriteStartDocument();
                xWriter.WriteStartElement("root");

                xWriter.WriteStartElement("User");

                xWriter.WriteElementString("Username", UserName);
                xWriter.WriteElementString("Password", Password);
                xWriter.WriteElementString("Id", ID);

                xWriter.WriteEndElement();

                xWriter.WriteEndElement();
                xWriter.WriteEndDocument();
            }
        }

        //function for "login"-button 
        public void CheckLogin()
        {
            XDocument doc = XDocument.Load(_filename);

            foreach (var xmlUser in doc.Root.Elements("User"))
            {
                string usernameval = xmlUser.Element("Username").Value;
                string passwordval = xmlUser.Element("Password").Value;
                string IDval = xmlUser.Element("Id").Value;

                //ID needs to be parsed so it is saved as a int
                int intID = Int32.Parse(IDval);

                User user = new User();
                user.UserName = usernameval;
                user.Password = passwordval;
                user.ID = IDval;

                if(validateLogin(user))
                {
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