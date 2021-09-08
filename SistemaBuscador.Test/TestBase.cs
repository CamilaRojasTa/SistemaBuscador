using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBuscador.Test
{
    public class TestBase
    {
        protected AplicationDbContext BuildContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AplicationDbContext>()
                .UseInMemoryDatabase(dbName).Options;

            var dbContext = new AplicationDbContext(options);
            return dbContext;
        }
    }
}
