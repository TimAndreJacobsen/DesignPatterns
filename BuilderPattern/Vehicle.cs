using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder_Pattern
{
    public class Vehicle
    {
        public string Make;
        public string Model;
        public double Price;
        public string FuelType;

        public Vehicle(string make, string model, double price, string FuelType)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.FuelType = FuelType;
        }
    }

    public class VehicleSalesReport
    {
        public string Title;
        public string VehicleDetails;
        public string ReportDetails;

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(Title)
                .AppendLine(VehicleDetails)
                .AppendLine(ReportDetails)
                .ToString();
        }
    }

    public interface IVehicleBuilder
    {
        void AddTitle();
        void AddVehicleDetails();
        //void AddVehicleStatistics();
        void AddReportDetails(DateTime dateTime);
        VehicleSalesReport GetDailyReport();
    }

    public class DailyReportBuilder : IVehicleBuilder
    {
        private VehicleSalesReport _report;
        private IEnumerable<Vehicle> _items;

        public DailyReportBuilder(IEnumerable<Vehicle> items)
        {
            Reset();
            _items = items;
        }

        public void AddTitle()
        {
            _report.Title = "------- Daily Sales Report ------- \n\n";
        }

        public void AddVehicleDetails()
        {
            _report.VehicleDetails = string.Join(Environment.NewLine, _items.Select(vehicle =>
            $"Vehicle: {vehicle.Make} - {vehicle.Model} \n" +
            $"Powered by {vehicle.FuelType}! \n" +
            $"Price: {vehicle.Price} \n"));
        }

        public void AddReportDetails(DateTime dateTime)
        {
            _report.ReportDetails = $"Report generated on {dateTime}";
        }

        public VehicleSalesReport GetDailyReport()
        {
            VehicleSalesReport finishedReport = _report;
            Reset();

            return finishedReport;
        }

        public void Reset()
        {
            _report = new VehicleSalesReport();
        }
    }


    public class VehicleBuildDirector
    {
        private IVehicleBuilder _builder;

        public VehicleBuildDirector(IVehicleBuilder concreteBuilder)
        {
            _builder = concreteBuilder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddVehicleDetails();
            _builder.AddReportDetails(DateTime.Now);
        }
    }
}
