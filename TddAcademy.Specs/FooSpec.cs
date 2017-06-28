using FluentAssertions;
using Xbehave;

namespace TddAcademy.Specs
{
    public class FooFact
    {
        private Foo testee;

        [Background]
        public void Background()
        {
            "Given a foo class".x(() => this.testee = new Foo());
        }

        [Scenario]
        public void Foo(int result)
        {
            "When I execute bar".x(() => result = this.testee.Bar());

            "Then it should be the proper value".x(() => result.Should().Be(10));
        }
    }
}