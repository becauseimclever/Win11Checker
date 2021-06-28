namespace Win11Checker.Models
{
    public class CPU
    {
        public CPU(string Brand, string Series, string Model, bool IsCompatible)
        {
            this.Brand = Brand; ;
            this.Series = Series;
            this.Model = Model;
            this.IsCompatible = IsCompatible;
        }
        public string Brand { get; }
        public string Series { get; }
        public string Model { get; }
        public bool IsCompatible { get; } = false;
    }
}
