using FluentAssertions;
using Xbehave;

namespace TddAcademy.Specs;

public class FooBarSpec
{
    private readonly Foo foo = new(new Bar());

    [Scenario]
    public void Say()
    {
        string? actual = null;

        "When foo says something"
            .x(() => actual = foo.Say());

        "Then foo should say 'foobar'"
            .x(() => actual.Should().Be("foobar"));
    }
}