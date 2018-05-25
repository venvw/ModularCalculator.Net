using System;
using System.Windows;
using DevExpress.Mvvm;
using ModularCalculator.Core.Modules;

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
