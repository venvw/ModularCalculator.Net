using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCalculator.Core.Modules
{
    public interface IModule
    {
        string Content { get; }
        void OnClick();
    }
}
