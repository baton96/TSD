using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1;

namespace TSD.Linq.Cars
{
    public class CarSalesBook
    {
        public IList<Car> Cars { get; }

        public CarSalesBook()
        {
            Cars = GenerateCars();
            Cars = ReadCarsFromFile();
        }

        private IList<Car> GenerateCars()
        {
            var cars = new List<Car>() {
                new Car("Skoda"){Sales2014=44243, Sales2015=45529},
                new Car("Toyota"){Sales2014=31484, Sales2015=36465},
                new Car("BMW"){Sales2014=7714, Sales2015=9549}
            };
            var sortedCars = cars.OrderBy(c => c.Sales2015).ToList();
            return sortedCars;
        }

        private IList<Car> ReadCarsFromFile()
        {
            return CarDataFileReader.ReadCarsFromCSVFile();
        }
    }
}
