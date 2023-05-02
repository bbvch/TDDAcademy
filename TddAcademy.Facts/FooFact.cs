using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts;

public class FooTest
{
    private readonly Foo testee;
    private readonly IBar barFake;

    public FooTest()
    {
        barFake = A.Fake<IBar>();
        testee = new Foo(barFake);
    }

    [Fact]
    public void Say()
    {
        const string BarReturn = "fake";
        const string FooReturn = "foo";
        A.CallTo(() => barFake.Say()).Returns(BarReturn);

        var actual = testee.Say();

        actual.Should().Be(FooReturn + BarReturn);
    }
}