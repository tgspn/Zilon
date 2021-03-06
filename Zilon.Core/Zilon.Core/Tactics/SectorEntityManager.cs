﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Zilon.Core.Tactics
{
    /// <summary>
    /// Базовая реализация менеджера сущностей сектора.
    /// </summary>
    /// <typeparam name="TSectorEntity">
    /// Тип сущности сектора.
    /// Сейчас это либо <see cref="IActor">IActor</see> либо <see cref="IPropContainer">IPropContainer</see>.
    /// </typeparam>
    public abstract class SectorEntityManager<TSectorEntity> : ISectorEntityManager<TSectorEntity> where TSectorEntity: class
    {
        private readonly List<TSectorEntity> _items;

        public IEnumerable<TSectorEntity> Items => _items;

        protected SectorEntityManager()
        {
            _items = new List<TSectorEntity>();
        }

        public void Add(TSectorEntity entity)
        {
            _items.Add(entity);

            DoAdded(entity);
        }

        public void Add(IEnumerable<TSectorEntity> entities)
        {
            var itemArray = entities.ToArray();
            _items.AddRange(itemArray);

            DoAdded(itemArray);
        }

        public void Remove(TSectorEntity entity)
        {
            _items.Remove(entity);

            DoRemoved(entity);
        }

        public void Remove(IEnumerable<TSectorEntity> entities)
        {
            var entityArray = entities.ToArray();
            foreach (var entity in entityArray)
            {
                _items.Remove(entity);
            }

            DoRemoved(entityArray);
        }

        public event EventHandler<ManagerItemsChangedArgs<TSectorEntity>> Added;
        public event EventHandler<ManagerItemsChangedArgs<TSectorEntity>> Removed;


        private void DoAdded(params TSectorEntity[] entities)
        {
            var args = new ManagerItemsChangedArgs<TSectorEntity>(entities);
            Added?.Invoke(this, args);
        }

        private void DoRemoved(params TSectorEntity[] entities)
        {
            var args = new ManagerItemsChangedArgs<TSectorEntity>(entities);
            Removed?.Invoke(this, args);
        }
    }
}
