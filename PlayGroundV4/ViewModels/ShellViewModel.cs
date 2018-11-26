using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Xml.Serialization;

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
            //Converting the object into the right form, so it can be transportet (information can be written into the file)
            XmlSerializer sr = new XmlSerializer(UserName.GetType());
            TextWriter writer = new StreamWriter(_filename,true);

            sr.Serialize(writer, UserName);
            sr.Serialize(writer, Password);
            sr.Serialize(writer, ID);

            writer.Close();
        }
    }
}