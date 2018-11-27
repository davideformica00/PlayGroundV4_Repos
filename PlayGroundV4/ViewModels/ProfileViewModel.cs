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


        public void BackBtn()
        {
            ShellViewModel.ChangeView(new LoginViewModel());
        }

    }
}

