using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using TSD.Linq.Cars;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {        
            var cars = new CarSalesBook().Cars;
            
            //1.7
            int numOfSeats = new Car().NumberOfSeats ?? default;
            Console.WriteLine($"numOfSeats = {numOfSeats}");
            Console.WriteLine();

            //2.4
            Console.WriteLine("TOP 3 sales with regard to the amount of sold cars in 2014:");
            foreach (var car in cars.OrderBy(car => -car.Sales2014).Take(3))
            {
                Console.WriteLine($"{car.Make} {car.Sales2014} {car.Sales2015}");
            }
            Console.WriteLine();

            //2.5
            Console.WriteLine("Sales which increased by at least 50% in 2015 comparing to 2014:");
            foreach (var car in cars.Where(car => car.Sales2015 > 1.5 * car.Sales2014))
            {
                Console.WriteLine($"{car.Make} {car.Sales2014} {car.Sales2015}");
            }
            Console.WriteLine();

            //2.6
            Console.WriteLine("3 sales opening the second ten of the ranking in 2015:");
            foreach (var car in cars.OrderBy(car => -car.Sales2015).Skip(10).Take(3))
            {
                Console.WriteLine($"{car.Make} {car.Sales2014} {car.Sales2015}");
            }
            Console.WriteLine();

            //2.7
            Console.WriteLine("Total of sold cars in 2014:");
            Console.WriteLine(cars.Sum(car => car.Sales2014));
            Console.WriteLine();
            Console.WriteLine("Total of sold cars in 2015:");
            Console.WriteLine(cars.Sum(car => car.Sales2015));
            Console.WriteLine();

            //2.8
            Console.WriteLine("TOP10 sales in 2015:");
            foreach (var car in cars.OrderBy(car => -car.Sales2015).Take(10))
            {
                Console.WriteLine($"{car.Make} {car.Sales2014} {car.Sales2015}");
            }
            Console.WriteLine();
            Console.WriteLine("LAST10 sales in 2015:");
            foreach (var car in cars.OrderBy(car => car.Sales2015).Take(10))
            {
                Console.WriteLine($"{car.Make} {car.Sales2014} {car.Sales2015}");
            }
            Console.WriteLine();

            //2.9
            SaveCarsToXML(cars);

            //2.10
            foreach (var car in LoadCarsFromXML())
            {
                Console.WriteLine($"{car.Make} {car.Sales2014} {car.Sales2015}");
            }
            Console.WriteLine();

            //3.1
            Console.WriteLine($"Memory used by processes of my PC: {Process.GetProcesses().MemoryUsed()}");
            Console.WriteLine();

            //3.2
            bool isLeap(int year) => DateTime.IsLeapYear(year);
            Console.WriteLine($"Is 2020 a leap year? {isLeap(2020)}");
            Console.WriteLine();

            //3.3
            GenericCollection<int> genericCollection = new GenericCollection<int>();
            genericCollection.IsEmpty();
            for (int i = 0; i < 10; i++)
            {
                genericCollection.Add(i);
            }
            genericCollection.IsEmpty();
            for (int i = 0; i < 10; i++)
            {
                genericCollection.Get(i); 
            }            

            Console.ReadLine();
        }

        //2.9
        static void SaveCarsToXML(IList<Car> cars)
        {
            XDocument xDoc = new XDocument();
            XElement root = new XElement("Cars");
            xDoc.Add(root);
            foreach (var car in cars)
            {
                XElement make = new XElement("Make", car.Make);
                XElement sales2014 = new XElement("Sales2014", car.Sales2014);
                XElement sales2015 = new XElement("Sales2015", car.Sales2015);
                root.Add(new XElement("Car", make, sales2014, sales2015));
            }
            xDoc.Save(@"cars.xml");
        }

        //2.10
        static List<Car> LoadCarsFromXML()
        {
            return XElement.Load(@"cars.xml").Elements("Car").Select(
                car => new Car(car.Element("Make").Value)
                {
                    Sales2014 = int.Parse(car.Element("Sales2014").Value),
                    Sales2015 = int.Parse(car.Element("Sales2015").Value)
                }).ToList();
        }
    }

    //3.1
    public static class ProcessExtensions
    {
        public static long MemoryUsed(this Process[] processes)
        {
            return processes.Sum(process => process.WorkingSet64);
        }
    }

    //3.3
    public class GenericCollection<T>
    {
        private readonly Random random = new Random();
        private readonly LinkedList<T> list = new LinkedList<T>();
        public void Add(T input)
        {
            if(random.NextDouble() < 0.5)
            {                
                list.AddFirst(input);
                Console.WriteLine($"Element \"{input}\" added at the beginning");
            }
            else
            {
                list.AddLast(input); 
                Console.WriteLine($"Element \"{input}\" added at the end");                
            }
        }
        public T Get(int index)
        {
            int randomIndex = random.Next(index + 1);
            T res = list.ElementAt(randomIndex);
            Console.WriteLine($"Element \"{res}\" got from random index {randomIndex}");
            return res;
        }
        public bool IsEmpty()
        {
            bool isEmpty = list.Count == 0;
            if (isEmpty) Console.WriteLine("Collection does not have elements");
            else Console.WriteLine("Collection has elements");
            return isEmpty;
        }
    }    
}
