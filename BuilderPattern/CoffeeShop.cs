using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public interface ICoffee
    {
        public string Type { get; set; }

        void Brew();
        void AddSugar();
        void AddMilk();
        string Serve();
    }

    // Concrete Types
    public class Filter : ICoffee
    {
        private readonly StringBuilder _output = new StringBuilder();
        public string Type { get; set; } = "filter";

        public void Brew() => _output.Append($"Brewing a fresh cup of {Type} \n");
        public void AddSugar() => _output.Append("with a lot sugar \n");
        public void AddMilk() => _output.Append("and a scoop of milk \n");
        public string Serve() => _output.ToString();
    }

    // Concrete implementation
    public class Espresso : ICoffee
    {
        private readonly StringBuilder _output = new StringBuilder();
        public string Type { get; set; } = "espresso";

        public void Brew() => _output.Append($"Brewing a fresh cup of {Type} \n");
        public void AddSugar() => _output.Append("with a little sugar \n");
        public void AddMilk() => _output.Append("and a splash of milk \n");
        public string Serve() => _output.ToString();
    }


    // Interface builder
    public interface ICoffeeBuilder
    {
        void SetType(string type);
        void Brew();
        void AddSugar();
        void AddMilk();
        ICoffee Serve();
    }

    // Concrete builder
    public class CoffeeBuilder : ICoffeeBuilder
    {
        private ICoffee ConcreteCoffee;

        public void SetType(string type)
        {
            ConcreteCoffee = type switch
            {
                "filter" => new Filter(),
                "espresso" => new Espresso(),
                _ => throw new NotImplementedException(),
            };
        }

        public void Brew() => ConcreteCoffee.Brew();
        public void AddSugar() => ConcreteCoffee.AddSugar();
        public void AddMilk() => ConcreteCoffee.AddMilk();

        public ICoffee Serve()
        {
            return ConcreteCoffee;
        }
    }


    // Director
    public class CoffeeBuildDirecor
    {
        private ICoffeeBuilder _builder;
        public CoffeeBuildDirecor(ICoffeeBuilder builder)
        {
            _builder = builder;
        }

        public Filter MakeFilter()
        {
            _builder.SetType("filter");
            _builder.Brew();
            return (Filter)_builder.Serve();
        }

        public Espresso MakeEspresso()
        {
            _builder.SetType("espresso");
            _builder.Brew();
            return (Espresso)_builder.Serve();
        }
        public Espresso MakeCappucino()
        {
            _builder.SetType("espresso");
            _builder.Brew();
            _builder.AddMilk();
            _builder.AddSugar();
            return (Espresso)_builder.Serve();
        }
    }




}
