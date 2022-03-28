using BenchmarkDotNet.Attributes;
using RecuperateDatas;

namespace IUTBDD_Benchmark
{
    public class BenchClass
    {                      

        [Benchmark]
        public void GetName()
        {

            GetDatas.GetName();

        }

        [Benchmark]
        public void GetNameCorrected()
        {
            GetDatas.GetNameCorrected();
        }

        [Benchmark]
        public void GetHomePlanet()
        {
            GetDatas.GetHomePlanet();
        }

        [Benchmark]
        public void GetHomePlanetCorrected()
        {
            GetDatas.GetHomePlanetCorrected();
        }

        [Benchmark]
        public void GetCharacterEpisodes()
        {
            GetDatas.GetCharacterEpisodes();
        }

        [Benchmark]
        public void GetCharacterEpisodesCorrected()
        {
            GetDatas.GetCharacterEpisodesCorrected();
        }



    }

}
