using System.Reflection.Metadata;

namespace HalloDekorator
{
    internal interface IComponent
    {
        decimal Preis { get; }
        string Name { get; }
    }

    class Pizza : IComponent
    {
        public decimal Preis => 6m;

        public string Name => "Pizza";
    }

    class Brot : IComponent
    {
        public decimal Preis => 3m;

        public string Name => "Brot";
    }

    abstract class Dekorator : IComponent
    {
        protected readonly IComponent component;

        public Dekorator(IComponent component)
        {
            this.component = component;
        }

        public abstract decimal Preis { get; }

        public abstract string Name { get; }
    }

    class Salami : Dekorator
    {
        public Salami(IComponent component) : base(component)
        { }

        public override decimal Preis => component.Preis + 3m;

        public override string Name => component.Name + " Salami";
    }

    class Käse : Dekorator
    {
        public Käse(IComponent component) : base(component)
        { }

        public override decimal Preis => component.Preis + 2m;

        public override string Name => component.Name + " Käse";
    }
}
