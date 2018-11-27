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
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private static ShellViewModel _instance;
        public ShellViewModel()
        {
            _instance = this;
            ActiveItem = new LoginViewModel();
        }

        public static void ChangeView(Screen screen)
        {
            _instance.ActiveItem = screen;
        }
    }
}