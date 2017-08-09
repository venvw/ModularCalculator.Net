using DevExpress.Mvvm;
using ModularCalculator.Core.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModularCalculator.Models
{
    internal class ModuleAdapter
    {
        private IModule module;

        private ModuleAdapter(IModule module)
        {
            this.module = module;
        }

        public string Content => module.Content;
        public DelegateCommand Command => new DelegateCommand(() =>
        {
            try
            {
                module.OnClick();
            }
            catch(Exception e)
            {
                MessageBox.Show($"{e.Message}", $"Error occurred in {module}.OnClick()");
            }
        });

        public static ModuleAdapter FromModule(IModule module)
        {
            if (module == null)
                throw new ArgumentNullException();

            return new ModuleAdapter(module);
        }
    }
}
