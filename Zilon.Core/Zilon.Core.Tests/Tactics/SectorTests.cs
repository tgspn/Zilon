﻿using System.Collections.Generic;
using FluentAssertions;
using Moq;

using NUnit.Framework;
using Zilon.Core.Common;
using Zilon.Core.Persons;
using Zilon.Core.Schemes;
using Zilon.Core.Tactics;
using Zilon.Core.Tactics.Spatial;

namespace Zilon.Core.Tests.Tactics
{
    [TestFixture]
    public class SectorTests
    {
        private Mock<ISurvivalData> _survivalDataMock;

        /// <summary>
        /// Тест проверяет, что при обновлении состояния сектора у актёра игрока в сектора падают
        /// значения характеристик выживания.
        /// </summary>
        [Test]
        public void Update_PlayerActorWithSurvival_SurvivalStatsDecremented()
        {
            // ARRANGE
            var mapMock = new Mock<IMap>();
            var map = mapMock.Object;

            var innerActorList = new List<IActor>();
            var actorManagerMock = new Mock<IActorManager>();
            actorManagerMock.SetupGet(x => x.Items).Returns(innerActorList);
            var actorManager = actorManagerMock.Object;

            var propContainerManagerMock = new Mock<IPropContainerManager>();
            var propContainerManager = propContainerManagerMock.Object;

            var dropResolverMock = new Mock<IDropResolver>();
            var dropResolver = dropResolverMock.Object;

            var schemeServiceMock = new Mock<ISchemeService>();
            var schemeService = schemeServiceMock.Object;

            var sector = new Sector(map, actorManager, propContainerManager, dropResolver, schemeService);
            sector.ExitNodes = new IMapNode[0];

            var actor = CreateActorMock();
            innerActorList.Add(actor);



            // ACT
            sector.Update();



            // ASSERT
            _survivalDataMock.Verify(x=>x.Update(), Times.Once);
        }

        private IActor CreateActorMock()
        {
            var actorMock = new Mock<IActor>();

            var personMock = new Mock<IPerson>();
            var person = personMock.Object;
            actorMock.SetupGet(x => x.Person).Returns(person);

            _survivalDataMock = new Mock<ISurvivalData>();
            var survivalStats = new SurvivalStat[] {
                new SurvivalStat(0){
                    Type = SurvivalStatType.Satiety,
                    Range = new Range<int>(-10, 10),
                    Rate = 1,
                    KeyPoints = new SurvivalStatKeyPoint[0]
                }
            };
            _survivalDataMock.Setup(x => x.Stats).Returns(survivalStats);
            var survivalData = _survivalDataMock.Object;
            personMock.SetupGet(x => x.Survival).Returns(survivalData);

            var effectCollection = new EffectCollection();
            personMock.SetupGet(x => x.Effects).Returns(effectCollection);



            return actorMock.Object;
        }
    }
}