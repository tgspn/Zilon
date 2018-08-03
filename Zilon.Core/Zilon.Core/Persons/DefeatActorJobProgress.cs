﻿using System.Collections.Generic;

using Zilon.Core.Schemes;
using Zilon.Core.Tactics;

namespace Zilon.Core.Persons
{
    /// <summary>
    /// Прогресс работы по уничтожению цели.
    /// </summary>
    public class DefeatActorJobProgress : IJobProgress
    {
        private readonly IActor _target;

        public DefeatActorJobProgress(IActor target)
        {
            _target = target;
        }

        public IJob[] ApplyToJobs(IEnumerable<IJob> currentJobs)
        {
            var modifiedJobs = new List<IJob>();
            foreach (var job in currentJobs)
            {
                if (job.Scheme.Type == JobType.Defeats)
                {
                    job.Progress++;
                    modifiedJobs.Add(job);
                }
            }

            return modifiedJobs.ToArray();
        }
    }
}