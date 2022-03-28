using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Persistance;
using Persistance.Models;
using Persistance.Seed;
using RecuperateDatas;
using System;

namespace IUTBDD_Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new StarWarsContext();
            dbContext.Database.EnsureCreated();
            dbContext.EnsureSeedData();

            var test = GetDatas.GetName();
            foreach(var c in test)
            {
                Console.WriteLine(c);

            }

            var test2 = GetDatas.GetHomePlanet();
            foreach (var hM in test2)
            {
                Console.WriteLine(hM);

            }

            var test3 = GetDatas.GetCharacterEpisodes();
            foreach (var cH in test3)
            {
                Console.WriteLine(cH);

            }



            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

        }
    }
}
