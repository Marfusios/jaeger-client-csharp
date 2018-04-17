using System;
using System.Collections.Generic;
using Jaeger.Core.Samplers;
using Jaeger.Core.Util;
using NSubstitute;
using Xunit;

namespace Jaeger.Core.Tests.Samplers
{
    public class RateLimitingSamplerTests
    {
        [Fact]
        public void TestTags()
        {
            RateLimitingSampler sampler = new RateLimitingSampler(123);
            var tags = sampler.Sample("operate", new TraceId(11L)).Tags;
            Assert.Equal("ratelimiting", tags["sampler.type"]);
            Assert.Equal(123.0, tags["sampler.param"]);
        }
    }
}
