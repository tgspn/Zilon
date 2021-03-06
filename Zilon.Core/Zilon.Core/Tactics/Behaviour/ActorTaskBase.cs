﻿using System.Diagnostics.CodeAnalysis;

namespace Zilon.Core.Tactics.Behaviour
{
    /// <summary>
    /// Базовый класс для всех задач актёра.
    /// </summary>
    /// <remarks>
    /// ОБЯЗАТЕЛЬНО все задачи актёров наследовать от этого класса.
    /// </remarks>
    public abstract class ActorTaskBase: IActorTask
    {
        [ExcludeFromCodeCoverage]
        protected ActorTaskBase(IActor actor)
        {
            Actor = actor;
        }

        [ExcludeFromCodeCoverage]
        protected IActor Actor { get; }

        [ExcludeFromCodeCoverage]
        public virtual bool IsComplete { get; set; }

        public abstract void Execute();
    }
}
