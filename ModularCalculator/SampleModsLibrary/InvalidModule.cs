using ModularCalculator.Core.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModsLibrary
{
    public class InvalidModule : IModule
    {
        public string Content => "Invalid Module";

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
