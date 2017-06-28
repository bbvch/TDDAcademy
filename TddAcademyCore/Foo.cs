namespace TddAcademy
{
    public class Foo : IFoo
    {
        private readonly IBar bar;

        public Foo(IBar bar)
        {
            this.bar = bar;
        }

        public string Say()
        {
            return "foo" + this.bar.Say();
        }
    }
}