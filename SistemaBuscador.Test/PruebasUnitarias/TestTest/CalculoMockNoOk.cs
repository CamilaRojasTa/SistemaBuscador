using SistemaBuscador.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBuscador.Test.PruebasUnitarias.TestTest
{
    public class CalculoMockNoOk : ICalculos
    {
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            return 17;
        }
    }
}
