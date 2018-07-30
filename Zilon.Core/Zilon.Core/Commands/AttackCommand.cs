﻿using System;
using System.Linq;
using Zilon.Core.Client;
using Zilon.Core.Common;
using Zilon.Core.Tactics;
using Zilon.Core.Tactics.Spatial;

namespace Zilon.Core.Commands
{
    //TODO Добавить тесты
    /// <summary>
    /// Команда на перемещение взвода в указанный узел карты.
    /// </summary>
    public class AttackCommand : ActorCommandBase
    {
        public AttackCommand(ISectorManager sectorManager,
            IPlayerState playerState) :
            base(sectorManager, playerState)
        {
        }

        public override bool CanExecute()
        {
            var map = _sectorManager.CurrentSector.Map;

            var currentNode = _playerState.ActiveActor.Actor.Node;

            var selectedActorViewModel = _playerState.SelectedActor;
            var targetNode = selectedActorViewModel.Actor.Node;

            var canExecute = MapHelper.CheckNodeAvailability(map, currentNode, targetNode);

            //TODO Добавить проверку:
            // 1. Выбран ли вражеский юнит.
            // 2. Находится ли в пределах досягаемости оружия.
            // 3. Видим ли текущим актёром.
            // 4. Способно ли оружие атаковать.
            // 5. Доступен ли целевой актёр для атаки.
            // 6. Возможно ли выполнение каких-либо команд над актёрами
            // (Нельзя, если ещё выполняется текущая команда. Например, анимация перемещения.)
            return canExecute;
        }

        protected override void ExecuteTacticCommand()
        {
            if (!CanExecute())
            {
                throw new InvalidOperationException("Не возможно выполнение команды.");
            }

            var sector = _sectorManager.CurrentSector;
            var selectedActorVM = _playerState.SelectedActor;

            var targetActor = selectedActorVM.Actor;
            _playerState.TaskSource.IntentAttack(targetActor);
            sector.Update();
        }
    }
}