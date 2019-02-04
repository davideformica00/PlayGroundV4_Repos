using Caliburn.Micro;
using PlayGroundV4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;
using WindForms = System.Windows.Forms ;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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

        public object panel_Images { get; private set; }

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
        private void get_Images(String folder_path)
        {
            if (folder_path == "") return;

            try
            {
                DirectoryInfo folder = new DirectoryInfo(folder_path);

                if(folder.Exists){
                    foreach (FileInfo fInfo in folder.GetFiles()) 
                    {
                        if (".jpg|.jpeg|.png".Contains(fInfo.Extension.ToLower()))
                        {
                            String sDate = fInfo.LastWriteTime.ToString("dd-MM-yyyy");
                            add_Image(fInfo.FullName);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void add_Image(String Image_with_Path)
        {
            Image newImage = new Image();

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(Image_with_Path, UriKind.Absolute);
            src.EndInit();
            newImage.Source = src;

            newImage.Stretch = Stretch.Uniform;
            newImage.Height = 100;

            panel_Images.Children.Add(newImage);
        }
    }
}