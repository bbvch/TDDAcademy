using FluentAssertions;
using Xunit;

namespace TddAcademy.Specs;

public static class XUnitSpec
{
    public class A_new_foo
    {
        private readonly Foo foo = new(new Bar());

        [Fact]
        public void should_have_been_initialized() =>
            foo.Should().NotBeNull();

        [Fact]
        public void should_say_foobar() =>
            foo.Say().Should().Be("foobar");
    }
}