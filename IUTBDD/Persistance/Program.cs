using Persistance.Seed;
using System;
using System.IO;

namespace Persistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new StarWarsContext();
            dbContext.Database.EnsureCreated();
            dbContext.EnsureSeedData();
            var sqlitePath = Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
       @"StarWars.db");
            Console.WriteLine("La base Star Wars a bien été créée. Vous pouvez la retrouver sous : " + sqlitePath);

        }
    }
}
