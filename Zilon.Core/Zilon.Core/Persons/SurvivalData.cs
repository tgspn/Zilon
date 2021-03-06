﻿using System;
using System.Linq;

using Zilon.Core.Common;

namespace Zilon.Core.Persons
{
    /// <summary>
    /// Базовая реализация данных о выживании.
    /// </summary>
    public class SurvivalData : ISurvivalData
    {
        public SurvivalData()
        {
            Stats = new[] {
                CreateStat(SurvivalStatType.Satiety),
                CreateStat(SurvivalStatType.Water)
            };
        }

        public SurvivalStat[] Stats { get; }

        public event EventHandler<SurvivalStatChangedEventArgs> StatCrossKeyValue;

        public void RestoreStat(SurvivalStatType type, int value)
        {
            var stat = Stats.SingleOrDefault(x => x.Type == type);
            if (stat != null)
            {
                ChangeStatInner(stat, value);
            }
        }
        
        public void Update()
        {
            foreach (var stat in Stats)
            {

                ChangeStatInner(stat, -stat.Rate);
            }
        }

        private void ChangeStatInner(SurvivalStat stat, int value)
        {
            var oldValue = stat.Value;

            stat.Value += value;

            // TODO Это можно вынести в сеттер 
            if (stat.Value >= stat.Range.Max)
            {
                stat.Value = stat.Range.Max;
            }

            if (stat.Value <= stat.Range.Min)
            {
                stat.Value = stat.Range.Min;
            }

            var diff = RangeHelper.CreateNormalized<int>(oldValue, stat.Value);

            foreach (var keyPoint in stat.KeyPoints)
            {
                if (diff.Contains(keyPoint.Value))
                {
                    DoStatCrossKeyPoint(stat, keyPoint);
                }
            }
        }

        private static SurvivalStat CreateStat(SurvivalStatType type)
        {
            var stat = new SurvivalStat(50)
            {
                Type = type,
                Range = new Range<int>(-100, 100),
                Rate = 1,
                KeyPoints = new[]{
                        new SurvivalStatKeyPoint{
                            Level = SurvivalStatHazardLevel.Lesser,
                            Value = 0
                        },
                        new SurvivalStatKeyPoint{
                            Level = SurvivalStatHazardLevel.Strong,
                            Value = -25
                        },
                        new SurvivalStatKeyPoint{
                            Level = SurvivalStatHazardLevel.Max,
                            Value = -50
                        }
                    }
            };
            return stat;
        }

        private void DoStatCrossKeyPoint(SurvivalStat stat, SurvivalStatKeyPoint keyPoint)
        {
            var args = new SurvivalStatChangedEventArgs(stat, keyPoint);
            StatCrossKeyValue?.Invoke(this, args);
        }
    }
}
