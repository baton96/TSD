namespace TSD.Linq.Cars
{   
    public class Car
    {        
        public Car() { }
		public Car(string make) { Make = make; }
        public string Make { get; }
        public int Sales2014 { get; set; }
        public int Sales2015 { get; set; }
        public int? NumberOfSeats { get; set; }
    }   
}
