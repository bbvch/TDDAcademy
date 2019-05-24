namespace TddAcademy;

public class Game
{
    private int pointsA;
    private int pointsB;

    public (int pointsA, int pointsB) Points
        => (pointsA, pointsB);

    public void ScorePlayerA()
    {
        if (PlayerBIsInAdvantage())
        {
            pointsB--;
            return;
        }

        pointsA++;

        bool PlayerBIsInAdvantage()
        {
            return pointsB == 4 && pointsA == 3;
        }
    }

    public void ScorePlayerB()
    {
        if (PlayerAIsInAdvantage())
        {
            pointsA--;
            return;
        }

        pointsB++;

        bool PlayerAIsInAdvantage()
        {
            return pointsA == 4 && pointsB == 3;
        }
    }
}