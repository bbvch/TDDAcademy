using FakeItEasy;
using Shouldly;
using Xunit;

namespace TddAcademy.Facts;

public class FooFacts
{
    private readonly Foo testee;
    private readonly IBar barFake;

    public FooFacts()
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

        actual.ShouldBe(FooReturn + BarReturn);
    }
}