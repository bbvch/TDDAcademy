using FluentAssertions;
using Xunit;

namespace TddAcademy.Facts;

public class PrettyPrinterFacts
{

    // 0:0 0:1 0:2 0:3  B w
    // 1:0 1:1 1:2 1:3  B w
    // 2:0 2:1 2:2 2:3  B w
    // 3:0 3:1 3:2 deuc adB B w
    // A w A w A w adA
    //             A w


    [Theory]
    [InlineData(0, 0, "love all")]
    [InlineData(1, 0, "fifteen:love")]
    [InlineData(0, 1, "love:fifteen")]
    [InlineData(3, 3, "deuce")]
    public void PrettyPrintScores(int pointsA, int pointsB, string expected)
    {
        var testee = new PrettyPrinter();

        var result = testee.PrintScore(pointsA, pointsB);

        result.Should().Be(expected);
    }
}