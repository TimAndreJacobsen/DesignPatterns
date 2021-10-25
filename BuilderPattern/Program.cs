using System;
using System.Collections.Generic;

namespace Builder_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {

            //// Concrete Builders
            //var coffeePurchaseOrderBuilder = new CoffeePurchaseOrderBuilder();
            
            //// Director
            //var POP


             //Build vehicles and generate report

            var items = new List<Vehicle>
            {
                new Vehicle("Honda", "Accord", 479000.00, "Diesel"),
                new Vehicle("Mazda", "323", 180000.00, "Gasoline"),
                new Vehicle("Tesla", "Model 3", 600000.00, "Electric"),
            };

            var VehicleBuilder = new DailyReportBuilder(items);
            var director = new VehicleBuildDirector(VehicleBuilder);

            director.BuildCompleteReport();

            var directorReport = VehicleBuilder.GetDailyReport();

            Console.WriteLine(directorReport.Debug());
        }
    }
}
