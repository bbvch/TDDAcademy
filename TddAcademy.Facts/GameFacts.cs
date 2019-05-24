using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts;

public class GameFacts
{
    private const string AdvantageASequence = "AAABBBA";
    private const string AdvantageBSequence = "AAABBBB";
    private readonly (int, int) expectedDeucePoints = (3, 3);

    private readonly Game testee;

    public GameFacts()
    {
        this.testee = new Game();
    }

    [Fact]
    public void ScoresShouldInitiallyBeZero()
    {
        testee.Points.Should()
            .Be((0, 0));
    }

    [Theory]
    [InlineData("A", 1, 0, "A scored once")]
    [InlineData("B", 0, 1, "B scored once")]
    [InlineData("AAB", 2, 1, "A scored twice and B scored once")]
    [InlineData("AAABBB", 3, 3, "game is in deuce")]
    [InlineData("AAAA", 4, 0, "A won")]
    [InlineData("ABBBB", 1, 4, "B won")]
    [InlineData("ABBBAAA", 4, 3, "advantage for player A")]
    [InlineData("ABABBAB", 3, 4, "advantage for player B")]
    public void WhenPlayersScoreScoreShouldBeIncreased(
        string scoredPoints,
        int expectedScoreOfA,
        int expectedScoreOfB,
        string reason)
    {
        RunScores(scoredPoints);

        var result = testee.Points;

        result.Should()
            .Be((expectedScoreOfA, expectedScoreOfB), reason);
    }

    [Fact]
    public void WhenGameIsInAdvantageAAndBScoresThenGoBackToDeuce()
    {
        RunScores(AdvantageASequence);

        testee.ScorePlayerB();

        testee.Points.Should()
            .Be(expectedDeucePoints);
    }

    [Fact]
    public void WhenGameIsInAdvantageBAndAScoresThenGoBackToDeuce()
    {
        RunScores(AdvantageBSequence);

        testee.ScorePlayerA();

        testee.Points.Should()
            .Be(expectedDeucePoints);
    }

    private void RunScores(string points)
    {
        foreach (var point in points)
        {
            if (point == 'A')
            {
                testee.ScorePlayerA();
            }
            else
            {
                testee.ScorePlayerB();
            }
        }
    }
}