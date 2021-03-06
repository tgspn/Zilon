﻿using System.Collections.Generic;
using System.Linq;

//using Zilon.Core.Logging;
using Zilon.Core.Schemes;

namespace Zilon.Core.Persons
{
    //public static class PerkResolver
    //{
    //    /// <summary>
    //    /// Выполняет расчёт прокачки перка на основании его выполненых работ.
    //    /// </summary>
    //    /// <param name="activePerk">Активный перк.</param>
    //    /// <returns>Возвращает true, если перк прокачен хоть на уровень.</returns>
    //    /// <remarks>
    //    /// У перка должны быть выставлен текущий прогресс работ в DoneLevelJobs.
    //    /// </remarks>
    //    public static bool Resolve(Perk activePerk)
    //    {
    //        if (activePerk.CurrentJobs == null)
    //        {
    //            throw new AppException("Активный перк не содержит никаких работ. Текущий перк не может развиваться.");
    //        }

    //        if (activePerk.TargetLevelScheme == null)
    //        {
    //            throw new AppException("Активным перком выбран перк, которые не может дальше развиваться.");
    //        }

    //        var allJobsDone = UpdateJobs(activePerk.TargetLevelScheme.Jobs, activePerk.CurrentJobs);

    //        if (!allJobsDone)
    //        {
    //            return false;
    //        }

    //        activePerk.CurrentJobs = null;

    //        // Если все работы выполнены, то повышаем подуровень перка.
    //        // Если взяты все подуровни, то переходим к следующему уровню.
    //        var currentLevel = activePerk.CurrentLevel;
    //        var currentSubLevel = activePerk.CurrentSubLevel;

    //        PerkHelper.GetNextLevel(activePerk.Scheme, ref currentLevel, ref currentSubLevel);

    //        activePerk.CurrentLevel = currentLevel;
    //        activePerk.CurrentSubLevel = currentSubLevel;
    //        activePerk.IsLevelPaid = false;

    //        PerkHelper.CalcLevelScheme(activePerk.Scheme.Levels, currentLevel, currentSubLevel,
    //            out PerkLevelSubScheme archievedLevelScheme, out PerkLevelSubScheme targetLevelScheme);

    //        AddLevelIfNew(activePerk.ArchievedLevelSchemes, archievedLevelScheme);

    //        activePerk.TargetLevelScheme = targetLevelScheme;

    //        return true;
    //    }

    //    /// <summary>
    //    /// Формирует список прокаченный уровней перка на основе
    //    /// текущих уровней и уровня после расчёта работ.
    //    /// </summary>
    //    /// <param name="perkArchievedLevelSchemes"> Полученные схемы уровне перка. </param>
    //    /// <param name="scopeArchievedLevelScheme"> Расчитанный уровень за итерацию. </param>
    //    /// <returns></returns>
    //    private static PerkLevelSubScheme[] AddLevelIfNew(PerkLevelSubScheme[] perkArchievedLevelSchemes,
    //        PerkLevelSubScheme scopeArchievedLevelScheme)
    //    {
    //        var stack = new Stack<PerkLevelSubScheme>(perkArchievedLevelSchemes);

    //        var topLevel = stack.Peek();
    //        if (topLevel != scopeArchievedLevelScheme)
    //        {
    //            stack.Push(scopeArchievedLevelScheme);
    //        }

    //        return stack.ToArray();
    //    }

    //    /// <summary>
    //    /// Выполняет обновление текущих работ перка на основе указанных работ.
    //    /// </summary>
    //    /// <param name="activePerk">Активный перк.</param>
    //    /// <param name="actorJobs">Работы, которые были выполнены в рамках этого перка.</param>
    //    /// <returns>Актеальное состояние выполненых работ перка.</returns>
    //    public static JobSubScheme[] UpdateActivePerkProgress(Perk activePerk, JobSubScheme[] actorJobs)
    //    {
    //        var totalPersonJobs = new List<JobSubScheme>();
    //        foreach (var schemeJob in activePerk.TargetLevelScheme.Jobs)
    //        {
    //            var totalJob = new JobSubScheme
    //            {
    //                Type = schemeJob.Type,
    //                Scope = schemeJob.Scope,
    //                Data = schemeJob.Data
    //            };
    //            totalPersonJobs.Add(totalJob);

