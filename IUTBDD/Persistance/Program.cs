using Persistance.Seed;
using System;

namespace Persistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new StarWarsContext();
            dbContext.Database.EnsureCreated();
            dbContext.EnsureSeedData();

        }
    }
}
