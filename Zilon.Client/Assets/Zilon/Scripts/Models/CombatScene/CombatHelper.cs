﻿using System.Collections.Generic;
using Zilon.Core.Persons;
using Zilon.Core.Players;
using Zilon.Core.Services.CombatMap;
using Zilon.Core.Tactics.Initialization;
using Zilon.Core.Tactics.Map;

namespace Assets.Zilon.Scripts.Models.CombatScene
{
    static class CombatHelper
    {
        public static CombatInitData GetData(IMapGenerator mapGenerator)
        {
            var map = new CombatMap();

            mapGenerator.CreateMap(map);

            return new CombatInitData
            {
                Map = map,
                Players = new[] {
                    new PlayerCombatInitData{
                        Player = CreateFakePlayer(),
                        Squads =new[]{
                            CreateSquad(5),
                            CreateSquad(3),
                            CreateSquad(4)
                        }
                    },
                    new PlayerCombatInitData{
                        Player = CreateFakePlayer(),
                        Squads =new[]{
                            CreateSquad(5),
                            CreateSquad(3),
                            CreateSquad(4),
                            CreateSquad(6),
                        }
                    }
                }
            };
        }



        private static Person CreatePerson()
        {
            var person = new Person { };
            return person;
        }

        private static IPlayer CreateFakePlayer()
        {
            return new HumanPlayer();
        }

        private static Squad CreateSquad(int count)
        {
            var persons = new List<Person>();

            for (var i = 0; i < count; i++)
            {
                persons.Add(CreatePerson());
            }

            return new Squad
            {
                Persons = persons.ToArray()
            };
        }
    }
}
