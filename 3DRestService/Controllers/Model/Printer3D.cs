namespace _3DRestService.Controllers.Model
{
    public class Printer3D
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double GramPerHour { get; set; }


        public Printer3D(int id, string brand, string model, double gramPerHour)
        {
            Id = id;
            Brand = brand;
            Model = model;
            GramPerHour = gramPerHour;
        }

        public Printer3D()
        {

        }
    }
}
