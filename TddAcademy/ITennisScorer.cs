namespace TddAcademy;

public interface ITennisScorer
{
    void ScorePlayerA();
    void ScorePlayerB();
    string Score { get; }
}