    //            var foundActorJobs = actorJobs.Where(x => x.Scope == schemeJob.Scope && x.Type == schemeJob.Type).ToArray();
    //            if (foundActorJobs.Count() > 1)
    //            {
    //                Logger.TraceError(LogCodes.ErrorCommon, "Для задачи перка актёра найдено больше одной задачи из схемы.");
    //            }
    //            var actorJob = foundActorJobs.FirstOrDefault();

    //            var foundPersonJobs = activePerk.CurrentJobs.Where(x => x.Scope == schemeJob.Scope && x.Type == schemeJob.Type).ToArray();
    //            if (foundPersonJobs.Count() > 1)
    //            {
    //                Logger.TraceError(LogCodes.ErrorCommon, "Для задачи перка персонажа найдено больше одной задачи из схемы.");
    //            }
    //            var personJob = foundPersonJobs.FirstOrDefault();

    //            if (personJob != null)
    //            {
    //                if (actorJob != null)
    //                {
    //                    if (schemeJob.Scope == JobScope.Global)
    //                    {
    //                        totalJob.Value = personJob.Progress + actorJob.Value;
    //                    }
    //                    else if (schemeJob.Scope == JobScope.Scenario && personJob.Progress < actorJob.Value)
    //                    {
    //                        totalJob.Value = actorJob.Value;
    //                    }
    //                }
    //                else
    //                {
    //                    totalJob.Value = personJob.Progress;
    //                }
    //            }
    //            else
    //            {
    //                if (actorJob != null)
    //                {
    //                    totalJob.Value = actorJob.Value;
    //                }
    //            }
    //        }

    //        return totalPersonJobs.ToArray();
    //    }

    //    /// <summary>
    //    /// Выполняет расчёт и обновление только работ перка.
    //    /// </summary>
    //    /// <param name="schemeJobs">Работы схемы.</param>
    //    /// <param name="factJobs">Фактические работы. Будут модифицированы.</param>
    //    /// <returns>true - если все работы перка прокачены. Иначе - false.</returns>
    //    /// <remarks>
    //    /// Для работ перка обновляется прогресс.
    //    /// Если условия работ перка выполнены, то отмечается признак <see cref="JobSubScheme.IsComplete">.
    //    /// !!!Если работа завершена, этот признак не должен сниматься данным методом.
    //    /// </remarks>
    //    //TODO Сделать отдельно метод, который выставляет признак Complete для задачи и метод проверки перка на выполнение всех условий.
    //    public static bool UpdateJobs(IEnumerable<JobSubScheme> schemeJobs, IEnumerable<JobSubScheme> factJobs)
    //    {
    //        if (!schemeJobs.Any())
    //        {
    //            throw new AppException("Обновление перка, у которого не заданы работы.");
    //        }

    //        var schemeJobArray = schemeJobs.ToArray();
    //        var factJobArray = factJobs.ToArray();

    //        var allJobsDone = true;
    //        for (var i = 0; i < schemeJobArray.Length; i++)
    //        {
    //            var schemeJob = schemeJobArray[i];
    //            var factJob = factJobArray.SingleOrDefault(x => x.Type == schemeJob.Type && x.Scope == schemeJob.Scope);

    //            if (factJob == null)
    //                continue;

    //            if (factJob.Value < schemeJob.Value)
    //            {
    //                allJobsDone = false;
    //            }
    //            else
    //            {
    //                factJobArray[i].IsComplete = true;
    //            }
    //        }

    //        return allJobsDone;
    //    }
    //}
}
