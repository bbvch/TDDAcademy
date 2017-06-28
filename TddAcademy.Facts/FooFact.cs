namespace TddAcademy.Facts
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;
    
    public class FooTest
    {
        private readonly Foo testee;
        private readonly IBar barFake;

        public FooTest()
        {
            this.barFake = A.Fake<IBar>();
            this.testee = new Foo(this.barFake);
        }

        [Fact]
        public void Say()
        {
            const string BarReturn = "fake";
            const string FooReturn = "foo";
            A.CallTo(() => this.barFake.Say()).Returns(BarReturn);

            var actual = this.testee.Say();

            actual.Should().Be(FooReturn + BarReturn);
        }
    }
}