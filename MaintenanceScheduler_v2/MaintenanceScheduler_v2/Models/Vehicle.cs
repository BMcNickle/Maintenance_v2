namespace MaintenanceScheduler_v2.Models
{
    //Class created like this to allow me to create an object named 'Vehicle' later
    public class Vehicle
    {
        public string VehicleType { get; set; }
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Milage { get; set; }
    }
}
