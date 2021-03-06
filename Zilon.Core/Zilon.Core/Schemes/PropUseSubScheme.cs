﻿using Newtonsoft.Json;

using Zilon.Core.Components;

namespace Zilon.Core.Schemes
{
    /// <summary>
    /// Подсхема предмета для хранения характеристик при применении предмета.
    /// </summary>
    public class PropUseSubScheme : SubSchemeBase, IPropUseSubScheme
    {
        /// <summary>
        /// Признак того, что при использовании будет уменьшен на единицу.
        /// </summary>
        [JsonProperty]
        public bool Consumable { get; private set; }

        /// <summary>
        /// Общие правила влияния.
        /// </summary>
        [JsonProperty]
        public ConsumeCommonRule[] CommonRules { get; private set; }

        //TODO Убрать, когда будут мысли, как можно задавать конкретные числа для правил
        [JsonProperty]
        public int Value { get; private set; }
    }
}
