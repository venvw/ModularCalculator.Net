using ModularCalculator.Core.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SampleModsLibrary
{
    public class AboutModule : IModule
    {
        public string Content => "About";

        public void OnClick()
        {
            MessageBox.Show("This is sample module");
        }
    }
}
