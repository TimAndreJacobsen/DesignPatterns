using BuilderPattern;
using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // The simple example
            var filterCoffeeBuilder = new CoffeeBuilder();

            filterCoffeeBuilder.SetType("filter");
            filterCoffeeBuilder.Brew();

            var filterCoffee = filterCoffeeBuilder.Serve();
            //Console.WriteLine(filterCoffee.Content);

            var espressoCoffeeBuilder = new CoffeeBuilder();
            espressoCoffeeBuilder.SetType("espresso");
            espressoCoffeeBuilder.Brew();
            espressoCoffeeBuilder.AddSugar();
            espressoCoffeeBuilder.AddMilk();

            var espressoCoffee = espressoCoffeeBuilder.Serve();
            //Console.WriteLine(espressoCoffee.Content);

            // Now we add in a director, to let us quickly generate "complex" objects.
            // We pass the builder into the director
            var coffeeBuilder = new CoffeeBuilder();
            var coffeeBuilderDirector = new CoffeeBuildDirecor(coffeeBuilder);

            var espressoOne = coffeeBuilderDirector.MakeEspressoWithMilkAndSugar();

            Console.WriteLine(espressoOne.Content);







            //// More complex example. Produce cars and generate a report
            ////Build vehicles and generate report
            //var items = new List<Vehicle>
            // {
            //     new Vehicle("Honda", "Accord", 479000.00, "Diesel"),
            //     new Vehicle("Mazda", "323", 180000.00, "Gasoline"),
            //     new Vehicle("Tesla", "Model 3", 600000.00, "Electric"),
            // };

            //var VehicleBuilder = new DailyReportBuilder(items);
            //var VehicleBuilderDirector = new VehicleBuildDirector(VehicleBuilder);

            //VehicleBuilderDirector.BuildCompleteReport();
            //var directorReport = VehicleBuilder.GetDailyReport();

            //Console.WriteLine(directorReport.Debug());
        }
    }
}
