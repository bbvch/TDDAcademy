namespace TddAcademy;

public class Foo
{
    private readonly IBar bar;

    public Foo(IBar bar)
    {
        this.bar = bar;
    }

    public string Say()
    {
        return "foo" + bar.Say();
    }
}