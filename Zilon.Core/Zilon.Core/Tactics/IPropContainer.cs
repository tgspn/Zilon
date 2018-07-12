﻿using System;
using Zilon.Core.Persons;
using Zilon.Core.Tactics.Spatial;

namespace Zilon.Core.Tactics
{
    /// <summary>
    /// Интерфейт предмета в секторе.
    /// </summary>
    public interface IPropContainer
    {
        /// <summary>
        /// Фактический предмет.
        /// </summary>
        IProp Prop { get; }

        /// <summary>
        /// Узер карты сектора, в котором находится контейнер.
        /// </summary>
        IMapNode Node { get; }

        /// <summary>
        /// Высртреливает, если контейнер открыт.
        /// </summary>
        event EventHandler<OpenContainerEventArgs> Opened;

        /// <summary>
        /// Открытие контейнера.
        /// </summary>
        void Open();
    }
}
