using FluentAssertions;
using LambdaTale;

namespace TddAcademy.Specs;

public class TennisScorerSpec
{
    private readonly ITennisScorer scorer;

    public TennisScorerSpec()
    {
        scorer = new TennisScorer(new Game(), new PrettyPrinter());
    }

    [Background]
    public static void Background()
    {
        "Two players starting a game of tennis".x(() => {});
    }

    [Scenario]
    public void PlayingAQuiteCommonTypeOfGame()
    {
        const string continuationSequence = "ABBAA";

        $"Then the start score should be 'love all'".x(
            () => scorer.Score.Should().Be("love all"));

        $"When Player A scores".x(
            () => scorer.ScorePlayerA());

        $"Then scorer should be 'fifteen:love'".x(
            () => scorer.Score.Should().Be("fifteen:love"));

        $"When player continue to play like '{continuationSequence}'".x(
            () => PlayGame(scorer, continuationSequence));

        "Then Player A should have won".x(
            () => scorer.Score.Should().Be("A won"));
    }

    [Scenario]
    public void PlayingAGameWithDeuceAndAdvantageSituationAndBWinsATheEnd()
    {
        const string toDeuceSequence = "AAABBB";

        "When players play until a deuce situation".x(
            () => PlayGame(scorer, toDeuceSequence));

        "Then score should be 'deuce'".x(
            () => scorer.Score.Should().Be("deuce"));

        "When player A scores".x(
            () => scorer.ScorePlayerA());

        "Then score should be 'advantage A'".x(
            () => scorer.Score.Should().Be("advantage A"));

        PlayerBScores();

        "Then score should be 'deuce'".x(
            () => scorer.Score.Should().Be("deuce"));

        PlayerBScores();

        "Then score should be 'advantage B'".x(
            () => scorer.Score.Should().Be("advantage B"));

        PlayerBScores();

        "Player B should have won".x(
            () => scorer.Score.Should().Be("B won"));
    }

    private void PlayerBScores()
    {
        "When player B scores".x(() => 
            scorer.ScorePlayerB());
    }


    private static void PlayGame(ITennisScorer scorer, string scores)
    {
        foreach (var score in scores)
        {
            if (score == 'A')
            {
                scorer.ScorePlayerA();
            }

            if(score == 'B')
            {
                scorer.ScorePlayerB();
            }
        }
    }
}