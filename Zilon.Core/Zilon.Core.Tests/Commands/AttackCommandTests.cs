﻿using System.Linq;

using FluentAssertions;

using LightInject;

using Moq;

using NUnit.Framework;

using Zilon.Core.Client;
using Zilon.Core.Commands;
using Zilon.Core.Tactics;
using Zilon.Core.Tactics.Behaviour;
using Zilon.Core.Tactics.Spatial;
using Zilon.Core.Tests.Common;

namespace Zilon.Core.Tests.Commands
{
    //TODO Добавить тест, который проверяет, что нельзя атаковать сквозь стены.
    public class AttackCommandTests: CommandTestBase
    {
        /// <summary>
        /// Тест проверяет, что можно атаковать, если не мешают стены.
        /// </summary>
        [Test]
        public void CanExecuteTest()
        {
            // ARRANGE
            var command = _container.GetInstance<AttackCommand>();



            // ACT
            var canExecute = command.CanExecute();


            // ASSERT
            canExecute.Should().Be(true);
        }

        /// <summary>
        /// Тест проверяет, что при выполнении команды корректно фисируется намерение игрока на атаку.
        /// </summary>
        [Test]
        public void Execute_CanAttack_AttackIntended()
        {
            // ARRANGE
            var command = _container.GetInstance<AttackCommand>();
            var humanTaskSourceMock = _container.GetInstance<Mock<IHumanActorTaskSource>>();
            var playerState = _container.GetInstance<IPlayerState>();



            // ACT
            command.Execute();


            // ASSERT
            var target = ((IActorViewModel)playerState.HoverViewModel).Actor;

            humanTaskSourceMock.Verify(x => x.Intent(It.Is<IIntention>(intention =>
                CheckAttackIntention(intention, playerState, target)
            )));
        }

        private static bool CheckAttackIntention(IIntention intention, IPlayerState playerState, IActor target)
        {
            var attackIntention = (Intention<AttackTask>)intention;
            var attackTask = attackIntention.TaskFactory(playerState.ActiveActor.Actor);
            return attackTask.Target == target;
        }

        protected override void RegisterSpecificServices(IMap testMap, Mock<IPlayerState> playerStateMock)
        {
            var targetMock = new Mock<IActor>();
            var targetNode = testMap.Nodes.OfType<HexNode>().SelectBy(2, 0);
            targetMock.SetupGet(x => x.Node).Returns(targetNode);
            var target = targetMock.Object;

            var targetVmMock = new Mock<IActorViewModel>();
            targetVmMock.SetupProperty(x => x.Actor, target);
            var targetVm = targetVmMock.Object;
            playerStateMock.SetupProperty(x => x.HoverViewModel, targetVm);

            _container.Register<AttackCommand>(new PerContainerLifetime());
        }
    }
}