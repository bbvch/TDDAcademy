namespace TddAcademy;

public class TennisScorer : ITennisScorer
{
    private readonly Game game;
    private readonly PrettyPrinter prettyPrinter;

    public TennisScorer(Game game, PrettyPrinter prettyPrinter)
    {
        this.game = game;
        this.prettyPrinter = prettyPrinter;
    }

    public string Score =>
        prettyPrinter.PrintScore(
            game.Points.pointsA,
            game.Points.pointsB);

    public void ScorePlayerA()
    {
        game.ScorePlayerA();
    }

    public void ScorePlayerB()
    {
        game.ScorePlayerB();
    }
}