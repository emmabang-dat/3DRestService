using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3DRestService.Controllers.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3DRestService.Controllers.Model;

namespace _3DRestService.Controllers.Manager.Tests
{
    [TestClass()]
    public class Printer3DManagerTests
    {
        private Printer3DManager _manager;

        [TestInitialize]
        public void SetUp()
        {
            _manager = new Printer3DManager();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_manager.GetAll(null));

            List<Printer3D> printer = _manager.GetAll(7.5);

            Assert.AreEqual(4, printer.Count);

            //List<Printer3D> printerMinimum = _manager.GetAll(minimumGramPerHour: 1);
            //Assert.AreEqual(5, printerMinimum.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_manager.GetById(1));
            Assert.IsNull(_manager.GetById(0));

            Assert.AreEqual("Ender3", _manager.GetById(1).Model);
            Assert.AreEqual(8.5, _manager.GetById(4).GramPerHour);
            Assert.AreEqual("Dremel", _manager.GetById(3).Brand);
        }

        [TestMethod()]
        public void AddTest()
        {
            var printer = new Printer3D()
            {
                Brand = "Jello",
                Model = "Huno4",
                GramPerHour = 7.8
            };

            Printer3D testPrinter = _manager.Add(printer);
            Assert.IsNotNull(testPrinter);
            Assert.AreEqual(printer, testPrinter);
        }
    }
}