namespace TddAcademy;

public class PrettyPrinter
{
    private const string PlayerA = "A";
    private const string PlayerB = "B";
    public const string LoveAll = "love all";
    public const string Love = "love";
    public const string Fifteen = "fifteen";
    public const string Thirty = "thirty";
    public const string Forty = "forty";
    public const string AWon = PlayerA + " won";
    public const string BWon = PlayerB + " won";
    public const string AdvantageA = "advantage " + PlayerA;
    public const string AdvantageB = "advantage " + PlayerB;
    public const string Deuce = "deuce";

    string[][] prettyScores =
    {
        new [] {LoveAll,             $"{Love}:{Fifteen}",    $"{Love}:{Thirty}",    $"{Love}:{Forty}",    BWon },
        new [] {$"{Fifteen}:{Love}", $"{Fifteen}:{Fifteen}", $"{Fifteen}:{Thirty}", $"{Fifteen}:{Forty}", BWon },
        new [] {$"{Thirty}:{Love}",  $"{Thirty}:{Fifteen}",  $"{Thirty}:{Thirty}",  $"{Thirty}:{Forty}",  BWon },
        new [] {$"{Forty}:{Love}",   $"{Forty}:{Fifteen}",   $"{Forty}:{Thirty}",   Deuce,                AdvantageB, BWon },
        new [] {AWon,                AWon,                   AWon,                  AdvantageA },
        new [] {"",                  "" ,                    "",                    AWon},
    };

    public string PrintScore(int pointsA, int pointsB)
    {
        return prettyScores[pointsA][pointsB];
    }
}