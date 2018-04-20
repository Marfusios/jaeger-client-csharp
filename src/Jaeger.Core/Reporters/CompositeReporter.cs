using System.Collections.Generic;

namespace Jaeger.Core.Reporters
{
    public class CompositeReporter : IReporter
    {
        private readonly List<IReporter> _reporters;

        public CompositeReporter(params IReporter[] reporters)
        {
            _reporters = new List<IReporter>(reporters);
        }

        public void Report(Span span)
        {
            foreach (var reporter in _reporters)
            {
                reporter.Report(span);
            }
        }

        public void Dispose()
        {
            foreach (var reporter in _reporters)
            {
                reporter.Dispose();
            }
        }
    }
}
