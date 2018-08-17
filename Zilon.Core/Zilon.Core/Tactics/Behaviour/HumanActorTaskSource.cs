﻿using System;
using System.Collections.Generic;
using System.Linq;

using Zilon.Core.Persons;
using Zilon.Core.Tactics.Behaviour.Bots;
using Zilon.Core.Tactics.Spatial;

namespace Zilon.Core.Tactics.Behaviour
{
    public class HumanActorTaskSource : IHumanActorTaskSource
    {
        private IActorTask _currentTask;

        //TODO обобщить намерения.
        private HexNode _targetNode;
        private bool _taskIsActual;
        private IAttackTarget _attackTarget;
        private IPropContainer _propContainer;
        private IOpenContainerMethod _method;
        private PropTransfer[] _transfers;
        private Equipment _equipment;
        private int _slotIndex;
        private IIntention _currentIntesion;

        private readonly IDecisionSource _decisionSource;
        private readonly ITacticalActUsageService _actUsageService;

        public HumanActorTaskSource(IDecisionSource decisionSource,
            ITacticalActUsageService actUsageService)
        {
            _decisionSource = decisionSource;
            _actUsageService = actUsageService;
        }

        public IActorTask[] GetActorTasks(IMap map, IActorManager actorManager)
        {
            var currentTaskIsComplete = _currentTask?.IsComplete;
            if (currentTaskIsComplete != null && !currentTaskIsComplete.Value)
            {
                return new IActorTask[] { _currentTask };
            }

            if (CurrentActor == null)
            {
                throw new InvalidOperationException("Не выбран текущий ключевой актёр.");
            }

            if (_currentIntesion == null)
            {
                return new IActorTask[0];
            }

            _currentTask = _currentIntesion.CreateActorTask(_currentTask, CurrentActor);
            _currentIntesion = null;

            if (_currentTask != null)
            {
                return new IActorTask[] { _currentTask };
            }
            else
            {
                return new IActorTask[0];
            }

            //if (_taskIsActual && _currentTask?.IsComplete == true)
            //{
            //    _targetNode = null;
            //    _attackTarget = null;
            //    _method = null;
            //    _propContainer = null;
            //}

            //if (_targetNode != null)
            //{
            //    if (_taskIsActual)
            //    {
            //        return new[] { _currentTask };
            //    }

            //    _taskIsActual = true;
            //    var moveTask = new MoveTask(CurrentActor, _targetNode, map);
            //    _currentTask = moveTask;

            //    return new[] { _currentTask };
            //}

            //if (_attackTarget != null)
            //{
            //    var attackTask = new AttackTask(CurrentActor, _attackTarget, _actUsageService);
            //    _currentTask = attackTask;
            //    return new[] { _currentTask };
            //}

            //if (_propContainer != null && _method != null)
            //{
            //    var openContainerTask = new OpenContainerTask(CurrentActor, _propContainer, _method);
            //    _currentTask = openContainerTask;
            //    return new[] { _currentTask };
            //}

            //if (_transfers != null)
            //{
            //    var inventory = CurrentActor.Person.Inventory;

            //    if (inventory == null)
            //    {
            //        throw new InvalidOperationException($"Для данного персонажа {CurrentActor.Person} не задан инвентарь.");
            //    }

            //    _currentTask = new TransferPropsTask(CurrentActor, _transfers);
            //    return new[] { _currentTask };
            //}

            //if (_equipment != null)
            //{
            //    _currentTask = new EquipTask(CurrentActor, _equipment, _slotIndex);
            //    return new[] { _currentTask };
            //}

            //return new IActorTask[0];
        }

        public void SwitchActor(IActor currentActor)
        {
            CurrentActor = currentActor;
        }

        public IActor CurrentActor { get; private set; }


        public void Intent(IIntention intension)
        {
            //TODO Чтобы отменять текущие намерения, нужно указывать CancelIntention.
            // Становление null для намерения происходит только изнутри, после создания задачи.
            if (intension == null)
            {
                throw new ArgumentException(nameof(intension));
            }

            _currentIntesion = intension;
        }

        /// <summary>
        /// Указать намерение двигаться к указанному узлу.
        /// </summary>
        /// <param name="targetNode"> Целевой узел карты. </param>
        public virtual void IntentMove(HexNode targetNode)
        {
            if (targetNode == null)
            {
                throw new ArgumentException(nameof(targetNode));
            }

            _attackTarget = null;

            if (targetNode != _targetNode)
            {
                _taskIsActual = false;
                ClearCurrentTask();

                _targetNode = targetNode;
            }
        }

        //TODO Должна быть возможность указывать действие, которым можно атаковать.
        /// <summary>
        /// Указать намерение атаковать цель.
        /// </summary>
        /// <param name="target"> Целевой объект. </param>
        public virtual void IntentAttack(IAttackTarget target)
        {
            //Отключаю это предупреждение, иначе получается кривой код.
#pragma warning disable IDE0016 // Use 'throw' expression
            if (target == null)
            {
                throw new ArgumentException(nameof(target));
            }
#pragma warning restore IDE0016 // Use 'throw' expression

            ClearCurrentTask();

            _attackTarget = target;
        }

        /// <summary>
        /// Намерение открыть контейнер в секторе.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="method"></param>
        public virtual void IntentOpenContainer(IPropContainer container, IOpenContainerMethod method)
        {
            ClearCurrentTask();
            _method = method;
            _propContainer = container;
        }

        /// <summary>
        /// Hамерение перенести предметы между хранилищами (инвентарь-сундук-пол).
        /// </summary>
        /// <param name="props"></param>
        public virtual void IntentTransferProps(IEnumerable<PropTransfer> transfers)
        {
            //TODO Сделать генерацию контейнеров для сброшенных на пол пердметов.
            ClearCurrentTask();
            _transfers = transfers.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equipment"></param>
        /// <param name="slotIndex"></param>
        public virtual void IntentEquip(Equipment equipment, int slotIndex)
        {
            ClearCurrentTask();
            _equipment = equipment;
            _slotIndex = slotIndex;
        }

        private void ClearCurrentTask()
        {
            _taskIsActual = false;
            _targetNode = null;
            _attackTarget = null;
            _method = null;
            _propContainer = null;
            _transfers = null;
        }

        public void IntentUseSelf(IProp usableProp)
        {
            throw new NotImplementedException();
        }
    }
}