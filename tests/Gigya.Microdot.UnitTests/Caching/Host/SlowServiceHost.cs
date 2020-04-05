﻿using Gigya.Microdot.Common.Tests;
using Gigya.Microdot.Fakes.KernelUtils;
using Gigya.Microdot.Hosting.Configuration;
using Gigya.Microdot.Ninject;
using Gigya.Microdot.Ninject.Host;
using Gigya.Microdot.SharedLogic;
using Ninject;

namespace Gigya.Microdot.UnitTests.Caching.Host
{
    public class SlowServiceHost : MicrodotServiceHost<ISlowService>
    {
        public SlowServiceHost() : base(new HostConfiguration(new TestHostConfigurationSource()))
        {
        }

        public string ServiceName => nameof(ISlowService).Substring(1);
        public override ILoggingModule GetLoggingModule() { return new ConsoleLogLoggersModules(); }

        protected override void Configure(IKernel kernel, BaseCommonConfig commonConfig)
        {
            kernel.Bind<ISlowService>().To<SlowService>().InSingletonScope();
            kernel.RebindForTests();
        }
    }
}
