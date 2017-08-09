using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

using ModularCalculator.Core;
using System.Collections.ObjectModel;
using ModularCalculator.Models;
using ModularCalculator.Core.Modules;
using System.IO;
using System.Reflection;

namespace ModularCalculator.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public string CurrentExpression => Calculator.CurrentExpression;
        public string PreviousExpression => Calculator.PreviousExpression;

        public ObservableCollection<ModuleAdapter> Modules
        {
            get => new ObservableCollection<ModuleAdapter>(ModulesManager.Loaded.Select((m) => ModuleAdapter.FromModule(m)));
        }

        public MainViewModel()
        {
            Calculator.OnCurrentExpressionChanged += (object s, EventArgs e) => RaisePropertyChanged(nameof(CurrentExpression));
            Calculator.OnPreviousExpressionChanged += (object s, EventArgs e) => RaisePropertyChanged(nameof(PreviousExpression));

            LoadModules();
        }

        public void LoadModules()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach(string dll in Directory.GetFiles(path, "*.dll"))
            {
                ModulesManager.Load(dll);
            }
            RaisePropertyChanged(nameof(Modules));
        }

        public DelegateCommand<string> PushBackCurrentExpressionCommand => new DelegateCommand<string>((string param) => Calculator.PushBackCurrentExpresion(param));
        public DelegateCommand ClearCurrentExpressionCommand => new DelegateCommand(() => Calculator.ClearCurrentExpression());
        public DelegateCommand ClearBothExpressionsCommand => new DelegateCommand(() => Calculator.ClearBothExpressions());
        public DelegateCommand DeleteLastInCurrentExpressionCommand => new DelegateCommand(() => Calculator.DeleteLastInCurrentExpression());
        public DelegateCommand ReverseMathematicalSignCommand => new DelegateCommand(() => Calculator.ReverseMathematicalSign());
        public DelegateCommand<string> ApplyMathematicalActionCommand => new DelegateCommand<string>((string param) => Calculator.ApplyMathemticalAction(param));
        public DelegateCommand EvaluateCommand => new DelegateCommand(() => Calculator.EvaluateThroughNCalc());
    }
}
