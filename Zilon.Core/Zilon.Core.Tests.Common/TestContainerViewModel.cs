﻿using Zilon.Core.Client;
using Zilon.Core.Tactics;

namespace Zilon.Core.Tests.Common
{
    public class TestContainerViewModel : IContainerViewModel
    {
        public IPropContainer Container { get; set; }
    }
}
