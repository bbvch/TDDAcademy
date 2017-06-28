using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts
{
    public class FooFact
    {
        private readonly Foo testee;

        public FooFact()
        {
            this.testee = new Foo();
        }

        [Fact]
        public void Foo()
        {
            var result = this.testee.Bar();

            result.Should().Be(10);
        }
    }
}