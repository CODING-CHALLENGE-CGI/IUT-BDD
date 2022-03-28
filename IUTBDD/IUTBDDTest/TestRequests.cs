using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistance;
using FluentAssertions;
using Persistance.Seed;
using System.Collections.Generic;
using Persistance.Models;
using RecuperateDatas;

namespace IUTBDDTest
{
    [TestClass]
    public class TestRequests
    {      

        [TestMethod]
        public void Compare_Name_NameCorrected()
        {

            
            List<string> names = GetDatas.GetName();
            List<string> namesCorrected = GetDatas.GetName();
            names.Should().BeEquivalentTo(namesCorrected);


        }


        [TestMethod]
        public void Compare_HomePlanet_HomePlanetCorrected()
        {
            List<HomePlanetCharacter> homePlanets = GetDatas.GetHomePlanet();
            List<HomePlanetCharacter> homePlanetsCorrected = GetDatas.GetHomePlanetCorrected();
            homePlanets.Should().BeEquivalentTo(homePlanetsCorrected);
        }

        [TestMethod]
        public void Compare_CharacterEpisodes_CharacterEpisodesCorrected()
        {

            
            List<CharacterFromEpisode> characterFromEpisodes = GetDatas.GetCharacterEpisodes();
            List<CharacterFromEpisode> characterFromEpisodesCorrected = GetDatas.GetCharacterEpisodesCorrected();
            characterFromEpisodes.Should().BeEquivalentTo(characterFromEpisodesCorrected);
        }
    }
}
