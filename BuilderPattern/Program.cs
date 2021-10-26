using BuilderPattern;
using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using a builder to instantiate and set parameters on object
            //
            // The pattern removes these parameters from the constructor and instead of having:
            // new Coffee("filter", true, true, true)
            // We get more readable code.
            //
            // Further this could be made fluent and allowing methods to be chained:
            // new Coffee().SetType("filter").Brew().AddMilk().AddSugar();
            var coffeeBuilder = new CoffeeBuilder();
            
            coffeeBuilder.SetType("filter");
            coffeeBuilder.Brew();
            coffeeBuilder.AddMilk();
            coffeeBuilder.AddSugar();

            Console.WriteLine(coffeeBuilder.Serve());

            // using a director
            var builder = new CoffeeBuilder();
            var director = new CoffeeBuildDirecor(builder);

            var filter = director.MakeFilter();
            var cappucino = director.MakeCappucino();
            
            Console.WriteLine(filter.Serve());
            Console.WriteLine(cappucino.Serve());
        }
    }
}
