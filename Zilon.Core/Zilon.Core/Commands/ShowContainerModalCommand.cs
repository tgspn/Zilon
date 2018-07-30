﻿using Zilon.Core.Client;

namespace Zilon.Core.Commands
{
    /// <summary>
    /// Команда на отображение модала для отображения контента контейнера.
    /// </summary>
    public class ShowContainerModalCommand : ShowModalCommandBase
    {
        private readonly IPlayerState _playerState;

        public ShowContainerModalCommand(ISectorModalManager sectorManager, IPlayerState playerState) :
            base(sectorManager)
        {
            _playerState = playerState;
        }
        
        public override void Execute()
        {
            var inventory = _playerState.ActiveActor.Actor.Inventory;
            var container = _playerState.SelectedContainer.Container;
            var containerContent = container.Content;
            var transferMachine = new PropTransferMachine(inventory, containerContent);
            
            ModalManager.ShowContainerModal(transferMachine);
        }

        public override bool CanExecute()
        {
            return true;
        }
    }
}