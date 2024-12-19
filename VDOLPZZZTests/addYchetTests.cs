using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDOLPZZZ.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDOLPZZZ.AppData;

namespace VDOLPZZZ.Pages.Tests
{
    [TestClass()]
    public class addYchetTests
    {
            [TestMethod()]
        public void CheckAccountingKod_PredpriytieTest()
        {
            Ychetnai acc = new Ychetnai { Kod_Predpriytie = 2, Naimenovanit_Prodykcie = "cdsfws", Kolichestvo = 2, Cena = 1 };
            bool expected = true;
            bool actual = addYchet.CheckAccounting(acc);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckNaimenovanit_ProdykcieTest()
        {
            Ychetnai acc = new Ychetnai { Kod_Predpriytie = 2, Naimenovanit_Prodykcie = "cdsfws", Kolichestvo = 2, Cena = 1 };
            bool expected = true;
            bool actual = addYchet.CheckAccounting(acc);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckCenaTest()
        {
            Ychetnai acc = new Ychetnai { Kod_Predpriytie = 2, Naimenovanit_Prodykcie = "cdsfws", Kolichestvo = 2, Cena = -21 };
            bool expected = false;
            bool actual = addYchet.CheckAccounting(acc);
            Assert.AreEqual(expected, actual);
        }
    }
}