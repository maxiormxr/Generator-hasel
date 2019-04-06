using Microsoft.VisualStudio.TestTools.UnitTesting;
using zadanie_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1.Tests
{
    [TestClass()]
    public class GeneratorHaslaTests
    {
        [TestMethod()]
        public void GenerujHasloTest()
        {
            GeneratorHasla gh = new GeneratorHasla(20, true);
            string haslo = gh.GenerujHaslo(false);
        }
    }
}