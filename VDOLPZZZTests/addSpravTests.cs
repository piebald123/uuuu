using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDOLPZZZ.AppData;
using VDOLPZZZ.Pages;

namespace VDOLPZZZTests
{
    [TestClass()]
    public class addSpravTests
    {
        [TestMethod()]
        public void CheckSpravochnayaNaimenovaniTest()
        {
            Spravochnaya inf = new Spravochnaya { Naimenovani = "get", Adres = "asd", FIO = "c" };
            bool expected = true;
            bool actual = addSprav.CheckSpravochnaya(inf);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckSpravochnayaAdresTest()
        {
            Spravochnaya inf = new Spravochnaya { Naimenovani = "get", Adres = "", FIO = "c" };
            bool expected = false;
            bool actual = addSprav.CheckSpravochnaya(inf);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckSpravochnayaFIOTest()
        {
            Spravochnaya inf = new Spravochnaya { Naimenovani = "get", Adres = "asd", FIO = "c" };
            bool expected = true;
            bool actual = addSprav.CheckSpravochnaya(inf);
            Assert.AreEqual(expected, actual);
        }
    }
}
