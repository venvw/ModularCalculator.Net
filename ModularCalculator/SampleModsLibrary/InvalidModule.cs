using System;
using ModularCalculator.Core.Modules;

namespace SampleModsLibrary
{
    //Module which causes an error
    public class InvalidModule : IModule
    {
        public string Content => "Invalid Module";

        public void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}
