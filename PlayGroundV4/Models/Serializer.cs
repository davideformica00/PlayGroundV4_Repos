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
        public static bool serialize(List<User> userlist, string path)
        {
           XDocument doc = new XDocument(path);

            using (XmlWriter xWriter = XmlWriter.Create(path, new XmlWriterSettings()
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
                    xWriter.WriteElementString("Id", user.ID);
                    xWriter.WriteElementString("Age", user.age);
                    xWriter.WriteElementString("Nationality", user.nationality);

                    xWriter.WriteEndElement();

                    xWriter.WriteEndElement();
                    xWriter.WriteEndDocument();
                }
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

        public static List<User> deserialize(string path)
        {
            if (File.Exists(path))
                throw new Exception("Path does not exist!");

            XDocument doc = XDocument.Load(path);

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
                user.nationality = nationalityval;
                user.age = ageval;
                user.ID = IDval;

                userlist.Add(user);

            }

            return userlist;
        }
    }
}