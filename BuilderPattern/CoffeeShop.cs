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
        public string Content { get; set; }
    }

    // Concrete implementation
    public class Filter : ICoffee
    {
        public string Type { get; set; } = "filter";
        public string Content { get; set; }


    }

    // Concrete implementation
    public class Espresso : ICoffee
    {
        public string Type { get; set; } = "espresso";
        public string Content { get; set; }


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
        private readonly StringBuilder _output = new StringBuilder();
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

        public void Brew() => _output.Append($"Brewing a fresh cup of {ConcreteCoffee.Type} \n");

        public void AddSugar() => _output.Append("added sugar \n");

        public void AddMilk() => _output.Append("added a splash of milk \n");

        public ICoffee Serve()
        {
            ConcreteCoffee.Content = _output.ToString();
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
        public Espresso MakeEspressoWithMilkAndSugar()
        {
            _builder.SetType("espresso");
            _builder.AddMilk();
            _builder.AddSugar();
            _builder.Brew();
            return (Espresso)_builder.Serve();
        }
    }




}
