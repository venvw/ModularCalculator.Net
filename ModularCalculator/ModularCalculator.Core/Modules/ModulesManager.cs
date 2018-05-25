using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModularCalculator.Core.Modules
{
    public static class ModulesManager
    {
        private static List<IModule> modules;

        public static ObservableCollection<IModule> Loaded
        {
            get => new ObservableCollection<IModule>(modules);
        }

        public static void Load(string assemblyPath)
        {
            modules = modules ?? new List<IModule>();

            var assembly = System.Reflection.Assembly.LoadFile(assemblyPath);
            var assemblyModules = assembly.GetTypes().Where((t) => t.GetInterfaces().Contains(typeof(IModule)));
            modules.AddRange(assemblyModules.Select((m) => (IModule)Activator.CreateInstance(m)));
        }
    }
}
