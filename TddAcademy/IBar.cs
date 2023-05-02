namespace TddAcademy
{
    public interface IBar
    {
        string Say();
    }

    public class Bar : IBar
    {
        public string Say()
        {
            return "bar";
        }
    }
}