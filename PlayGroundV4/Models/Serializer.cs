using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PlayGroundV4.Models
{
    public abstract class Serializer
    {
        private static readonly string _filename = "userlist.xml";
        public static bool serialize(List<User> userlist)
        {
            XDocument doc = XDocument.Load(_filename);

            using (XmlWriter xWriter = XmlWriter.Create(_filename, new XmlWriterSettings()
            {
                Indent = true,
                NewLineOnAttributes = true
            }))
            {   //Writing to the file
                xWriter.WriteStartDocument();
                xWriter.WriteStartElement("root");

                foreach(User user in userlist)
                {
                    xWriter.WriteStartElement("User");

                    xWriter.WriteElementString("Username", user.UserName);
                    xWriter.WriteElementString("Password", user.Password);
                    xWriter.WriteElementString("Age", user.Age);
                    xWriter.WriteElementString("Nationality", user.Nationality);

                    xWriter.WriteEndElement();          
                }
                xWriter.WriteEndElement();
                xWriter.WriteEndDocument();
            }
            return true;
        }

        public static string getProperty(XElement element, string value)
        {
            if (element.Element(value) == null)
                return "";
            else
                return element.Element(value).Value;
        }

        public static List<User> deserialize()
        {
            XDocument doc;
            if (!File.Exists(_filename))
            {
                using (XmlWriter xWriter = XmlWriter.Create(_filename, new XmlWriterSettings()
                {
                    Indent = true,
                    NewLineOnAttributes = true
                }))
                {
                    doc = new XDocument();
                    xWriter.WriteStartDocument();
                    xWriter.WriteStartElement("root");
                    xWriter.WriteEndElement();
                    xWriter.WriteEndDocument();                   
                }
                
                return new List<User>();
            }

            try
            {
                doc = XDocument.Load(_filename);

                List<User> userlist = new List<User>();

                foreach (var xmlUser in doc.Root.Elements("User"))
                {
                    string usernameval = xmlUser.Element("Username").Value;
                    string passwordval = xmlUser.Element("Password").Value;
                    string nationalityval = xmlUser.Element("Nationality").Value;
                    string ageval = xmlUser.Element("Age").Value;
                    string IDval = xmlUser.Element("Id").Value;

                    //ID needs to be parsed so it is saved as a int
                    int intID = Int32.Parse(IDval);

                    User user = new User();
                    user.UserName = usernameval;
                    user.Password = passwordval;
                    user.Nationality = nationalityval;
                    user.Age = ageval;

                    userlist.Add(user);
                }

                return userlist; 
            }
            catch(Exception)
            {
                return new List<User>();
            }               
        }
    }
}