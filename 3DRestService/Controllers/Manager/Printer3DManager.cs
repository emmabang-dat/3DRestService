using System.Collections.Generic;
using _3DRestService.Controllers.Model;

namespace _3DRestService.Controllers.Manager
{
    public class Printer3DManager
    {
        private static int nextId = 1;

        private static List<Printer3D> data = new List<Printer3D>()
        {
            new Printer3D() {Id = nextId++, Brand = "Creality", Model = "Ender3", GramPerHour = 7.5},
            new Printer3D() {Id = nextId++, Brand = "Creality", Model = "Ender10", GramPerHour = 10},
            new Printer3D() {Id = nextId++, Brand = "Dremel", Model = "Digilab", GramPerHour = 6.5},
            new Printer3D() {Id = nextId++, Brand = "Prusa", Model = "MK3S", GramPerHour = 8.5},
            new Printer3D() {Id = nextId++, Brand = "MakerBot", Model = "Replicator", GramPerHour = 9.5}
        };

        public List<Printer3D> GetAll(double? minimumGramPerHour)
        {
            List<Printer3D> result = new List<Printer3D>(data);

            if (minimumGramPerHour != null)
            {
                result = result.FindAll(filterPrinter => filterPrinter.GramPerHour >= minimumGramPerHour);
            }

            return result;
        }

        public Printer3D GetById(int id)
        {
            return data.Find( printer => printer.Id == id);
        }

        public Printer3D Add(Printer3D newPrinter3D)
        {
            newPrinter3D.Id = nextId++;
            data.Add(newPrinter3D);
            return newPrinter3D;
        }
    }
}
