using System.Windows;
using ModularCalculator.Core.Modules;

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
