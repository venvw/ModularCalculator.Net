namespace ModularCalculator.Core.Modules
{
    public class SinModule : IModule
    {
        public string Content => "Sin(x)";

        public void OnClick()
        {
            Calculator.ApplyFunction("Sin({0})");
        }
    }

    public class CosModule : IModule
    {
        public string Content => "Cos(x)";

        public void OnClick()
        {
            Calculator.ApplyFunction("Cos({0})");
        }
    }

    public class TanModule : IModule
    {
        public string Content => "Tan(x)";

        public void OnClick()
        {
            Calculator.ApplyFunction("Tan({0})");
        }
    }

    public class CtgModule : IModule
    {
        public string Content => "Ctg(x)";

        public void OnClick()
        {
            Calculator.ApplyFunction("1/Tan({0})");
        }
    }

    public class Pow2 : IModule
    {
        public string Content => "Pow(x, 2)";

        public void OnClick()
        {
            Calculator.ApplyFunction("Pow({0}, 2)");
        }
    }
}
