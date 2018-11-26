using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayGroundV4_1._2
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

    }
}
