using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBuscador.Test.PruebasUnitarias.TestTest
{
    [TestClass]
    public class CalculosTest
    {
        [TestMethod]
        public void CumpleDespuesdeHoy()
        {
            //Preparacion
            DateTime fecha = new DateTime(2000, 12, 1);
            var clase = new Calculos();

            //Ejecucion
            int edad = clase.CalcularEdad(fecha);


            //Verificacion
            Assert.AreEqual(20, edad);
        }

        [TestMethod]
        public void CumpleAntesdeHoy()
        {
            //Preparacion
            DateTime fecha = new DateTime(2000, 1, 1);
            var clase = new Calculos();

            //Ejecucion
            int edad = clase.CalcularEdad(fecha);


            //Verificacion
            Assert.AreEqual(21, edad);
        }

    }
}
